using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;

namespace ProjetoTransacoesImobiliarias.Models
{
    public class Client
    {
        private static int Contador = 0;//ver esta linha
        private int idClient;
        private string name;
        private string adress;
        private int idAgent;
        protected static List<Client> ClientList = new List<Client>();

        protected Client(string nome, string morada, int userID)
        {
            if(!UserController.Access(userID, 2)){
                throw new InvalidOperationException("Acess denied");
            }
            this.SetIdClient(Contador++);
            this.SetNameClient(nome);
            this.SetAdressClient(morada);
            this.SetIdAgentClient(userID);

            ClientList.Add(this);
        }


        #region Proprities

        private int SetIdClient(int id)
        {
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