using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Views.CLI
{
    public class CliPropertyAdd
    {
        public static void Show(int userID)
        {
            Console.Clear();
            Console.WriteLine("\t\tAdd new property");

            while(true)
            {
                int clientID;
                Console.WriteLine("Property address");
                string? adress = Console.ReadLine();
                PropertyType type = CliPropertyType.Show();
                Console.WriteLine("Square meters");
                double.TryParse(Console.ReadLine(), out double squareMeters);// need validation
                Console.WriteLine("Wanted Value:");
                decimal.TryParse(Console.ReadLine(), out decimal wantedValue);// needs validation
                while(true){
                    Console.WriteLine("Client ID:");
                    int.TryParse(Console.ReadLine(), out clientID);
                    // if(ClientController.GetClientById(userID)) break;
                    Console.Clear();
                    Console.WriteLine($"Id does not exis, insert new client");
                    Console.WriteLine("Press any key to continue");
                    string? pause = Console.ReadLine();
                //    CliClientAdd.Show(userID);

                }

                PropertyController? a = new PropertyController(adress, type, 0, wantedValue, squareMeters, clientID, userID);
                if(a != null ){
                    Console.WriteLine("Property not created");
                    return;
                }else{
                    Data.SaveToJsonGeneric(userID, PropertyController.PropertyControllerList);

                }
                
                //Guardar lista no disco? vale a pena?
                //in the end send to avaliation list

                Console.WriteLine("Property created successfully");
                break;
            }
        }
    }
}