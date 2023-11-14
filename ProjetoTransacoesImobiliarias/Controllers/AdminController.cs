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

    public AdminController(Admin admin, IUserService userService, IClientService clientService)
    {
        _admin = admin;
        _userService = userService;
        _clientService = clientService;
    }

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
                    if(_clientService.SaveClientsToJson()){
                        ErrorHandler.PressAnyKey("Fechando aplicação...");
                    }

                    break;
                case "0":
                    exitMenu = true;
                    break;
                default:
                    ErrorHandler.WrongOption();
                    break;
            }
        }
    }

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
                    ErrorHandler.WrongOption();
                    break;
            }
        }
    }

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
                    ErrorHandler.WrongOption();
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
                    ErrorHandler.WrongOption();
                    break;
            }
        }
    }

    private void SubMenuManageProperties()
    {
        var exitMenu = false;
        while (!exitMenu)
        {
            var option = AdminView.ManagePropertiesMenu();
            switch (option)
            {
                case "1":
                    // Adicionar Propriedade
                    break;
                case "2":
                    // Editar Propriedade
                    break;
                case "3":
                    // Eliminar Propriedade
                    break;
                case "0":
                    exitMenu = true;
                    break;
                default:
                    ErrorHandler.WrongOption();
                    break;
            }
        }
    }

    private void ListClients(bool all = true)
    {
        var clients = all ? _clientService.GetAllClients() : _admin.GetAdminClients();
        if (!clients.Any())
        {
            ErrorHandler.PressAnyKey("Sem dados.");
        }
        else
        {
            AdminView.DisplayAllClients(clients);
        }
    }

    private void ListAllUsers()
    {
        var allUsers = _userService.GetAllUsers();
        AdminView.DisplayUsers(allUsers);
    }

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

        // @TODO: Deveriamos alterar o nome da classe para MessageHandler ?
        ErrorHandler.PressAnyKey("Cliente Adicionado com sucesso.");
        _admin.AddClient(newClient);
        return newClient;
    }

    private Client EditClient()
    {
        return null;
    }

    private Client DeleteClient()
    {
        return null;
    }

    private User AddUser()
    {
        var adminView = new AdminView();
        var clientData = AdminView.AddUser();

        var newUser =
            _userService.CreateUser(clientData.Userame,clientData.Password,clientData.Name,clientData.Role);

        if (newUser is null)
        {
            // tratar do erro aqui ? 
            return null;
        }

        // @TODO: Deveriamos alterar o nome da classe para MessageHandler ?
        ErrorHandler.PressAnyKey("Utilizador Adicionado com sucesso.");
        return newUser;
    }
}