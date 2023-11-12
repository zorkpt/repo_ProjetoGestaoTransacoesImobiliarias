using ProjetoTransacoesImobiliarias.Models;
//using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class AdminController : Admin
{

    public AdminController(string username, string password) : base(username, password)
    {
    }
    
    public static void Menu(Admin admin)
    {
        bool exitMenu = false;
        while (!exitMenu)
        {
            var option = AdminView.ShowAdminMenu(admin);
            switch (option)
            {
                case "1":
                    Console.WriteLine("escolhi a opcao 1");
                    // ManageUsers();
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
    
    
    public bool AddClientByAdmin(string name, string address, int userID){
        //      this.AddClient(name, address, userID);
        //      return this != null ? true : false;
        return true;
    }

}