using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Services;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias;

internal class Program
{
    private static UserService _userService;
    
    private static void Main(string[] args)
    {
        Console.Clear();

        var userService = new UserService();
        
        if (!userService.LoadUsersFromJson())
        {
            Console.WriteLine("Não foi possível carregar os dados do usuário. A aplicação será encerrada.");
            return;
        }

        var authService = new AuthenticationService(userService);

        var user = authService.StartLoginProcess();
        
        MenuView.ShowUserMenu(user);


        foreach (var user1 in userService.GetAllUsers())
        {
            Console.WriteLine($"Nome: {user1.Id} - {user1.Username}");
        }
        
        // while(true){
        //     Console.WriteLine("Choose one option:");
        //     Console.WriteLine("1. CLI");
        //     Console.WriteLine("2. WinForms");
        //     Console.WriteLine("0. Sair");
        //
        //     if(int.TryParse(Console.ReadLine(), out var choice)){
        //         switch(choice){
        //             case 1:
        //                 CliMainView.Show();
        //                 return;
        //             case 2: 
        //                 break;
        //             case 0:
        //                 return;
        //         }
        //     }else
        //     {
        //         Console.WriteLine("Entrada inválida. Por favor, insere um número.");
        //     }
        // }
    }
}