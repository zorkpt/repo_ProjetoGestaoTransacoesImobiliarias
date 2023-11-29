using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class AppController 
{
    private readonly IUserService _userService;
    private readonly IClientService _clientService;
    private readonly IPropertyService _propertyService;

    public AppController(IUserService userService, IClientService clientService, IPropertyService propertyService)
    {
        _userService = userService;
        _clientService = clientService;
        _propertyService = propertyService;
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
                var adminController = new AdminController(admin, _userService, _clientService, _propertyService );
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