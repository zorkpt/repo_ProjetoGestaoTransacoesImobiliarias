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

        #region getClient
        public int ShowClientId()
        {
            
            return GetIdClient();
        }
        public string ShowClientName()
        {
            return GetNameClient();
        }
        public string ShowClientAdress()
        {
            return GetAddress();
        }

        public int ShowClientAgent()
        {
            return GetIdAgentClient();
        }

        #endregion endGet

        #region SetClient

        public void SetClientName(string name)
        {
            SetNameClient(name);
        }

        public void SetClientAdress(string adress)
        {
            SetAddressClient(adress);
        }

        public void SetClientAgent(int id)
        {
            SetIdAgentClient(id);
        }

        #endregion endSet
        public static List<ClientController> ClientControllerList = new List<ClientController>();

        //gerir clientes por aqui
        public ClientController(string name, string address, int userID) 
                            : base (name, address, userID)
        {

            if(!UserController.Access(userID, 2)){// Talvez nao por aqui
                throw new InvalidOperationException("Acess denied");
            }
            
            ClientControllerList.Add(this);//
        }


        //Fazer verificacao do ID do cliente com clientController? Ver com pessoal
        public static bool GetClientById(int id){
            
            ClientController? log = ClientController.ClientControllerList.FirstOrDefault(c => c.GetIdClient() == id);
            return log == null ? false : true;
            
        }

        public static ClientController? AddClient(string name, string adress, int UserID){
            ClientController a = new ClientController(name, adress, UserID);
            return a;
        }



        public bool RemoveClientController(){
            ClientController.ClientControllerList.Remove(this);
            this.RemoveClient();            
            return true;
        }
    }
}