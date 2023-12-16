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

namespace TransacoesImobiliariasWinForms
{
    public class FormsController
    {
        private UserService _userService = new UserService();
        private Dados _dados;
        public FormsController()
        {
            _dados = new Dados();
        }

        public void Start(User user)
        {
            MessageBox.Show($"Resultou! {user.Name}");
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

            var query = $"SELECT * FROM Users WHERE UserName = '" + userName + "' AND Password = '" + pass + "'";
            Clipboard.SetText(query);

            var dados = _dados.Select(query);

            if (dados.HasRows) // com erro aqui
            {
                string? uName = dados["UserName"].ToString();
                string? password = dados["Password"].ToString();
                string? name = dados["Name"].ToString();
                UserRole role = (UserRole)Enum.Parse(typeof(UserRole), dados["Role"].ToString());

                User user = _userService.CreateUser(uName, password, name, role);

                return user;
            }
            else return null;

            #endregion

        }

    }
}
