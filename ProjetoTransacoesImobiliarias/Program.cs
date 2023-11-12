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
        var userService = new UserService();
        
        if (!userService.LoadUsersFromJson())
        {
            Console.WriteLine("Não foi possível carregar os dados do usuário. A aplicação será encerrada.");
            return;
        }

        var authService = new AuthenticationService(userService);

        var user = authService.StartLoginProcess();

        var appController = new AppController(userService);
        appController.Start(user);
        
    }
}