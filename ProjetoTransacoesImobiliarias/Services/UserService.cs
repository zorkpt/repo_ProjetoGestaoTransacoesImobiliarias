using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Services;

public class UserService : IUserService
{
    private static int _counter = 0;
    private readonly List<User> _users = new();

    private static readonly string FilePath =
        Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Files", "Data.json");

    public IEnumerable<User> GetAllUsers() => _users.AsReadOnly();


    public bool LoadUsersFromJson()
    {
        try
        {
            var json = File.ReadAllText(FilePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var dataFailedCounter = 0;
            
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
                    case nameof(UserRole.Admin):
                        _users.Add(JsonSerializer.Deserialize<Admin>(element.GetRawText(), options));
                        break;
                    case nameof(UserRole.Manager):
                        _users.Add(JsonSerializer.Deserialize<Manager>(element.GetRawText(), options));
                        break;
                    case nameof(UserRole.Agent):
                        _users.Add(JsonSerializer.Deserialize<Manager>(element.GetRawText(), options));
                        break;
                    case nameof(UserRole.Evaluator):
                        _users.Add(JsonSerializer.Deserialize<Manager>(element.GetRawText(), options));
                        break;

                    default:
                        dataFailedCounter++;
                        break;
                }
            }

            // Updates _counter to the last id in the json
            if (_users.Any())
            {
                _counter = _users.Max(u => u.Id) + 1;
            }

            if (dataFailedCounter > 0)
            {
                Console.WriteLine($"Falhou o carregamente de {dataFailedCounter} registos.");
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


    public User CreateUser(string username, string password, UserRole role)
    {
        int newId = _counter++;

        switch (role)
        {
            case UserRole.Admin:
                var adminUser = new Admin(username, password) { Id = newId };
                _users.Add(adminUser);
                return adminUser;
            case UserRole.Manager:
                var managerUser = new Manager(username, password) { Id = newId };
                _users.Add(managerUser);
                return managerUser;
            case UserRole.Agent:
                var agentUser = new Agent(username, password) { Id = newId };
                _users.Add(agentUser);
                return agentUser;
            case UserRole.Evaluator:
                var evaluatorUser = new Evaluator(username, password) { Id = newId };
                _users.Add(evaluatorUser);
                break;
            default:
                throw new ArgumentException("Role inválido");
        }

        throw new InvalidOperationException("O user não foi criado devido a um role inválido.");
    }
}