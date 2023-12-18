using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Controllers
{
    public class PropertyController
    {
        /// <summary>
        /// Add a new property.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public Property AddProperty(Property property)
        {
            return property;
        }

        /// <summary>
        /// Find a property by id.
        /// </summary>
        /// <returns></returns>
        public Property? ChooseProperty()
        {
            int propertyId = PropertyView.ChooseProperty();
            Property? property = Property.PropertyList.Find(x => x.Id == propertyId);
            if (property == null) return null;
            return property;
        }
    }
}