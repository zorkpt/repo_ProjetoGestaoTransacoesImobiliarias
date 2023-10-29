using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;

namespace ProjetoTransacoesImobiliarias.Models
{
    public class Client
    {
        protected static int Contador = 0;//ver esta linha
        public int IdClient;
        public string Name;
        public string Adress {get; set;}
        public int IdAgent;
        public static List<Client> ClientList = new List<Client>();

        public Client(string nome, string morada, int userID)
        {
            if(!UserController.Access(userID, 2)){
                throw new InvalidOperationException("Acess denied");
            }
            this.IdClient = Contador++;
            this.Name = nome;
            this.Adress = morada;
            this.IdAgent = userID;

            ClientList.Add(this);
        }
    }
}