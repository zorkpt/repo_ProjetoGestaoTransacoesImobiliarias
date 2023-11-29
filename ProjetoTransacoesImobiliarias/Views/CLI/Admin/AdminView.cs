using System;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class AdminView
{
    public static string? ShowAdminMenu(Admin admin)
    {
        Menu.AdminMenu(admin);
        return Console.ReadLine();
    }

    public static string? ManageUsersMenu()
    {
        Menu.ManageUsers();
        return Console.ReadLine();
    }

    public static string? ManageClientsMenu()
    {
        Menu.ManageClients();
        return Console.ReadLine();
    }

    public static string? ManagePropertiesMenu()
    {
        Menu.ManageProperties();
        return Console.ReadLine();
    }

    public static string? ManageTransactionsMenu()
    {
        Menu.ManageTransactions();
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
        MessageHandler.PressAnyKey();
    }

    public static ClientData AddClient()
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

    public static void DisplayAllClients(IEnumerable<Client> clients)
    {
        Console.Clear();
        Console.WriteLine("Lista de Todos os Utilizadores:");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("| ID | Username | Morada  |                        |");
        Console.WriteLine("---------------------------------------------------");
        foreach (var client in clients)
        {
            Console.WriteLine($"| {client.Id} | {client.Name} | {client.Address} | ");
        }

        Console.WriteLine("---------------------------------------------------");
        MessageHandler.PressAnyKey();
    }


    public static UserData AddUser()
    {
        Console.WriteLine("Adicionar novo utilizador:");
        Console.Write("Nome: ");
        var name = Console.ReadLine() ?? string.Empty;

        Console.Write("Username: ");
        var username = Console.ReadLine() ?? string.Empty;
        
        Console.Write("Password: ");
        var password = Console.ReadLine() ?? string.Empty;

        Console.Write("Role\n");
        var userRole = SelectUserRole();

        return new UserData
        {
            Name = name,
            Userame = username,
            Password = password,
            Role = userRole
        };
    }

    private static UserRole SelectUserRole()
    {
        while (true)
        {
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Manager");
            Console.WriteLine("3. Agent");
            Console.WriteLine("4. Evaluator");

            var choice = Console.ReadLine() ?? string.Empty;
            switch (choice)
            {
                case "1":
                    return UserRole.Admin;
                case "2":
                    return UserRole.Manager;
                case "3":
                    return UserRole.Agent;
                case "4":
                    return UserRole.Evaluator;
                default:
                    MessageHandler.PressAnyKey("Seleção Inválida. Escolhe entre 1 e 4.");
                    continue;
            }
        }
    }
}

public class ClientData
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}

public class UserData
{
    public string Name { get; set; }
    public string Userame { get; set; }

    public string Password { get; set; }
    public UserRole Role { get; set; }
}