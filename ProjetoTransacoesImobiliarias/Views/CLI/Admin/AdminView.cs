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

//    public static ClientData AddClient()
 //   {
  //      Console.WriteLine("Adicionar novo cliente:");
   //     Console.Write("Nome: ");
    //    string clientName = Console.ReadLine() ?? string.Empty;
//
 //       Console.Write("Endereço: ");
  //      string clientAddress = Console.ReadLine() ?? string.Empty;
//
 //       Console.Write("Número de telefone: ");
  //      string clientPhoneNumber = Console.ReadLine() ?? string.Empty;
//
 //       return new ClientData
  //      {
   //         Name = clientName,
    //        Address = clientAddress,
     //       PhoneNumber = clientPhoneNumber
      //  };
   // }

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
    
    public static PropertyData AddProperty()
    {
        Console.WriteLine("Adicionar nova propriedade:");
        Console.Write("Morada: ");
        var address = Console.ReadLine() ?? string.Empty;

        Console.Write("Descrição: ");
        var description = Console.ReadLine() ?? string.Empty;
        
        Console.Write("Tipo de Propriedade\n");
        var propertyType = SelectPropertyType();
        
        Console.Write("Área: ");
        var size = double.Parse(Console.ReadLine() ?? string.Empty);

        Console.Write("ID do Cliente: ");
        var clientId = int.Parse(Console.ReadLine() ?? string.Empty);
        
        return new PropertyData
        {
            Address = address,
            Description = description,
            PropertyType = propertyType,
            Size = size,
            ClientId = clientId
        };
    }
    private static PropertyType SelectPropertyType()
    {
        while (true)
        {
            Console.WriteLine("1. Apartamento");
            Console.WriteLine("2. Moradia");
            Console.WriteLine("3. Terreno");

            var choice = Console.ReadLine() ?? string.Empty;
            switch (choice)
            {
                case "1":
                    return PropertyType.Apartment;
                case "2":
                    return PropertyType.House;
                case "3":
                    return PropertyType.Land;
                default:
                    MessageHandler.PressAnyKey("Seleção Inválida. Escolhe entre 1 e 3.");
                    continue;
            }
        }
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
    /// <summary>
    /// Manages the submenu for managing clients.
    /// </summary>
    public void ManageClientOptionsView()
    {
        Menu.ManageClientsView();
    }

    public static int ChoosePropertyIdView(){
        Console.Clear();
        
        int id;
        Console.WriteLine("========== Escolha o ID da propriedade ==========");
        id = Convert.ToInt32(Console.ReadLine());
        return id;
    }

    public static decimal ChoosePropertyPriceView()
    {
        Console.Clear();
        decimal price;
        Console.WriteLine("========== Escolha o valor da proposta ==========");
        price = Convert.ToDecimal(Console.ReadLine());
        return price;
    }

    public static int ChooseClientIdView()
    {
        Console.Clear();
        int id;
        Console.WriteLine("========== Escolha o ID do cliente ==========");
        id = Convert.ToInt32(Console.ReadLine());
        return id;
    }

}

public class UserData
{
    public string Name { get; set; }
    public string Userame { get; set; }

    public string Password { get; set; }
    public UserRole Role { get; set; }
}

public class PropertyData
{
    public string Address { get; set; }
    public string Description { get; set; }
    public PropertyType PropertyType { get; set; }
    public double Size { get; set; }
    public int ClientId { get; set; }
}