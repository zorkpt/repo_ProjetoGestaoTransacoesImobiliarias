using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;

namespace ProjetoTransacoesImobiliarias.Models
{
    public class Admin : User
    {
        public List<Client> Clients { get; private set; }
        public Admin(string username, string password, string name)
            : base(username, password, name, UserRole.Admin)
        {
            Clients = new List<Client>();
        }

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public IEnumerable<Client> GetAdminClients() => Clients.AsReadOnly();
    }
}