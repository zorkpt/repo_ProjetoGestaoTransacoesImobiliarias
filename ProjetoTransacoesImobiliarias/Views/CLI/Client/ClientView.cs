namespace ProjetoTransacoesImobiliarias.Views.CLI.Client;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Services;

public class ClientView
{


    public static ClientData AddClient()
    {
        Console.WriteLine("Adicionar novo cliente:");
        Console.Write("Nome: ");
        var clientName = Console.ReadLine() ?? string.Empty;

        Console.Write("Endereço: ");
        var clientAddress = Console.ReadLine() ?? string.Empty;

        Console.Write("Número de telefone: ");
        var clientPhoneNumber = Console.ReadLine() ?? string.Empty;

        return new ClientData
        {
            Name = clientName,
            Address = clientAddress,
            PhoneNumber = clientPhoneNumber
        };
    }

    /// <summary>
    /// Delete client view 
    /// </summary>
    /// <returns></returns>
    public static string DeleteClientView()
    {
        Console.Clear();
        Console.WriteLine("Id do cliente a eliminar?");
        string num = Console.ReadLine() ?? string.Empty;
        return num;

    }
    
    public class ClientData
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}