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
        public Agent(string username, string password)
            : base(username, password, UserRole.Agent)
        {
            
        }

 

    }
}