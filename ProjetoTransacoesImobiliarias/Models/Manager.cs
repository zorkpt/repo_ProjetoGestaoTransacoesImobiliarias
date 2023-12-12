using System.Collections.Generic;
using System.Dynamic;
using System.Text.Json.Serialization;
using ProjetoTransacoesImobiliarias.Controllers;

namespace ProjetoTransacoesImobiliarias.Models;

public class Manager : User
{
    public Manager(string username, string password, string name)
        : base(username, password, name, UserRole.Manager)
    {
    }
    
    public IEnumerable<Client> GetManagerClients() => Clients.AsReadOnly();

}

