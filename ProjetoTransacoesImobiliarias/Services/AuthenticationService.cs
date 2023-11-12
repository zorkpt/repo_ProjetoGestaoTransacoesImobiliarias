using System;
using System.Linq;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Services;

public class AuthenticationService
{
    private readonly UserService _userService;
    private User _loggedInUser;

    public AuthenticationService(UserService userService)
    {
        _userService = userService;
    }

    private User AuthenticateUser(string username, string password)
    {
        var allUsers = _userService.GetAllUsers();

        if (!allUsers.Any())
        {
            Console.WriteLine("Erro de autenticação: Nenhum utilizador foi carregado.");
            return null;
        }

        var user = allUsers.FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
            u.Password == password);

        if (user != null)
        {
            Console.WriteLine("Utilizador ligado com sucesso.");
            return user;
        }

        Console.WriteLine("Falha de autenticação: Utilizador ou senha incorretos.");
        return null;
    }

    public User StartLoginProcess()
    {
        var isLoggedIn = false;

        while (!isLoggedIn)
        {
            var loginData = new LoginView();
            loginData.Start();

            _loggedInUser = AuthenticateUser(loginData.username, loginData.password);
            isLoggedIn = _loggedInUser != null;
        }

        return _loggedInUser;
    }
}