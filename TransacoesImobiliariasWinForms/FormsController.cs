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
using System.Diagnostics.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Azure.Core.Pipeline;

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

                while (dados.Read())
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
                            UserRole role = item;
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
            return "Sem dados";
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
            var query = " SELECT Agente.NomeAgente, COUNT(IdNegocio) " +
                        "FROM Agente " +
                        "JOIN ContratoMediacao ON NIFAgente = AgenteNIF " +
                        "JOIN Proposta ON IdContratoMediacao = IdCMediacao " +
                        "JOIN PropostaContrato ON PropostaIdProposta = IdProposta " +
                        "JOIN ContratoCompraVenda ON IdNegocio = ContratoCompraVenda " +
                        "JOIN Pagamento ON IdNegocio = Pagamento.ContratoCompraVenda " +
                        "WHERE Pagamento.IdPagamento IS NOT NULL " +
                        "GROUP BY NomeAgente " +
                        "HAVING COUNT(IdNegocio) >= ALL( " +
                        "                SELECT COUNT(IdNegocio) " +
                        "                FROM Agente " +
                        "                JOIN ContratoMediacao ON NIFAgente = AgenteNIF " +
                        "                JOIN Proposta ON IdContratoMediacao = IdCMediacao " +
                        "                JOIN PropostaContrato ON PropostaIdProposta = IdProposta " +
                        "                JOIN ContratoCompraVenda ON IdNegocio = ContratoCompraVenda " +
                        "                JOIN Pagamento ON IdNegocio = Pagamento.ContratoCompraVenda " +
                        "                WHERE Pagamento.IdPagamento IS NOT NULL " +
                        "                GROUP BY NomeAgente);";

            var dados = _dados.Select(query);

            if (dados == null) return "";

            if (dados.HasRows && dados.Read())
            {
                //var numUsers = dados.GetInt32(dados.GetOrdinal("NumUsers"));
                string numUsers = dados["NomeAgente"].ToString();
                return numUsers;
            }
            return "Sem dados";
        }

        #endregion

        #region Sql para Clientes
        /// <summary>
        /// Insere um cliente na base de dados
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="nif"></param>
        /// <param name="data"></param>
        /// <param name="contacto"></param>
        /// <param name="cc"></param>
        /// <param name="morada"></param>
        /// <param name="tipoContacto"></param>
        /// <returns></returns>
        public bool InserirClienteSQL(string nome, string nif, DateTime data, string contacto, string cc,
                                        string morada, string tipoContacto)
        {

            string? tipoTXT = _dados.ProcTipoContactoByName(tipoContacto);
            if (tipoTXT.IsNullOrEmpty()) return false;
            int tipo;
            int nifInt = int.TryParse(nif, out int result) ? result : -1;
            int ccInt;


            if (int.TryParse(tipoTXT, out tipo))
            {
                if (int.TryParse(cc, out ccInt)) {

                    if (!_dados.InserirContacto(nifInt, tipo, contacto)) return false;

                    //converter em data
                    if (!_dados.InserirCliente(nifInt, nome, morada, data, ccInt)) return false;

                }
            }
            return true;
        }
        /// <summary>
        /// Procura todos os tipos de contactos que possam existir
        /// </summary>
        /// <returns></returns>
        public List<string> TipoContactoSQL()
        {
            List<string> lista = new List<string>();

            lista = _dados.TodosTiposContactos();

            return lista;

        }
        /// <summary>
        /// Procura os contactos de um determinado cliente
        /// </summary>
        /// <param name="nif"></param>
        /// <returns></returns>
        public List<Contact> ListaContactos(string nif)
        {
            if (string.IsNullOrEmpty(nif)) return null;
            int num = int.Parse(nif);
            List<Contact> list = new List<Contact>();

            var query = "SELECT distinct ClienteNIF, Cliente.Nome, [Tipo Contacto].DescTC,ClienteContacto.Contacto, IdContacto " +
                        "FROM Cliente " +
                        "JOIN ClienteContacto on ClienteContacto.ClienteNIF = Cliente.NIF  " +
                        "JOIN[Tipo Contacto] ON[Tipo Contacto].TCId = ClienteContacto.TCId " +
                        "WHERE ClienteContacto.ClienteNIF = '" + num + "'";

            Clipboard.SetText(query);
            var dados = _dados.Select(query);

            while (dados.HasRows && dados.Read())
            {
                string? clienteNIF = dados["ClienteNIF"].ToString();
                string? valor = dados["DescTC"].ToString();
                string? contacto = dados["Contacto"].ToString();
                
                TipoContacto a = new TipoContacto();

                foreach (TipoContacto tipo in Enum.GetValues(typeof(TipoContacto)))
                {
                    if(valor == tipo.ToString())
                    {
                        a = tipo;
                        break;
                    }
                }

                //if (int.TryParse(valor, out int tipoInt))
                //{
                Contact novo = new Contact(clienteNIF, a, contacto);
                    list.Add(novo);
                //}

            }

            if(list !=  null)
            {
                return list;
            }
            return null;

        }

        #region Update cliente
        public bool CLienteUpdate(Client cliente)
        {
            if (cliente == null) return false;

            //procura na bd se existe nif
            if (_dados.ExisteNif(cliente.NIF))
            {
                //Client client = _dados.ProcClientSqlByNif(cliente.NIF);


                if (!ClienteUpdateNome(cliente.Name, cliente.NIF)) return false;
                if(!ClienteUpdateMorada(cliente.Address, cliente.NIF)) return false;
                if (!ClienteUpdateDataNasc(cliente.DateOfBirth, cliente.NIF)) return false;
                if (!ClienteUpdateCC(cliente.CC, cliente.NIF)) return false;

                if (!ContactoUpdateDescricao(cliente)) return false;
                if (!ContactoUpdateTipo(cliente)) return false;

                return true;

            }
            else
            {
                return false;
            }

        }
        public bool ClienteUpdateNome(string nome, string nif)
        {
            if(_dados.UpdateClieteNomeSQL(nome, nif)) return true;
            return false;
        }
        public bool ClienteUpdateMorada(string morada, string nif)
        {
            if(_dados.ClienteUpdateMoradaSQL(morada, nif)) return true;
            return false;
        }
        public bool ClienteUpdateDataNasc(string data, string nif)
        {
            //transformar string em DateTime
            if (DateTime.TryParse(data, out DateTime dataNascimento))
            {
                if (_dados.ClienteUpdateDataNascSQL(dataNascimento, nif)) return true;
                
            }
            return false;
        }
        public bool ClienteUpdateCC(string cc, string nif)
        {
            if(_dados.ClienteUpdateCCSQL(cc, nif)) return true;
            return false;
        }
        public bool ContactoUpdateDescricao(Client cliente)
        {
            if(_dados.ContactoUpdateDescricaoSQL(cliente.Contact, cliente.NIF)) return true;
            
            return false;
        }
        public bool ContactoUpdateTipo(Client cliente)
        {
            if (_dados.ContactoUpdateTipoSQL(cliente.Contact, cliente.NIF)) return true;

            return false;
        }
        #endregion

        #region Apagar cliente
        public bool ApagarCliente(Client cliente)
        {
            if (cliente == null) return false;
            //verifica se cliente existe na base de dados
            if (_dados.ExisteNif(cliente.NIF))
            {
                //elimina contactos deste cliente
                if(!_dados.DeleteContactos(cliente)) return false;
                //elimina este cliente!
                if(!_dados.DeleteCliente(cliente)) return false;
                return true;

            }
            return false;

        }

        #endregion

        #endregion


        #region Propriedades

        public List<Property> CriaListaPropriedades()
        {
            

            List<Property> list =  _dados.ListaPropriedades();

            return list;

        }

        #endregion

    }
}
