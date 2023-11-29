using System.Collections.Concurrent;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Services;
using ProjetoTransacoesImobiliarias.Views;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class AdminController
{
    private readonly IUserService _userService;
    private readonly IClientService _clientService;
    private readonly Admin _admin;
    private readonly IPropertyService _propertyService;
    private AdminView AdminView { get; set; }
    
    public AdminController(Admin admin, IUserService userService, IClientService clientService, IPropertyService propertyService)
    {
        _admin = admin;
        _userService = userService;
        _clientService = clientService;
        _propertyService = propertyService;
        AdminView = new AdminView();
    }

    /// <summary>
    /// Executes the menu functionality for the admin user.
    /// </summary>
    public void Menu()
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

                case "5":
                    ListClients(false);
                    break;
                case "6":
                    ListClients();
                    break;
                case "7":
                    AddClient();
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
                    AddClient();
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
                    ListAllUsers();
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
                    AddProperty();
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

    private Property AddProperty()
    {
        var propertyData = AdminView.AddProperty();
        var client = _clientService.GetClientById(propertyData.ClientId);
        var newProperty =
            _propertyService.CreateProperty(propertyData.Address,
                propertyData.Description,
                propertyData.PropertyType,
                propertyData.Size,
                _admin,
                client);
      
        if (newProperty is null)
        {
            return null;
        }

        MessageHandler.PressAnyKey("Propriedade adicionada com sucesso.");
        _admin.AddProperty(newProperty);
        return newProperty;
    }

    /// <summary>
    /// Lists clients based on the specified criteria.
    /// </summary>
    /// <param name="all"></param>
    private void ListClients(bool all = true)
    {
        var clients = all ? _clientService.GetAllClients() : _admin.GetAdminClients();
        if (!clients.Any())
        {
            MessageHandler.PressAnyKey("Sem dados.");
        }
        else
        {
            AdminView.DisplayAllClients(clients);
        }
    }

    /// <summary>
    /// Lists all users.
    /// </summary>
    private void ListAllUsers()
    {
        var allUsers = _userService.GetAllUsers();
        AdminView.DisplayUsers(allUsers);
    }

    /// <summary>
    /// Adds a new client to the system.
    /// </summary>
    /// <returns>Returns the newly created client object if successful, otherwise returns null.</returns>
    private Client AddClient()
    {
        var adminView = new AdminView();
        var clientData = AdminView.AddClient();

        var newClient =
            _clientService.CreateClient(clientData.Name, clientData.Address, clientData.PhoneNumber, _admin);

        if (newClient is null)
        {
            // tratar do erro aqui ? 
            return null;
        }

        MessageHandler.PressAnyKey("Cliente Adicionado com sucesso.");
        _admin.AddClient(newClient);
        return newClient;
    }

    /// <summary>
    /// Edits a client and returns the modified client.
    /// </summary>
    /// <returns></returns>
    private Client EditClient()
    {
        return null;
    }

    /// <summary>
    /// Deletes a client.
    /// </summary>
    /// <returns></returns>
    private Client DeleteClient()
    {
        return null;
    }

    /// <summary>
    /// Adds a new user to the system.
    /// </summary>
    /// <returns></returns>
    private User AddUser()
    {
        var clientData = AdminView.AddUser();
        var newUser = _userService.CreateUser(clientData.Userame,
                                                        clientData.Password,
                                                        clientData.Name,
                                                        clientData.Role);

        MessageHandler.PressAnyKey("Utilizador Adicionado com sucesso.");
        return newUser;
    }
}