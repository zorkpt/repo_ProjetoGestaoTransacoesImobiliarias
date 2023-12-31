using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Interfaces
{
    public interface IPropertyService
    {
        IEnumerable<Property> GetAllProperties();
        Property GetPropertyById(int id);

        Property CreateProperty(string address, string description, PropertyType propertyType, double size,
             User addedBy,Client client);
        void DeleteProperty(Property property);
    }
}