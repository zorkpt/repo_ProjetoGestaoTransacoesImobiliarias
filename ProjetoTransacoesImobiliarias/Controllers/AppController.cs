using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Services;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class AppController 
{
    private readonly IUserService _userService;
    private readonly IClientService _clientService;

    public AppController(IUserService userService, IClientService clientService)
    {
        _userService = userService;
        _clientService = clientService;
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
                var adminController = new AdminController(admin, _userService, _clientService);
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