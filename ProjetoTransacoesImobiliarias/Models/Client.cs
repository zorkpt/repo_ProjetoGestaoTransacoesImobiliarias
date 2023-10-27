using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTransacoesImobiliarias.Models
{
    public class Client
    {
        protected static int Contador = 0;//ver esta linha
        public int IdClient;
        public string Name;
        public string Adress {get; set;}
        public int IdAgent;

        public Client(string nome, string morada, int agentID)
        {
            this.IdClient = Contador++;
            this.Name = nome;
            this.Adress = morada;
            this.IdAgent = agentID;
        }
    }
}