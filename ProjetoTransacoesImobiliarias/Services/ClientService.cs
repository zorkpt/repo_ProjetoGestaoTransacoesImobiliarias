using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using System.Text.Json;
using ProjetoTransacoesImobiliarias.Views.CLI;
using ProjetoTransacoesImobiliarias.Views.CLI.Client;

namespace ProjetoTransacoesImobiliarias.Services;

public class ClientService : IClientService
{
    private static int _counter = 0;
    private readonly IUserService _userService;

    /// <summary>
    /// Initializes a new instance of the ClientService class.
    /// </summary>
    /// <param name="userService"></param>
    public ClientService(IUserService userService){
        _userService = userService;
    }

    private readonly List<Client> _clients = new();

    private static readonly string FilePath =
        Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Files", "Clients.json");

    public IEnumerable<Client> GetAllClients() => _clients.AsReadOnly();


    /// <summary>
    /// Loads clients from a JSON file.
    /// </summary>
    /// <returns>Returns true if the clients are successfully loaded, false otherwise.</returns>
    public bool LoadClientsFromJson()
    {
        try
        {
            var json = File.ReadAllText(FilePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            using var doc = JsonDocument.Parse(json);

            if (doc.RootElement.ValueKind != JsonValueKind.Array)
            {
                Console.WriteLine("Formato do JSON Inválido.");
                return false;
            }

            foreach (var element in doc.RootElement.EnumerateArray())
            {
                var client = JsonSerializer.Deserialize<Client>(element.GetRawText(), options);
                if (client == null) continue;
                var addedByUser = _userService.GetUserById(client.AddedById);
                client.SetAddedBy(addedByUser);
                _clients.Add(client);
            }

            if (_clients.Any())
            {
                _counter = _clients.Max(u => u.Id) + 1;
            }

            return true;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("O arquivo JSON não foi encontrado.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro Inesperado: {ex.Message}");
        }

        return false;
    }

    /// <summary>
    /// Saves clients to a JSON file.
    /// </summary>
    /// <returns>Returns true if the clients are successfully saved, false otherwise.</returns>
    public bool SaveClientsToJson(){

    //var simplifiedClientList = _clients.Select(c => new { c.Name, c.Email }).ToList();

        var clientList = _clients.Select(client => new {
            client.Id,
            client.Name,
            client.Address,
            client.PhoneNumber,
            client.AddedById
        }).ToList();

        var json = JsonSerializer.Serialize(clientList);
        
        Console.WriteLine($"File Path: {FilePath}");
        try{
            File.WriteAllText(FilePath, json);
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Erro Inesperado: {ex.Message}");
        }

        return true;
    }

    // GetClientById
    public Client GetClientById(int id) => _clients.FirstOrDefault(c => c.Id == id);
    
    /// <summary>
    /// Delete client from the client list
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    public bool DeleteClient(Client client)
    {
        if(_clients.Remove(client))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Creates a new client with the given name, address, phone number, and added by user.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="address"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="addedBy"></param>
    /// <returns>Returns the newly created client.</returns>
    public Client CreateClient(string name, string address, string phoneNumber, User addedBy) 
    { 
        var newId = _counter++;
        var newClient = new Client(name, address, name, addedBy, addedBy.Id) { Id = newId };
        _clients.Add(newClient);
        return newClient;
    }
   
    public Client AddClient(ClientView.ClientData clientData, User user)
    {
        var newClient = CreateClient(clientData.Name, clientData.Address, clientData.PhoneNumber, user);

        if (newClient is null)
        {
            return null;
        }

        user.AddClient(newClient);
        MessageHandler.PressAnyKey("Cliente Inserido com sucesso!");
        return newClient;
    }
    
   public Client UpdateClient(Client client)
    {
        var clientToUpdate = GetClientById(client.Id);
        if (clientToUpdate == null)
        {
            return null;
        }

        clientToUpdate.Name = client.Name;
        clientToUpdate.Address = client.Address;
        clientToUpdate.PhoneNumber = client.PhoneNumber;
        MessageHandler.PressAnyKey("Cliente editado com sucesso!");

        return clientToUpdate;
    }




    
}