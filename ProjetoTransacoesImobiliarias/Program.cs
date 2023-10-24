using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias;

internal class Program
{
    private static void Main(string[] args)
    {
        Manager managerTeste = new Manager(1,"Teste", "passwordSegura");

        Console.WriteLine(managerTeste.Username);
        Console.WriteLine(managerTeste.DisplayRoleSpecificInfo());
        
        Console.WriteLine(managerTeste.RegisterClient());
        bool registrationSuccess = managerTeste.RegisterClient();
        
        AppController.Run();
        
    }
    
}