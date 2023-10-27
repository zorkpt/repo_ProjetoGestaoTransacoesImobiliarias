using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias;

internal class Program
{
    private static void Main(string[] args)
    {
        

        Manager manager = new Manager("USERNAME", "PASS");
        ManagerController hugo = new ManagerController(manager);
        
        Client novoCliente = hugo.AddClient("Hugo", "Morada");

        List<Client> lista = new List<Client>();

        lista.Add(novoCliente);

        hugo.SeeList(lista);

        int num = hugo.SearchClientById(novoCliente, lista);
        Console.WriteLine($"O numdero do ID do cliente é: {num}");

        AppController.Run();
        
    }
    
}