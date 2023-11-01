using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI.Client;

namespace ProjetoTransacoesImobiliarias.Views.CLI
{
    public class CliClientOptions
    {
        public static void Show(int userID){
            Console.Clear();
            Console.WriteLine($"\t\tCliente Options (Log with: {userID})");
            while (true){
                Console.WriteLine("1. Add Client");
                Console.WriteLine("2. Edit Client");
                Console.WriteLine("3. Delete Client");
                Console.WriteLine("4. Details of Client");
                Console.WriteLine("5. List of Clients");
                Console.WriteLine("0. Sair");



            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine(choice);
                switch (choice)
                {
                    case 1:
                        CliClientAdd.Show(userID);
                        break;
                    case 2:
                        //Edit
                        CliClientEdit.Show();
                        
                        break;
                    case 3:
                        //delete
                        CliClientDelete.Show();
                        break;
                    case 4:

                        CliClientPrint.PrintClientDetailsById();
                        break;
                        //Details
                    case 5:
                        Console.Clear();
                        GenericController.ListView(ClientController.ClientControllerList);
                        break;
                    case 0:
                        //exit
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tenta novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, insere um número.");
            }
            }
        }
    }
}