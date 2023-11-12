using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Services;
//using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class AdminController
{
    private readonly IUserService _userService;
    private readonly Admin _admin;
    
    public AdminController(Admin admin, IUserService userService)
    {
        _admin = admin;
        _userService = userService;
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
                    // ViewReports();
                    break;
                case "3":
                    // SystemSettings();
                    break;
                case "4":
                    // UpdateProfile(admin);
                    break;
                case "0":
                    exitMenu = true;
                    break;
                default:
                    AdminView.WrongOption();
                    break;
            }
        }
    }
    
    private void ListAllUsers()
    {
        var allUsers = _userService.GetAllUsers();
        AdminView.DisplayUsers(allUsers);
    }
    
    public bool AddClientByAdmin(string name, string address, int userID){
        //      this.AddClient(name, address, userID);
        //      return this != null ? true : false;
        return true;
    }

}