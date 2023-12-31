using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;

namespace ProjetoTransacoesImobiliarias.Models
{
    public class Agent : User
    {
        public Agent(string username, string password, string name)
            : base(username, password, name, UserRole.Agent)
        {
            
        }

        public IEnumerable<Client> GetAgentClients() => Clients.AsReadOnly();
 

    }
}