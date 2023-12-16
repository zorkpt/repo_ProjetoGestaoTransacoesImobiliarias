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

        public FormsController()
        {
            
        }

        public void Start(User user)
        {
            MessageBox.Show($"Resultou! {user.Name}");
        }

        public User StartLoginProcess(string userName, string pass)
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

    }
}
