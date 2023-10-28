using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTransacoesImobiliarias.Models
{
    public class Admin : User
    {
        public Admin(string username, string password)
            : base(username, password, UserRole.Admin)
        {
            
        }
    }
}