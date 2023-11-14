using System;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class AdminView
{
    public static string? ShowAdminMenu(Admin admin)
    {
        Console.Clear();
        Console.WriteLine("========== Menu de Administração ==========");
        Console.WriteLine($"Bem-Vindo {admin.Username}");
        Console.WriteLine("1. Gerir Utilizadores");
        Console.WriteLine("2. Adicionar Cliente");
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

   public ClientData AddClient()
    {
        Console.WriteLine("Adicionar novo cliente:");
        Console.Write("Nome: ");
        string clientName = Console.ReadLine() ?? string.Empty;

        Console.Write("Endereço: ");
        string clientAddress = Console.ReadLine() ?? string.Empty;

        Console.Write("Número de telefone: ");
        string clientPhoneNumber = Console.ReadLine() ?? string.Empty;

        return new ClientData
        {
            Name = clientName,
            Address = clientAddress,
            PhoneNumber = clientPhoneNumber
        };
    }
}

public class ClientData
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}