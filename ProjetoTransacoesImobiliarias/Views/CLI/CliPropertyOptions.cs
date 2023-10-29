using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTransacoesImobiliarias.Views.CLI
{
    public class CliPropertyOptions
    {
        public static void Show(int userID)
        {
            Console.Clear();
            Console.WriteLine("\t\tProperty options");

            while(true)
            {
                Console.WriteLine("Property address");
                string? adress = Console.ReadLine();
                int type = CliPropertyType.Show();
                Console.WriteLine("Square meters");
                double.TryParse(Console.ReadLine(), out double squareMeters);
                Console.WriteLine("Wanted Value:");
                decimal.TryParse(Console.ReadLine(), out decimal wantedValue);
                Console.WriteLine("Client ID:");
                int.TryParse(Console.ReadLine(), out int clientID);
                //Fazer verificacao do ID do cliente com clientController
                
                //in the end send to avaliation list
            }
        }
    }
}