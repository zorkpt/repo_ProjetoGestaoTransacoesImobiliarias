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
        public List<Property> Properties { get; private set; }

        public Admin(string username, string password, string name)
            : base(username, password, name, UserRole.Admin)
        {
            Clients = new List<Client>();
            Properties = new List<Property>();
        }

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public void AddProperty(Property property)
        {
            Properties.Add(property);
        }
        public IEnumerable<Client> GetAdminClients() => Clients.AsReadOnly();
    }
}