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
        public static void Show(int userID){
            Console.Clear();

            Console.WriteLine("\t\tAdd Client ");
            Console.WriteLine("Name: ");
            string? name = Console.ReadLine();
            Console.WriteLine("Adress: ");
            string? adress = Console.ReadLine();

            Client? a = UserController.AddClient(name, adress, userID);
            if(a == null){
                Console.WriteLine("Error, client not added");
                return;
            }

            bool save = Data.SaveToJson(Client.ClientList);
            if(!save){
                Console.WriteLine("Error, client not save in jsonFiles");
            }
            Console.Clear();
        }
    }
}