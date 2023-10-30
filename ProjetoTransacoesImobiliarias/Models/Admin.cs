using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;

namespace ProjetoTransacoesImobiliarias.Models
{
    public class Admin : User
    {
        protected decimal CommissionValue { get; set; }
        public Admin(){
            //vazio
        }
        public Admin(string username, string password)
            : base(username, password, UserRole.Admin)
        {
            
        }

        protected static bool EditClientNameByID(ClientController c, string newName, List<ClientController> clientList)
        {
            c.SetClientName(newName);
            
            return true;
        }
        protected static bool EditClientAdressyID(ClientController c, string newAdress)
        {
            c.SetClientAdress(newAdress);

            return false;
        }


        protected static ClientController RegisterProperty(string name, string adress, int IdAgent)
        {
            ClientController a = new ClientController(name, adress, IdAgent);
            return a;
        }



    }
}