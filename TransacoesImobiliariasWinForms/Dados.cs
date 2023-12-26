using Microsoft.Data.SqlClient;
using ProjetoTransacoesImobiliarias.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Shapes;
using static ProjetoTransacoesImobiliarias.Models.Contact;
using static System.Net.Mime.MediaTypeNames;


namespace TransacoesImobiliariasWinForms
{
    internal class Dados
    {

        #region Atributos
        private string servidor = "127.0.0.1";
        private string UsernameBD = "POO";
        private string passwordBD = "poo";
        private string tabelaBD = "TrabalhoAAD";

        #endregion

        #region Contrutor 
        public Dados() { }

        #endregion
        #region Metodos

        private SqlConnection Ligacao()
        {
            string connectionString = "Data Source=" + servidor + ";Initial Catalog=" + tabelaBD + ";User ID=" + UsernameBD + ";Password=" + passwordBD + ";TrustServerCertificate=True";

            SqlConnection conn = new SqlConnection(connectionString);
//            conn.AccessToken = "Integrated Security=True; Encrypt=False; TrustServerCertificate=True;";

            try
            {

                return conn;
            }
            catch (Exception ex)
            {

                MessageBox.Show("[Ligacao] Erro ao abrir a conexão: " + ex.Message);//enviar para erros
                throw; // Re-throw a exceção para que o chamador possa lidar com ela
            }
        }


        private bool Disconnect(SqlConnection conn)
        {

            try
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    return true;
                }
                else
                {
                    return false; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao fechar a conexão: " + ex.Message);
                return false; // Ocorreu um erro ao fechar a conexão
            }
        }

        public SqlDataReader Select(string sql)
        {
            try
            {
                SqlConnection conn = Ligacao();
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                if (command == null)
                {
                    Disconnect(conn);
                    return null;
                }
                SqlDataReader ler = command.ExecuteReader();
                if (ler == null)
                {
                    Disconnect(conn);
                    return null;
                }
                return ler;
            } catch (Exception ex) 
            {
                Clipboard.SetText(ex.Message);
                
                MessageBox.Show("[Select] " + ex.Message);
                return null;
            }

        }

        public bool Insert(string sql)
        {
            try
            {
                using (SqlConnection conn = Ligacao())
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        if (command == null)
                        {
                            return false;
                        }

                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Clipboard.SetText(ex.Message);
                MessageBox.Show("[Insert] " + ex.Message);
                return false;
            }
        }



        /// <summary>
        /// Procura clientes na base de dados por nif
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Lista de Clientes!</returns>
        public List<Client> ProcSqlByNif(string text)
        {
            List<Client> list = new List<Client>();

            //var query = "SELECT * FROM Cliente WHERE NIF LIKE '%" + text + "%';"; // tenho de mudar esta query

            var query = "SELECT* " +
                        "FROM Cliente " +
                        "left JOIN ClienteContacto ON ClienteContacto.ClienteNIF = Cliente.NIF " +
                        "LEFT JOIN[Tipo Contacto] ON[Tipo Contacto].TCId = ClienteContacto.TCId " +
                        " WHERE NIF LIKE '%" + text + "%';"; 

            var dados = Select(query);
            string? nif;
            string? morada;
            string? nome;
            string? dataNasc;
            string? cc;
            string? tel; string tipoContacto;

            if (dados == null) return null;
            while (dados.HasRows && dados.Read())
            {
                //var numUsers = dados.GetInt32(dados.GetOrdinal("NumUsers"));
                nif = dados["NIF"].ToString();
                nome = dados["Nome"].ToString();
                morada = dados["Morada"].ToString();
                dataNasc = dados["DataNasc"].ToString();
                cc = dados["CC"].ToString();
                tipoContacto = dados["DescTC"].ToString();
                tel = dados["Contacto"].ToString();

                TipoContacto tipo =  Enum.TryParse(tipoContacto, ignoreCase: true, out TipoContacto result) ? result : TipoContacto.Email;


                Contact contact = new Contact(nif, tipo, tipoContacto);

                Client novo = new Client(nome, morada, contact, nif, cc, dataNasc);
                list.Add(novo);
            }

            return list;

        }

        /// <summary>
        /// Procuar cliente na Base de dados por nif
        /// </summary>
        /// <param name="text"></param>
        /// <returns>devolve um cliente</returns>
        public Client ProcClientSqlByNif(string text)
        {
            text = text.Trim();

            var query = "SELECT* " +
                        "FROM Cliente " +
                        "left JOIN ClienteContacto ON ClienteContacto.ClienteNIF = Cliente.NIF " +
                        "LEFT JOIN[Tipo Contacto] ON[Tipo Contacto].TCId = ClienteContacto.TCId " +
                        " WHERE NIF LIKE '%" + text + "%';";

            var dados = Select(query);
            string? nif;
            string? morada;
            string? nome;
            string? dataNasc;
            string? cc;
            string? tel; string tipoContacto;

            if (dados == null) return null;
            if (dados.HasRows && dados.Read())
            {
                //var numUsers = dados.GetInt32(dados.GetOrdinal("NumUsers"));
                nif = dados["NIF"].ToString();
                nome = dados["Nome"].ToString();
                morada = dados["Morada"].ToString();
                dataNasc = dados["DataNasc"].ToString();
                cc = dados["CC"].ToString();
                tipoContacto = dados["DescTC"].ToString();
                tel = dados["Contacto"].ToString();

                TipoContacto tipo = Enum.TryParse(tipoContacto, ignoreCase: true, out TipoContacto result) ? result : TipoContacto.Email;

                Contact contact = new Contact(nif, tipo, tipoContacto);

                Client novo = new Client(nome, morada, contact, nif, cc, dataNasc);
                return novo;

            }

            return null;

        }


        public List<Client> TodosClientes()
        {
            List<Client> list = new List<Client>();

            //var query = "SELECT * FROM Cliente WHERE NIF LIKE '%" + text + "%';"; // tenho de mudar esta query

            var query = "SELECT* " +
                        "FROM Cliente " +
                        "left JOIN ClienteContacto ON ClienteContacto.ClienteNIF = Cliente.NIF " +
                        "LEFT JOIN[Tipo Contacto] ON[Tipo Contacto].TCId = ClienteContacto.TCId ";

            var dados = Select(query);
            string? nif;
            string? morada;
            string? nome;
            string? dataNasc;
            string? cc;
            string? tel; string tipoContacto;

            if (dados == null) return null;
            while (dados.HasRows && dados.Read())
            {
                //var numUsers = dados.GetInt32(dados.GetOrdinal("NumUsers"));
                nif = dados["NIF"].ToString();
                nome = dados["Nome"].ToString();
                morada = dados["Morada"].ToString();
                dataNasc = dados["DataNasc"].ToString();
                cc = dados["CC"].ToString();
                tipoContacto = dados["DescTC"].ToString();
                tel = dados["Contacto"].ToString();

                TipoContacto tipo = Enum.TryParse(tipoContacto, ignoreCase: true, out TipoContacto result) ? result : TipoContacto.Email;


                Contact contact = new Contact(nif, tipo, tel);

                Client novo = new Client(nome, morada, contact, nif, cc, dataNasc);
                list.Add(novo);
            }

            return list;

        }

        public bool ExisteNif(string nif)
        {
            nif = nif.Trim();
            var query = "SELECT NIF " +
                        "FROM Cliente " +
                        "WHERE NIF =  '" + nif + "';";

            Clipboard.SetText(query);
            var dados = Select(query);
            if (dados == null) return false;
            while (dados.HasRows && dados.Read())
            {
                //MessageBox.Show(dados["NIF"].ToString());
                if (dados["NIF"].ToString() == nif)
                {

                    return true;
                }
            }

            return false;
        }

        public string ProcTipoContactoByName(string nome) 
        {
            var query = "SELECT TCId FROM [Tipo Contacto] " +
                        "WHERE DescTC = '" + nome + "';";
            //Clipboard.SetText(query);
            var dados = Select(query);
            
            if(dados.HasRows && dados.Read())
            {
                
                string? tipo = dados[0].ToString();
                return tipo;
            }

            return "";

        }

        public List<string> TodosTiposContactos()
        {

            var query = "SELECT DescTC FROM [Tipo Contacto]";
            List<String> list = new List<String>();
            bool temDados = false;
            var dados = Select(query);
            while (dados.HasRows && dados.Read())
            {

                list.Add(dados[0].ToString());
                temDados = true;
            }

            if(temDados) return list;
            return null;
        }


        #region Inserir Cliente

        public bool InserirContacto(int nif, int tipoContacto, string contacto)
        {

            var query = "INSERT ClienteContacto (ClienteNIF, TCId, Contacto) Values(" + nif + ", " + tipoContacto + ", '" + contacto + "');";

            Clipboard.SetText(query);
            if(!Insert(query)) return false;

            return true;

        }

        public bool InserirCliente(int nif, string nome, string morada, DateTime data, int cc)
        {

            var query = "INSERT Cliente (Nome, Morada, DataNasc, NIF, CC) " +
                        "Values('" + nome + "', '" + morada + "', '" + data + "', " + nif + ", " + cc + ");";

            Clipboard.SetText(query);
            if (!Insert(query)) return false;

            return true;

        }

        #endregion


        #endregion
    }
}
