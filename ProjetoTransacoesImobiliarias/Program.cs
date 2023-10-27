using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias;

internal class Program
{
    private static void Main(string[] args)
    {
        
        Manager manager = new Manager("USERNAME", "PASS");
        ManagerController lidar = new ManagerController();

        Client novoCliente = lidar.AddClient("Hugo", "Morada", manager.Id);

        List<Client> lista = new List<Client>();

        lista.Add(novoCliente);

        int num = lidar.SearchClientById(novoCliente, lista);
        Console.WriteLine($"O numdero do ID do cliente é: {num}");

        AppController.Run();
        
    }
    
}