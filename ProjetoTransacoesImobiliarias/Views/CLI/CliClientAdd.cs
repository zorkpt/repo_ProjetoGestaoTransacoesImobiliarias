using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Views.CLI
{
    public class CliClientAdd
    {
        public static void Show(ManagerController man){
            Console.Clear();
            Console.WriteLine("\t\tAdd Client");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Adress: ");
            string adress = Console.ReadLine();
            man.AddClient(name, adress);
        }
    }
}