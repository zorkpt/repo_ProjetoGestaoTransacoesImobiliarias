using System.Text.Json;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Services;

public class UserService
{
    private const string LastIdFilePath = "lastId.txt";
    private static int _counter = 0; 
    private readonly List<UserTest> _users = new();
    private static readonly string FilePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Files", "Data.json");

    public IEnumerable<UserTest> GetAllUsers() => _users.AsReadOnly();
    

    public bool LoadUsersFromJson()
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
                var userType = element.GetProperty("userType").GetString();
                switch (userType)
                {
                    // usa userrole
                    case "Admin":
                        _users.Add(JsonSerializer.Deserialize<AdminTest>(element.GetRawText(), options));
                        break;
                    //     case "Manager":
                    //         _users.Add(JsonSerializer.Deserialize<ManagerTest>(element.GetRawText(), options));
                    //       break;
                    // ... cases for other user types
                    default:
                        Console.WriteLine($"tipo de user errado: {userType}");
                        break;
                }
            }
            
            // Updates _counter to the last id in the json
            if (_users.Any())
            {
                _counter = _users.Max(u => u.Id) + 1;
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
    
    
    public UserTest CreateUser(string username, string password, UserRole role)
    {
        int newId = _counter++;

        switch (role)
        {
            case UserRole.Admin:
                var adminUser = new AdminTest(username, password) { Id = newId };
                _users.Add(adminUser);
                return adminUser;
            case UserRole.Manager:
                /*var managerUser = new ManagerTest(username, password) { Id = newId };
                _users.Add(managerUser);
                return managerUser;*/
            case UserRole.Agent:
                break;
            case UserRole.Avaliator:
                break;
            default:
                throw new ArgumentException("Role inválido");
        }
        throw new InvalidOperationException("O user não foi criado devido a um role inválido.");
    }
    
    
}