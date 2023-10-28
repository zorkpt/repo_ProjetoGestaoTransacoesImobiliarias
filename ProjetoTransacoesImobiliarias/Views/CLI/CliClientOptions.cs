using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Models;

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

                // ... outras opções
                Console.WriteLine("0. Sair");
            User log = User.UserList.FirstOrDefault(u => u.Id == userID);

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine(choice);
                switch (choice)
                {
                    case 1:
                        //Add
                        if(log.Role == UserRole.Manager){
                            Manager manager = Manager.ManagerList.FirstOrDefault(m => m.Id == userID);
                            ManagerController man = new ManagerController(manager);
                            CliClientAdd.Show(man);
                            return;
                        }
                        if(log.Role == UserRole.Agent){
                            //Case, quem esteja a adicionar seja agent
                        }
                        if(log.Role == UserRole.Admin){

                        }
                        if(log.Role == UserRole.Avaliator){
                            Console.WriteLine("User without access");
                        }
                        break;
                    case 2:
                        //Edit
                        break;
                    case 3:
                        //delete
                        break;
                    case 4:

                        CliClientPrint.All();
                        break;
                        //Details
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