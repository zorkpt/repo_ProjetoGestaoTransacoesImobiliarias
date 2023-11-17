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