using System;
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
        
        AppController.ShowUserMenu(user);
        
        foreach (var user1 in userService.GetAllUsers())
        {
            Console.WriteLine($"Nome: {user1.Id} - {user1.Username}");
        }
        
    }
}