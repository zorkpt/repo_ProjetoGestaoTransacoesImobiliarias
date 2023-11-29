using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Services
{
    public class PropertyService : IPropertyService
    {
        private static int _counter;
        private readonly IUserService _userService;
        private readonly IClientService _clientService;

        readonly List<Property> _propertiesList = new();

        /// <summary>
        /// Initializes a new instance of the PropertyService class.
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="clientService"></param>
        public PropertyService(IUserService userService, IClientService clientService)
        {
            _clientService = clientService;
            _userService = userService;
        }

        private static readonly string FilePath =
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Files", "Properties.json");


        public bool LoadPropertiesFromJson()
        {
            try
            {
                var json = File.ReadAllText(FilePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                };
    
                using var doc = JsonDocument.Parse(json);

                if (doc.RootElement.ValueKind != JsonValueKind.Array)
                {
                    Console.WriteLine("Formato do JSON Inválido.");
                    return false;
                }

                foreach (var element in doc.RootElement.EnumerateArray())
                {
                    var property = JsonSerializer.Deserialize<Property>(element.GetRawText(), options);
                    if (property == null) continue;
            
                    var addedByUser = _userService.GetUserById(property.AddedById);
                    var addedByClient = _clientService.GetClientById(property.ClientId);
                    
                    property.SetAddedBy(addedByUser);
                    property.SetClient(addedByClient);
                    _propertiesList.Add(property);
                }

                if (_propertiesList.Any())
                {
                    _counter = _propertiesList.Max(u => u.Id) + 1;
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
        
        public IEnumerable<Property> GetAllProperties() => _propertiesList.AsReadOnly();

        /// <summary>
        /// Creates a new Property object with the given address, description, property type, size, added by user, and owner client.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="description"></param>
        /// <param name="propertyType"></param>
        /// <param name="size"></param>
        /// <param name="addedBy"></param>
        /// <param name="owner"></param>
        /// <returns>The newly created Property object.</returns>
        public Property CreateProperty(string address, string description, PropertyType propertyType, double size, int addedById, User addedBy, int clientId, Client client)
        { 
            var newId = _counter++;
            var newProperty = new Property(address, description, propertyType, size, addedById, addedBy, clientId, client) { Id = newId };
            _propertiesList.Add(newProperty);
            return newProperty;
        }
    }
}