using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Views.CLI
{
    public class CliPropertyType
    {
        public static int Show()
        {
            Console.Clear();
            Console.WriteLine("\t\tProperty type");

            while (true)
            {
                Console.WriteLine("Choose a type");

                foreach (var item in Enum.GetValues(typeof(PropertyType)))
                {
                    Console.WriteLine($"{(int)item+1} - {item}");
                }
                int choice = Console.Read();

                if(choice > 0 && choice < Enum.GetValues(typeof(PropertyType)).Length){
                    return choice;
                }

            }
        }
    }
}