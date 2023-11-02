using ProjetoTransacoesImobiliarias.Models;
//using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class AdminController : Admin
{
    
    //private int UserId;
    public static List<AdminController> AdminControllersList = new List<AdminController>();
     AdminController(){
        
    }
    public AdminController(string userName, string password)
                            : base (userName, password, UserRole.Admin)
    {
        AdminControllersList.Add(this);
    }
    public bool AddClientByAdmin(string name, string address, int userID){

        this.AddClient(name, address, userID);
        return this != null ? true : false;

    }
    
}