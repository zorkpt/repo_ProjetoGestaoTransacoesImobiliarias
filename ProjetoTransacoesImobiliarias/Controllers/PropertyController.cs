using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Controllers
{
    public class PropertyController
    {
        public Property AddProperty(Property property)
        {
            return property;
        }

        public Property? ChooseProperty()
        {
            int propertyId = PropertyView.ChooseProperty();
            Property? property = Property.PropertyList.Find(x => x.Id == propertyId);
            if (property == null) return null;
            return property;
        }
    }
}