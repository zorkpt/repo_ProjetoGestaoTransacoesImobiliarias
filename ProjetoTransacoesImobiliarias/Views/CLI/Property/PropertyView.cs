using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Views.CLI;

public static class PropertyView
{

    public static void DisplayAllProperties(IEnumerable<Property> properties)
    {
        Console.Clear();
        Console.WriteLine("Lista de Todas as Propriedades:");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("| ID  | Tipo       | Descrição        | Área | Morada                | Agente    | Vendedor ");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        foreach (var property in properties)
        {
            var seller = property.Client?.Name ?? "N/A";
            var agent = property.AddedBy?.Username ?? "N/A";
            var description = property.Description.Length > 15 ? property.Description.Substring(0, 13) + "..." : property.Description;

            Console.WriteLine($"| {property.Id,-4} | {property.PropertyType,-10} | {description,-17} | {property.SquareMeters,-4} | {property.Address,-22} | {agent,-9} | {seller,-8} |");
        }

        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        MessageHandler.PressAnyKey();
    }

    public static int ChooseProperty(){
            Console.Clear();
            Console.WriteLine("Inserir Id da propriedade:");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Id invalida. Tente novamente:");
            }
            return id;                    
    }


}