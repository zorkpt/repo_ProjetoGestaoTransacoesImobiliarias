using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Services
{
    public class PropertyService : IPropertyService
    {
        private static int _counter = 0;
        private readonly IUserService _userService;
        private readonly IClientService _clientService;

        List<Property> _propertiesList = new();

        public PropertyService(IUserService userService, IClientService clientService)
        {
            _clientService = clientService;
            _userService = userService;
        }

        public IEnumerable<Property> GetAllProperties() => _propertiesList.AsReadOnly();

        public Property CreateProperty(string address, string description,
                                 PropertyType propertyType, double size, 
                                 User addedBy, Client owner)
        {
            var newId = _counter++;
            var newProperty = new Property(address, description, propertyType, size, addedBy.Id, owner.Id);
            _propertiesList.Add(newProperty);
            return newProperty;
        }
    }
}