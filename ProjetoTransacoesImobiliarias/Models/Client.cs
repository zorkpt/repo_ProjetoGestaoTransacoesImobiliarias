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
        public int idClient;
        public string name;
        public string adress;
        public int idAgent;
        public static List<Client> ClientList = new List<Client>();

        // public Client(string nome, string morada, int userID)
        // {

        //     this.SetIdClient(Contador++);
        //     this.SetNameClient(nome);
        //     this.SetAdressClient(morada);
        //     this.SetIdAgentClient(userID);

        //     ClientList.Add(this);


        // }

        public Client(string nome, string morada, int userID){
            this.name = nome;
            this.adress = morada;
            this.idAgent = userID;

            ClientList.Add(this);

            Client.SaveToJson1();
        }

        // Method to save the ClientList to JSON file
        public static void SaveToJson1()
        {
            try{
                string json = JsonSerializer.Serialize(ClientList);
                string FileJson = "Files/ClientJson.json";
                File.WriteAllText(FileJson, json);
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }

        }

        #region Proprities

        private int SetIdClient(int id)
        {
            if(id < 0 ){
                return -1;
            }
            return idClient = id;
        }
        protected int GetIdClient()
        {
            return idClient;
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

    }
}