using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;
using System.Text.Json;
using System.IO;


namespace ProjetoTransacoesImobiliarias.Models
{
    public class Client
    {
        private static int Contador = 0;//ver esta linha
        private int idClient;
        private string name;
        private string adress;
        private int idAgent;
        public static List<Client> ClientList = new List<Client>();

        public Client(string nome, string morada, int userID)
        {

            this.SetIdClient(Contador++);
            this.SetNameClient(nome);
            this.SetAdressClient(morada);
            this.SetIdAgentClient(userID);

            ClientList.Add(this);


        }

        #region Proprities

        protected int GetIdClient()
        {
            return idClient;
        }

        protected bool SetIdClient(int id){
            
            idClient = id;
            return true;
        }

        protected string GetNameClient()
        {
            return name;
        }
        protected string GetAdress()
        {
            return adress;
        }

        protected void SetAdressClient(string value)
        {
            adress = value;
        }

        protected void SetNameClient(string value)
        {
            name = value;
        }

        protected int GetIdAgentClient()
        {
            return idAgent;
        }

        protected void SetIdAgentClient(int value)
        {
            idAgent = value;
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


    }
}