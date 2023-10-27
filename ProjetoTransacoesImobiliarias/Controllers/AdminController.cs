using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class AdminController
{
    public static void StartView()
    {
        Console.WriteLine("View de Admin Iniciada");
    }
    public AdminController(){
        
    }

    public Manager AddManager(string userName, string pass)
    {
        Manager a = new Manager(userName, pass);
        return a;
    }
}