using System.Collections.Generic;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Models;

public class Evaluator : User
{
    public Evaluator(string username, string password)
        : base(username, password, UserRole.Evaluator)
    {
    }
    
}
