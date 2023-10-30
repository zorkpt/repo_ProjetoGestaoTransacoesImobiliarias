using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        protected static Client? AddClient(string name, string adress, int UserID){
            Client a = new Client(name, adress, UserID);
            return a;
        }

        /// <summary>
        /// Searches for a client in the clientList by their IdClient.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="clientList"></param>
        /// <returns>The IdClient of the found client if it exists in the clientList, otherwise -1.</returns>
        protected static int SearchClientById(Client c, List<Client> clientList){

            foreach(Client? cliente in clientList){
                return cliente.IdClient == c.IdClient ? c.IdClient : -1;
            }

            return -1;
        }


        /// <summary>
        /// Removes a client from the clientList by the specified Id.
        /// </summary>
        /// <param name="Id">The Id number of the client to be removed.</param>
        /// <param name="clientList">List of clients</param>
        /// <returns>True if the client was successfully removed, false otherwise.</returns>
        protected static bool RemoveClientById(int Id, List<Client> clientList)
        {
            
            foreach(Client cliente in clientList){
                if(cliente.IdClient == Id){
                    clientList.Remove(cliente);
                    return true;
                }
            }

            return false;
        }

        protected static bool EditClientNameByID(Client c, string newName, List<Client> clientList)
        {
            c.Name = newName;
            
            return true;
        }
        protected static bool EditClientAdressyID(Client c, string newAdress)
        {
            c.Adress = newAdress;

            return false;
        }


        protected static Client RegisterProperty(string name, string adress, int IdAgent)
        {
            Client a = new Client(name, adress, IdAgent);
            return a;
        }



    }
}