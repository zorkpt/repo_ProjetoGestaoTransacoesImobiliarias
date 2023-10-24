using System.Reflection.Metadata;
using Projeto_de_Gestao_de_Transacoes_Imobiliarias.Controllers;
using Projeto_de_Gestao_de_Transacoes_Imobiliarias.Models;

namespace Projeto_de_Gestao_de_Transacoes_Imobiliarias;

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