using System.Collections.Concurrent;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Services;
using ProjetoTransacoesImobiliarias.Views;
using ProjetoTransacoesImobiliarias.Views.CLI;
using ProjetoTransacoesImobiliarias.Views.CLI.Client;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class AdminController : UserController
{
    private readonly Admin _admin;
    private AdminView AdminView { get; set; }
    

    public AdminController(Admin admin, IUserService userService, IClientService clientService, IPropertyService propertyService,
        ProposalController proposalController, TransactionController transactionController, PropertyController propertyController, VisitsController visitsController)
        : base(userService, clientService, propertyService, proposalController, transactionController, propertyController, visitsController)
    {
        _admin = admin;
        AdminView = new AdminView();
    }

    /// <summary>
    /// Executes the menu functionality for the admin user.
    /// </summary>
    public override void MenuStart()
    {
        var exitMenu = false;
        while (!exitMenu)
        {
            var option = AdminView.ShowAdminMenu(_admin);
            switch (option)
            {
                case "1":
                    SubMenuManageClients();
                    break;
                case "2":
                    SubMenuManageUsers();
                    break;
                case "3":
                    SubMenuManageTransactions();
                    break;
                case "4":
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

    /// <summary>
    /// Manages the submenu for managing clients.
    /// </summary>
    private void SubMenuManageClients()
    {
        var exitMenu = false;
        while (!exitMenu)
        {
            var option = AdminView.ManageClientsMenu();
            switch (option)
            {
                case "1":
                    var clientData = ClientView.AddClient();
                    _clientService.AddClient(clientData, _admin);
                    break;
                case "2":
                    EditClient();
                    break;
                case "3":
                    DeleteClient();
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

    /// <summary>
    /// Manages the submenu for user management.
    /// </summary>
    private void SubMenuManageUsers()
    {
        var exitMenu = false;
        while (!exitMenu)
        {
            var option = AdminView.ManageUsersMenu();
            switch (option)
            {
                case "1":
                    AddUser();
                    break;
                case "2":
                    // Editar User
                    break;
                case "3":
                    // Eliminar User
                    break;
                case "4":
                    ListAllUsers(_userService);
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
            var option = AdminView.ManageTransactionsMenu();
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

    /// <summary>
    /// Manages the submenu for managing transactions.
    /// </summary>
    private void SubMenuManageProperties()
    {
        var exitMenu = false;
        while (!exitMenu)
        {
            var option = AdminView.ManagePropertiesMenu();
            switch (option)
            {
                case "1":
                    AddProperty(_admin);
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

    /// <summary>
    /// Lists clients based on the specified criteria.
    /// </summary>
    /// <param name="all"></param>
    private void ListClients(bool all = true)
    {
        var clients = all ? _clientService.GetAllClients() : _admin.GetAdminClients();
        ListClients(clients);
    }


    /// <summary>
    /// Deletes a client.
    /// </summary>
    /// <returns></returns>
    private Client? DeleteClient()
    {
        return null;
    }
}