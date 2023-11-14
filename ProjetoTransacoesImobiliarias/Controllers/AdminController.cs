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
                    ListAllUsers();
                    break;
                case "2":
                    AddClient();
                    Console.WriteLine("adicionado com sucesso.");
                    break;
                case "3":
                    // SystemSettings();
                    break;
                case "4":
                    // UpdateProfile(_admin);
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

    if (newClient is null) {
        // tratar do erro aqui ? 
        return null;
    }

    return newClient;
    // @TODO: adicionar a uma lista de clientes do admin ?
}

    public bool AddClientByAdmin(string name, string address, int userID){
        //      this.AddClient(name, address, userID);
        //      return this != null ? true : false;
        return true;
    }

}