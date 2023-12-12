using System.Collections.Generic;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Models;

public class Evaluator : User
{
    public Evaluator(string username, string password, string name)
        : base(username, password, name, UserRole.Evaluator)
    {
    }
    public IEnumerable<Client> GetEvaluatorClients() => Clients.AsReadOnly();
 
}
