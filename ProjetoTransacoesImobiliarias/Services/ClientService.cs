using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using System.Text.Json;

namespace ProjetoTransacoesImobiliarias.Services;

public class ClientService : IClientService
{
    private static int _counter = 0;
    private readonly IUserService _userService;

    public ClientService(IUserService userService){
        _userService = userService;
    }

    private readonly List<Client> _clients = new();

    private static readonly string FilePath =
        Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Files", "Clients.json");

    public IEnumerable<Client> GetAllClients() => _clients.AsReadOnly();


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
                if (client != null)
                {
                    var addedByUser = _userService.GetUserById(client.AddedById);
                    client.SetAddedBy(addedByUser);
                    _clients.Add(client);
                }
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

    public bool SaveClientsToJson(){

    //var simplifiedClientList = _clients.Select(c => new { c.Name, c.Email }).ToList();

        var clientList = _clients.Select(client => new {
            Id = client.Id,
            Name = client.Name,
            Address = client.Address,
            PhoneNumber = client.PhoneNumber,
            AddedById = client.AddedById
        }).ToList();

        string json = JsonSerializer.Serialize(clientList);

        string FileJson = "./Files/ClientJson.json";

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

    public Client CreateClient(string name, string address, string phoneNumber, User addedBy) 
    { 
        var newId = _counter++;
        var newClient = new Client(name, address, name, addedBy, addedBy.Id) { Id = newId };
        _clients.Add(newClient);
        return newClient;
    }
}