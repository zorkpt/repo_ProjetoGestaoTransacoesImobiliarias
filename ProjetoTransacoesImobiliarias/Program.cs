using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias;

internal class Program
{
    private static void Main(string[] args)
    {
        
        Console.Clear();
        while(true){
            Console.WriteLine("Choose one option:");
            Console.WriteLine("1. CLI");
            Console.WriteLine("2. WinFOrms");
            Console.WriteLine("0. Sair");

            int choice;
            if(int.TryParse(Console.ReadLine(), out choice)){
                switch(choice){
                    case 1:
                        CliMainView.Show();
                        return;
                    case 2: 

                        break;
                    case 0:
                        return;
                }
            }else
            {
                Console.WriteLine("Entrada inválida. Por favor, insere um número.");
            }
        }

        Manager manager = new Manager("USERNAME", "PASS");
        ManagerController hugo = new ManagerController(manager);
        
        Client novoCliente = hugo.AddClient("Hugo", "Morada");

        List<Client> lista = new List<Client>();

        lista.Add(novoCliente);

        hugo.SeeList(lista);

        int num = hugo.SearchClientById(novoCliente, lista);
        Console.WriteLine($"O numdero do ID do cliente é: {num}");

        //AppController.Run();
        
    }
    
}