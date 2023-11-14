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

    public static void DisplayAllClients(IEnumerable<Client> clients)
    {
        Console.Clear();
        Console.WriteLine("Lista de Todos os Utilizadores:");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("| ID | Username | Morada                            |");
        Console.WriteLine("---------------------------------------------------");
        foreach (var client in clients)
        {
            var role = client.GetType().Name;
            Console.WriteLine($"| {client.Id} | {client.Name} | {client.Address} |");
        }
        Console.WriteLine("---------------------------------------------------");
        ErrorHandler.PressAnyKey();
    }
}

public class ClientData
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}