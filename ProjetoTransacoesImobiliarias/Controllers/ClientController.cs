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
            return GetAdress();
        }

        public int ShowClientAgent()
        {
            return GetIdAgentClient();
        }

        #endregion endGet

        #region SetClient

        public void SetClientName(string name)
        {
            SetClientName(name);
        }

        public void SetClientAdress(string adress)
        {
            SetAdressClient(adress);
        }

        public void SetClientAgent(int id)
        {
            SetIdAgentClient(id);
        }

        #endregion endSet
        public static List<ClientController> ClientManagerList = new List<ClientController>();

        //gerir clientes por aqui
        public ClientController(string name, string address, int userID) 
                            : base (name, address, userID)
        {

            if(!UserController.Access(userID, 2)){// Talvez nao por aqui
                throw new InvalidOperationException("Acess denied");
            }
            ClientManagerList.Add(this);
        }


        //Fazer verificacao do ID do cliente com clientController? Ver com pessoal
        public static bool GetClientById(int id){
            
            ClientController? log = ClientController.ClientManagerList.FirstOrDefault(c => c.GetIdClient() == id);
            return log == null ? false : true;
            
        }

        public static ClientController? AddClient(string name, string adress, int UserID){
            ClientController a = new ClientController(name, adress, UserID);
            return a;
        }

        /// <summary>
        /// Searches for a client in the clientList by their IdClient.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="clientList"></param>
        /// <returns>The IdClient of the found client if it exists in the clientList, otherwise -1.</returns>
        protected int SearchClientById(ClientController c, List<ClientController> clientList){

            foreach(ClientController? cliente in clientList){
                return cliente.ShowClientId() == c.ShowClientId() ? c.ShowClientId() : -1;
            }

            return -1;
        }

        /// <summary>
        /// Removes a client from the clientList by the specified Id.
        /// </summary>
        /// <param name="Id">The Id number of the client to be removed.</param>
        /// <param name="clientList">List of clients</param>
        /// <returns>True if the client was successfully removed, false otherwise.</returns>
        protected static bool RemoveClientById(int Id, List<ClientController> clientList)
        {
            
            foreach(ClientController cliente in clientList){
                if(cliente.ShowClientId() == Id){
                    clientList.Remove(cliente);
                    return true;
                }
            }

            return false;
        }

    }
}