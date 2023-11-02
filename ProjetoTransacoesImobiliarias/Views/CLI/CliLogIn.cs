using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Views.CLI
{
    public class CliLogIn
    {
        public static void Show(){
            Console.Clear();
            Console.WriteLine("\t\tLogin");
            while (true)  
            {
                Console.WriteLine("Insert User ID number");


                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    
                    UserRole? log = UserController.Login(choice);
                    if(log == null){
                        Console.Clear();
                        Console.WriteLine($"User {choice} doenst exists.");
                        break;
                    }

                    if(log == UserRole.Manager){
                        ManagerView.StartManagerView(choice);
                        return;
                    }
                    if(log == UserRole.Agent){
                        CliAgentView.StartAgentView(choice);
                        return;
                    }
                    if(log == UserRole.Admin){
                        CliAdminView.StartAdminView(choice);
                        return;
                    }
                    if(log == UserRole.Avaliator){
                        CliAvaliatorView.StartAvaliatorView(choice);
                        return;
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