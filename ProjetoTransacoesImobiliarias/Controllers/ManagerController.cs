using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views;
using ProjetoTransacoesImobiliarias.Views.CLI;
using ProjetoTransacoesImobiliarias.Views.CLI.Client;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class ManagerController: UserController
{   
    private readonly Manager _manager;
    private ProposalController proposalController;
    private TransactionController transactionController;
    private ManagerView managerView { get; set; }
    private VisitsController visitsController;
    private PropertyController propertyController;

    public ManagerController(Manager manager, IUserService userService, IClientService clientService, IPropertyService propertyService)
        : base(userService, clientService, propertyService, new ProposalController(), new TransactionController(), new PropertyController(), new VisitsController())
    {
        _manager = manager;
        managerView = new ManagerView();
    }

    public override void MenuStart()
    {
        var exitMenu = false;
        while (!exitMenu)
        {
            var option = ManagerView.ShowManagerMenu(_manager);
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
                    _clientService.AddClient(clientData, _manager);
                    break;
                case "2":
                    EditClient();
                    break;
                case "3":
                  //  DeleteClient();
                    break;
                case "4":
                    ListClients(false);
                    break;
                case "5":
                    ListClients();
                    break;
                case "6":
                    ManageClientOptions();//novo
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
            var option = ManagerView.ManageTransactionsMenu();
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
            var option = ManagerView.ManagePropertiesMenu();
            switch (option)
            {
                case "1":
                    AddProperty(_manager);
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
        var clients = all ? _clientService.GetAllClients() : _manager.GetManagerClients();
        ListClients(clients);
    }
}