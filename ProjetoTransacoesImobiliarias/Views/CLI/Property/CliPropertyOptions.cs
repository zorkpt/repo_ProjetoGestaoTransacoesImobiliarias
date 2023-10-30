using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Models;

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
                Console.WriteLine("1. Add Property");
                Console.WriteLine("2. Edit Property");
                Console.WriteLine("3. Delete Property");
                Console.WriteLine("4. Details of Property");
                Console.WriteLine("5. List of Properties");
                Console.WriteLine("0. Back");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                { 
                    case 1:
                        CliPropertyAdd.Show(userID);
                        break;
                    case 2:
                        //Edit
                        break;
                    case 3:
                        //delete
                        break;
                    case 4:
                        //Details
                        break;
                    case 5:
                        Console.Clear();
                        GenericController.ListView(PropertyController.PropertyControllerList);
                        break;
                    case 0:
                        //exit
                        
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;

                }
            }
        }
    }
}