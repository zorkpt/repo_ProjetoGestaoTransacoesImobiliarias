using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Views.CLI
{
    public class CliPropertyType
    {
        public static PropertyType Show()
        {
            Console.Clear();
            Console.WriteLine("\t\tProperty type");

            while (true)
            {
                Console.WriteLine("Choose a type");

                foreach (var item in Enum.GetValues(typeof(PropertyType)))
                {
                    Console.WriteLine($"{(int)item} - {item}");
                }

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Choice: {Enum.GetValues(typeof(PropertyType)).Length}");
                while(true){
                    Console.WriteLine("Choose a type");
                    switch (choice)
                    {
                        case 0:
                            return PropertyType.Land;
                        case 1:
                            return PropertyType.Apartment;
                        case 2:
                            return PropertyType.House;
                    }
                }
            }
        }
    }
}