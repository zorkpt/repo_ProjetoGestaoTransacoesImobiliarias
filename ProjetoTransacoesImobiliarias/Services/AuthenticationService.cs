using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Services;

public class AuthenticationService
{
    private readonly UserService _userService;
    private UserTest _loggedInUser;

    public AuthenticationService(UserService userService)
    {
        _userService = userService;
    }

    private UserTest AuthenticateUser(string username, string password)
    {
        var allUsers = _userService.GetAllUsers();

        if (!allUsers.Any())
        {
            Console.WriteLine("Erro de autenticação: Nenhum usuário foi carregado.");
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

        Console.WriteLine("Falha de autenticação: Usuário ou senha incorretos.");
        return null;
    }
    
    public UserTest StartLoginProcess()
    {
        bool isLoggedIn = false;

        while (!isLoggedIn)
        {
            Console.WriteLine("Por favor, insira seu nome de usuário:");
            string username = Console.ReadLine();
            Console.WriteLine("Por favor, insira sua senha:");
            string password = Console.ReadLine();
            
            _loggedInUser = AuthenticateUser(username, password);
            isLoggedIn = _loggedInUser != null;
            
        }

        return _loggedInUser;
    }
}