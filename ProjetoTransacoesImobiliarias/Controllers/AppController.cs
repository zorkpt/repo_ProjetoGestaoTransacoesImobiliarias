using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Services;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class AppController 
{
    private readonly IUserService _userService;

    public AppController(IUserService userService)
    {
        _userService = userService;
    }

    public void Start(User user)
    {
        ShowUserMenu(user);
    }

    private void ShowUserMenu(User user)
    {
        switch (user)
        {
            case Admin admin:
                var adminController = new AdminController(admin, _userService);
                adminController.Menu(); 
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