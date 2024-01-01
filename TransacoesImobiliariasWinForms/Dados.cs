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
using Microsoft.Data.Sqlite;
using System.DirectoryServices.ActiveDirectory;

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


        #region testes

        private string? CaminhoBD = "../../trabalhoPOOsqlite.db";
        private string? scriptBD = "../../CriarTabelasSqlite3.sql";

        private void testeBD()
        {
            if (!File.Exists(CaminhoBD))
            {
                var connection = new SqliteConnection($"Data Source={CaminhoBD}");
                connection.Open();
                var commando = connection.CreateCommand();
                string scriptContent = File.ReadAllText(scriptBD);
                string[] commands = scriptContent.Split(';');

                foreach (var cmd in commands)
                {
                    if (!string.IsNullOrWhiteSpace(cmd))
                    {
                        commando.CommandText = cmd;
                        commando.ExecuteNonQuery();
                    }
                }

            }
        }

        #endregion


        #region Contrutor 
        public Dados() 
        {

        }

        #endregion
        
        #region Metodos

        /// <summary>
        /// Liga com a base de dados 
        /// </summary>
        /// <returns></returns>
        private SqliteConnection Ligacao()
        {
            if (File.Exists(CaminhoBD))
            {
                SqliteConnection connLite = new SqliteConnection("Data Source=" + CaminhoBD + ";");
                return connLite;

            }

            return null;

        }


        private bool Disconnect(SqliteConnection conn)
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

        public SqliteDataReader Select(string sql)
        {
            try
            {
                SqliteConnection conn = Ligacao();
                conn.Open();

                SqliteCommand command = new SqliteCommand(sql, conn);
                if (command == null)
                {
                    Disconnect(conn);
                    return null;
                }
                SqliteDataReader ler = command.ExecuteReader();
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
                using (SqliteConnection conn = Ligacao())
                {
                    conn.Open();

                    using (SqliteCommand command = new SqliteCommand(sql, conn))
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
                //Clipboard.SetText(ex.Message);
                MessageBox.Show("[Insert] " + ex.Message);
                return false;
            }
        }

        private bool Update(string sql)
        {
            try
            {
                SqliteConnection conn = Ligacao();
                conn.Open();

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        conn.Close();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
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
            Clipboard.SetText(query);
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

                Contact contact = new Contact(nif, tipo, tel);

                Client novo = new Client(nome, morada, contact, nif, cc, dataNasc);
                return novo;

            }

            return null;

        }

        /// <summary>
        /// Cria uma lista de todos os clientes 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Procura se existe um cliente com base no nif
        /// </summary>
        /// <param name="nif"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Procura tipo de contacto pelo nome.
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Lista todos os tipos de contactos disponiveis 
        /// </summary>
        /// <returns></returns>
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

            var query = "INSERT INTO ClienteContacto (ClienteNIF, TCId, Contacto) Values(" + nif + ", " + tipoContacto + ", '" + contacto + "');";

            Clipboard.SetText(query);
            if(!Insert(query)) return false;

            return true;

        }

        public bool InserirCliente(int nif, string nome, string morada, DateTime data, int cc)
        {

            var query = "INSERT INTO Cliente (Nome, Morada, DataNasc, NIF, CC) " +
                        "Values('" + nome + "', '" + morada + "', '" + data + "', " + nif + ", " + cc + ");";

            Clipboard.SetText(query);
            if (!Insert(query)) return false;

            return true;

        }
        #endregion
        
        #region update cliente
        public bool UpdateCliente(Client cliente)
        {

            var query = "UPDATE Cliente ";

            if(Update(query)) return true;
            return false;
        }

        public bool UpdateClieteNomeSQL(string nome, string nif)
        {
            var query = "UPDATE Cliente SET Nome = '" + nome + "' WHERE NIF = " + nif ;
            //Clipboard.SetText(query);
            if (Update(query)) return true;
            return false;
        }

        public bool ClienteUpdateMoradaSQL(string morada, string nif)
        {
            var query = "UPDATE Cliente SET Morada = '" + morada + "' WHERE NIF = " + nif;

            if (Update(query)) return true;
            return false;
        }

        public bool ClienteUpdateDataNascSQL(DateTime data, string nif)
        {
            var query = "UPDATE Cliente SET DataNasc = '" + data + "' WHERE NIF = " + nif;

            if (Update(query)) return true;
            return false;
        }

        public bool ClienteUpdateCCSQL(string cc, string nif)
        {

            var query = "UPDATE Cliente SET CC = '" + cc + "' WHERE NIF = " + nif;

            if (Update(query)) return true;
            return false;
        }

        public bool ContactoUpdateDescricaoSQL(Contact contact, string nif)
        {
            var query = "UPDATE ClienteContacto SET Contacto = '" + contact.Descricao + 
                        "' WHERE ClienteNIF = " + nif;

            if (Update(query)) return true;
            return false;
        }

        public bool ContactoUpdateTipoSQL(Contact contact, string nif)
        {


            var query = "UPDATE ClienteContacto SET Contacto = '" + contact.Tipo +
                        "' WHERE ClienteNIF = " + nif;

            if (Update(query)) return true;
            return false;
        }

        #endregion

        #region Delete cliente / contactos

        public bool DeleteContactos(Client cliente)
        {
            var query = "DELETE FROM ClienteContacto WHERE ClienteNIF = " + cliente.NIF;
            if(Update(query)) return true;
            return false;

        }

        public bool DeleteCliente(Client cliente)
        {
            var query = "DELETE FROM Cliente WHERE NIF = " + cliente.NIF;
            if (Update(query)) return true;
            return false;
        }

        #endregion

        #region Propriedades

        public List<Property> ListaPropriedades()
        {
            List<Property> lista = new List<Property>();

            var query = "SELECT Imovel.IdImovel, TipoImovel.Descricao, Area, [ClienteNIF Proprientario] as proprietario, Cliente.Nome " +
                        "FROM Imovel " +
                        "JOIN TipoImovel ON TipoImovel.IdTipoImovel = Imovel.IdTipoImovel " +
                        "JOIN Cliente ON Cliente.NIF = Imovel.[ClienteNIF Proprientario]";
            var dados = Select(query);

            string? id;
            string? propertyType;
            string? area;
            string? proprietarioNif;


            while (dados.HasRows && dados.Read())
            {
                id = dados["IdImovel"].ToString();
                propertyType = dados["Descricao"].ToString();
                area = dados["Area"].ToString();
                proprietarioNif = dados["proprietario"].ToString();

                if(int.TryParse(id, out int imovelId))
                {
                    if(double.TryParse(area, out double imovelArea))
                    {
                        if(int.TryParse(proprietarioNif, out int imovelProprietarioNif))
                        {
                            Property nova = new Property(imovelId, propertyType, imovelArea, imovelProprietarioNif);

                            lista.Add(nova);
                        }

                    }

                }

            }

            return lista;

        }

        #endregion

        #endregion
    }
}
