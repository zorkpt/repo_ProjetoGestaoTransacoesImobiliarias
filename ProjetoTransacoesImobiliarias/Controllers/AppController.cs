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

    /// <summary>
    /// Starts the application.
    /// </summary>
    /// <param name="user"></param>
    public void Start(User user)
    {
        ShowUserMenu(user);
    }

    /// <summary>
    /// Shows the menu for the user.
    /// </summary>
    /// <param name="user"></param>
    public void ShowUserMenu(User user)
    {
        UserController userController;

        switch (user)
        {
            case Admin admin:
                userController = new AdminController(admin, _userService, _clientService, _propertyService,
                    new ProposalController(), new TransactionController(), new PropertyController(),
                    new VisitsController());
                break;
            case Manager manager:
                 userController = new ManagerController(manager, _userService, _clientService, _propertyService);
                break;
            case Agent agent:
                userController = new AgentController(agent, _userService, _clientService, _propertyService);
                break;
            case Evaluator evaluator:
                userController = new EvaluatorController(evaluator, _userService, _clientService, _propertyService);
                break;

            default:
                Console.WriteLine("Tipo de utilizador desconhecido.");
                return;
        }

     userController.MenuStart();
        
    }
}