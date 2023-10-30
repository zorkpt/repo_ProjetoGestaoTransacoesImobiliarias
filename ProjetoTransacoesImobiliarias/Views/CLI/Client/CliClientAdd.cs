using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            if(string.IsNullOrEmpty(name)) return;
            if(string.IsNullOrEmpty(adress)) return;

            ClientController? a = ClientController.AddClient(name, adress, userID);
            if(a == null){
                Console.WriteLine("Error, client not added");
                return;
            }

            bool save = Data.SaveToJsonGeneric(userID, ClientController.ClientManagerList);
            if(!save){
                Console.WriteLine("Error, client not save in jsonFiles");
            }else{
                Console.Clear();
                Console.WriteLine("Client added successfully");
            }
            //Console.Clear();
        }
    }
}