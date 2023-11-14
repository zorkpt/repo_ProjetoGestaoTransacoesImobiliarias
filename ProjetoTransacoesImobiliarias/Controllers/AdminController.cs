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
                    AdminView.ManageUsersMenu();
                    break;
                case "2":
                    AdminView.ManageClientsMenu();
                    break;
                case "3":
                    break;
                case "4":
                    AdminView.ManagePropertiesMenu();
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

    public Client AddClient()
    {
        var adminView = new AdminView();
        var clientData = adminView.AddClient();

        var newClient = _clientService.CreateClient(clientData.Name, clientData.Address, clientData.PhoneNumber, _admin);

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

    public bool AddClientByAdmin(string name, string address, int userID)
    {
        //      this.AddClient(name, address, userID);
        //      return this != null ? true : false;
        return true;
    }

}