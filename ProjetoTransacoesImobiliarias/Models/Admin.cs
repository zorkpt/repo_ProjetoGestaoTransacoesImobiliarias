using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;

namespace ProjetoTransacoesImobiliarias.Models
{
    public class Admin : User
    {
        public Admin(string username, string password, string name)
            : base(username, password, name, UserRole.Admin)
        {
            Clients = new List<Client>();
            Properties = new List<Property>();
        }

        public IEnumerable<Client> GetAdminClients() => Clients.AsReadOnly();
        public IEnumerable<Property> GetAdminProperties() => Properties.AsReadOnly();
    }
}