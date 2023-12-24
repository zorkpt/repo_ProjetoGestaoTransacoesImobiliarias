using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Services;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static ProjetoTransacoesImobiliarias.Models.Contact;
using Microsoft.IdentityModel.Tokens;

namespace TransacoesImobiliariasWinForms
{
    public class FormsController
    {
        private UserService _userService = new UserService();
        private Dados _dados;
        private FormsController _formController;
        public FormsController()
        {
            _dados = new Dados();
            
        }

        public void Start(User user, Form login)
        {
            login.Hide();
            UserForm form = new UserForm(user);
            form.Show();
        }

        public User StartLoginProcess(string userName, string pass, string origenDados)
        {
            #region json
            if (origenDados != "sql")
            {
                bool carrega = _userService.LoadUsersFromJsonWinforms();


                if (carrega)
                {
                    var allUsers = _userService.GetAllUsers();

                    var user = allUsers.FirstOrDefault(u =>
                         u.Username.Equals(userName, StringComparison.OrdinalIgnoreCase) &&
                         u.Password == pass);

                    if (user == null)
                    {
                        MessageBox.Show("Nao consegiu selecionar utilizador, nao existe?!");
                        return null;
                    }

                    return (User)user;
                }
                return null;
            }
            #endregion
            #region sql

            //var query = $"SELECT * FROM Users WHERE UserName = '" + userName + "' AND Passwords = '" + pass + "'";
            //Clipboard.SetText(query);
            var query = $"SELECT idUser, UserType, UserName, Passwords, Name " +
            $"FROM Users  " +
            $"JOIN UserType ON UserType.IdUserType = Users.IdUserType " +
            $"WHERE UserName = '{userName}' AND Passwords = '{pass}'";


            var dados = _dados.Select(query);

            if (dados == null) return null;

            if (dados.HasRows)
            {

                while(dados.Read())
                { 
                    string? uName = dados["UserName"].ToString();
                    string? password = dados["Passwords"].ToString();
                    string? name = dados["Name"].ToString();

                    
                        string userTypeString = dados["UserType"].ToString();
                        // Check if the 'UserType' column value is a valid UserRole enum
                        foreach (UserRole item in Enum.GetValues(typeof(UserRole)))
                        {
                            if (item.ToString() == userTypeString)
                            {
                                UserRole role =  item;
                                User user = _userService.CreateUser(uName, password, name, role);
                                return (user);
                                break;
                            }
                        }

                }
            }
            else return null;
            return null;
            #endregion

        }

        public string TotalFuncionariosSQL()
        {
            var query = "SELECT COUNT(IdUser) as NumUsers FROM Users";
            var dados = _dados.Select(query);

            if (dados == null) return "";

            if (dados.HasRows && dados.Read())
            {
                //var numUsers = dados.GetInt32(dados.GetOrdinal("NumUsers"));
                string numUsers = dados["NumUsers"].ToString();
                return numUsers;
            }
            return "Sem dados" ;
        }

        #region Sql para atualizar UserForm

        public string TotalClientesSQL()
        {
            var query = "SELECT COUNT(nif) as NumClientes FROM Cliente";
            var dados = _dados.Select(query);

            if (dados == null) return "";

            if (dados.HasRows && dados.Read())
            {
                //var numUsers = dados.GetInt32(dados.GetOrdinal("NumUsers"));
                string numUsers = dados["NumClientes"].ToString();
                return numUsers;
            }
            return "Sem dados";
        }

        public string TotalProVendaSQL()
        {
            var query = "SELECT COUNT(IdCMediacao) as NumPropriedadesVenda FROM ContratoMediacao WHERE Ativo = 1;";
            var dados = _dados.Select(query);

            if (dados == null) return "";

            if (dados.HasRows && dados.Read())
            {
                //var numUsers = dados.GetInt32(dados.GetOrdinal("NumUsers"));
                string numUsers = dados["NumPropriedadesVenda"].ToString();
                return numUsers;
            }
            return "Sem dados";
        }

        public string TotalProVendidasMesSQL()
        {
            var query = "SELECT COUNT(IdCMediacao) as NumPropriedadesVenda FROM ContratoMediacao WHERE Ativo = 1 AND data < DATEADD(Month, -1, GETDATE());";
            var dados = _dados.Select(query);

            if (dados == null) return "";

            if (dados.HasRows && dados.Read())
            {
                //var numUsers = dados.GetInt32(dados.GetOrdinal("NumUsers"));
                string numUsers = dados["NumPropriedadesVenda"].ToString();
                return numUsers;
            }
            return "Sem dados";
        }

        public string ClintePropEfetuadaSQL()
        {
            var query = "SELECT COUNT(distinct NIF) as NumPropostas FROM Cliente JOIN Proposta ON Proposta.[ClienteNIF Comprador] = cliente.NIF WHERE Proposta.Ativa = 1;";
            var dados = _dados.Select(query);

            if (dados == null) return "";

            if (dados.HasRows && dados.Read())
            {
                //var numUsers = dados.GetInt32(dados.GetOrdinal("NumUsers"));
                string numUsers = dados["NumPropostas"].ToString();
                return numUsers;
            }
            return "Sem dados";
        }

        public string ClienteFaltaPagamentoSQL()
        {
            var query = "SELECT COUNT(IdNegocio) as ContratosSemPagamento FROM ContratoCompraVenda LEFT JOIN Pagamento ON Pagamento.ContratoCompraVenda = ContratoCompraVenda.IdNegocio WHERE IdPagamento IS NULL;";
            var dados = _dados.Select(query);

            if (dados == null) return "";

            if (dados.HasRows && dados.Read())
            {
                //var numUsers = dados.GetInt32(dados.GetOrdinal("NumUsers"));
                string numUsers = dados["ContratosSemPagamento"].ToString();
                return numUsers;
            }
            return "Sem dados";


        }

        public string FuncionariosMesSQL()
        {
            var query = " NULL;";
            var dados = _dados.Select(query);

            if (dados == null) return "";

            if (dados.HasRows && dados.Read())
            {
                //var numUsers = dados.GetInt32(dados.GetOrdinal("NumUsers"));
                string numUsers = dados["ContratosSemPagamento"].ToString();
                return numUsers;
            }
            return "Sem dados";
        }

        #endregion

        #region Sql para Clientes
        public bool InserirClienteSQL(string nome, string nif, DateTime data, string contacto, string cc,
                                        string morada, string tipoContacto)
        {

            string? tipoTXT = _dados.ProcTipoContactoByName(tipoContacto);
            if(tipoTXT.IsNullOrEmpty()) return false;
            int tipo;
            int nifInt = int.TryParse(nif, out int result) ? result : -1;
            int ccInt;


            if (int.TryParse(tipoTXT, out tipo))
            {
                if(int.TryParse(cc, out ccInt)){

                    if (!_dados.InserirContacto(nifInt, tipo, contacto)) return false;

                    //converter em data
                    if (!_dados.InserirCliente(nifInt, nome, morada, data, ccInt)) return false;

                }
            }
            return true;
        }



        #endregion

    }
}
