using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class AppController
{
    public static void ShowUserMenu(User user)
    {
        switch (user)
        {
            case Admin admin:
                AdminController.Menu(admin); 
                break;
            case Manager manager:
                ManagerController.Menu(manager);
                break;
            case Agent agent:
                AgentController.Menu(agent);
                break;
            case Evaluator evaluator:
                EvaluatorController.Menu(evaluator);
                break;
            
            default:
                // use default to deal with error ? 
                break;
        }
    }
}