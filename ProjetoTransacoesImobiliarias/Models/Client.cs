using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;


namespace ProjetoTransacoesImobiliarias.Models
{
    public class Client
    {
        private static int Contador = 1;

        public int IdClient { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public int IdAgent { get; private set; }

        public static List<Client> ClientList { get; } = new List<Client>();

  
        public Client(string name, string address, int idAgent)
        {
            IdClient = GetNextId();
            Name = name;
            Address = address;
            IdAgent = idAgent;
            RegisterClient();
        }
        
        // json constructor
        [JsonConstructor]
        public Client(int idClient, string name, string address, int idAgent)
        {
            IdClient = idClient;
            Name = name;
            Address = address;
            IdAgent = idAgent;
            RegisterClient();
        }

        private void RegisterClient()
        {
            ClientList.Add(this);
        }

        #region Proprities

        protected int GetIdClient()
        {
            return IdClient;
        }

        protected bool SetIdClient(int id){
            
            IdClient = id;
            return true;
        }

        protected string GetNameClient()
        {
            return Name;
        }
        protected string GetAddress()
        {
            return Address;
        }

        protected void SetAddressClient(string value)
        {
            Address = value;
        }

        protected void SetNameClient(string value)
        {
            Name = value;
        }

        protected int GetIdAgentClient()
        {
            return IdAgent;
        }

        protected void SetIdAgentClient(int value)
        {
            IdAgent = value;
        }
        #endregion

        protected bool RemoveClient(){
            //remove cliente na instancia atual
            ClientList.Remove(this);
            return true;
        }
        protected static bool RemoveClientById(int id)
        {
            Client? log = ClientList.FirstOrDefault(c => c.GetIdClient() == id);
            if(log == null) return false;

            ClientList.Remove(log);
            Contador--;
            return true;
        }

        private static int GetNextId()
        {
            return Contador++;
        }

        public static void InitializeNextId()
        {
            if (ClientList.Any())
            {
                Contador = ClientList.Max(c => c.IdClient) + 1;
            }
        }
    }
}