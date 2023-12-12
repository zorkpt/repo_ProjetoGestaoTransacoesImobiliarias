using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;
using ProjetoTransacoesImobiliarias.Views.CLI.Client;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class EvaluatorController : UserController
{
    private readonly Evaluator _evaluator;
    private ProposalController proposalController;
    private TransactionController transactionController;
    private EvaluatorView evaluatorView { get; set; }
    private VisitsController visitsController;
    private PropertyController propertyController;

    public EvaluatorController(Evaluator evaluator, IUserService userService, IClientService clientService, IPropertyService propertyService)
        : base(userService, clientService, propertyService, new ProposalController(), new TransactionController(), new PropertyController(), new VisitsController())
    {
        _evaluator = evaluator;
        evaluatorView = new EvaluatorView();
    }

public override void MenuStart()
{
    var exitMenu = false;
    while (!exitMenu)
    {
        var option = EvaluatorView.ShowEvaluatorMenu(_evaluator);
        switch (option)
        {
            case "1":
                SubMenuManageClients();
                break;
            case "2":
                SubMenuManageTransactions();
                break;
            case "3":
                SubMenuManageProperties();
                break;
            case "99":
                if (_clientService.SaveClientsToJson())
                {
                    MessageHandler.PressAnyKey("Fechando aplicação...");
                }
                break;
            case "0":
                exitMenu = true;
                break;
            default:
                MessageHandler.WrongOption();
                break;
        }
    }
}

private void SubMenuManageClients()
{
    var exitMenu = false;
    while (!exitMenu)
    {
        var option = Menu.ManageClientsMenu();
        switch (option)
        {
            case "1":
                var clientData = ClientView.AddClient();
                _clientService.AddClient(clientData, _evaluator);
                break;
            case "2":
                EditClient();
                break;
            case "3":
                // DeleteClient();
                break;
            case "4":
                ListClients(false);
                break;
            case "5":
                ListClients();
                break;
            case "6":
                ManageClientOptions();
                break;
            case "0":
                exitMenu = true;
                break;
            default:
                MessageHandler.WrongOption();
                break;
        }
    }
}

private void SubMenuManageTransactions()
{
    var exitMenu = false;
    while (!exitMenu)
    {
        var option = EvaluatorView.ManageTransactionsMenu();
        switch (option)
        {
            case "1":
                // Nova Visita
                break;
            case "2":
                // Nova transação
                break;
            case "3":
                // Editar Transação
                break;
            case "0":
                exitMenu = true;
                break;
            default:
                MessageHandler.WrongOption();
                break;
        }
    }
}

private void SubMenuManageProperties()
{
    var exitMenu = false;
    while (!exitMenu)
    {
        var option = EvaluatorView.ManagePropertiesMenu();
        switch (option)
        {
            case "1":
                AddProperty(_evaluator);
                break;
            case "2":
                // Editar Propriedade
                break;
            case "3":
                // Eliminar Propriedade
                break;
            case "4":
                var allProperties = _propertyService.GetAllProperties();
                PropertyView.DisplayAllProperties(allProperties);
                break;
            case "0":
                exitMenu = true;
                break;
            default:
                MessageHandler.WrongOption();
                break;
        }
    }
}

private void ListClients(bool all = true)
{
    var clients = all ? _clientService.GetAllClients() : _evaluator.GetEvaluatorClients();
    ListClients(clients);
}
}