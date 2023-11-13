using System;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Controllers;

public static class AdminView
{
    public static string? ShowAdminMenu(Admin admin)
    {
        Console.Clear();
        Console.WriteLine("========== Menu de Administração ==========");
        Console.WriteLine($"Bem-Vindo {admin.Username}");
        Console.WriteLine("1. Gerir Utilizadores");
        Console.WriteLine("2. Ver Relatórios");
        Console.WriteLine("3. Configurações do Sistema");
        Console.WriteLine("4. Atualizar Perfil");
        Console.WriteLine("0. Sair");
        return Console.ReadLine();
    }


public static void DisplayUsers(IEnumerable<User> users)
    {
        Console.Clear();
        Console.WriteLine("Lista de Todos os Utilizadores:");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("| ID | Username | Role                            |");
        Console.WriteLine("---------------------------------------------------");
        foreach (var user in users)
        {
            var role = user.GetType().Name; 
            Console.WriteLine($"| {user.Id} | {user.Username} | {role,-30} |");
        }
        Console.WriteLine("---------------------------------------------------");
        ErrorHandler.PressAnyKey();
    }
}