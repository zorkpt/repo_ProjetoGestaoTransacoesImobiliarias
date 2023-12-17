using Microsoft.Data.SqlClient;
using ProjetoTransacoesImobiliarias.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace TransacoesImobiliariasWinForms
{
    internal class Dados
    {

        #region Atributos
        private string servidor = "127.0.0.1";
        private string UsernameBD = "Geral";
        private string passwordBD = "Ricardo10@@";
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

        

        #endregion
    }
}
