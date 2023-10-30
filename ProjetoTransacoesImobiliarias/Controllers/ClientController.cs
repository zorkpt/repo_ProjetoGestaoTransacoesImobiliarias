using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Controllers
{
    public class ClientController : Client
    {
        //gerir clientes por aqui
        public ClientController(string name, string address, int userID) : base (name, address, userID)
        {

        }


        //Fazer verificacao do ID do cliente com clientController? Ver com pessoal
        public static bool GetClientById(int id){
            Client? log = Client.ClientList.FirstOrDefault(u => u.IdClient == id);
            return log == null ? false : true;
            
        }
    }
}