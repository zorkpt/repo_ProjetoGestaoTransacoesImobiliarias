using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Views;

public class ManagerView
{
    public static void StartView()
    {
        Console.WriteLine("View de Manager Iniciada");
    }

    public static void ListView<T>(List<T> l){
        foreach (var item in l)
        {
            if(typeof(T) == typeof(Client)){
                Client item1 = item as Client;
                var itemm = item1;
                Console.WriteLine($"{itemm.Name}");
            }
            
        }
    }
}