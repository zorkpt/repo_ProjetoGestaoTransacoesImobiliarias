using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
                Console.WriteLine("Escolhe o tipo de utilizador:");
                Console.WriteLine("Insert User ID number");


                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    //recebe o num e verifica se user existe.
                    // primeiro tem de fazer loadUsers, claro. Pode ser nesta pagina.
                    //
                    User log = User.UserList.FirstOrDefault(u => u.Id == choice);

                    if(log != null){// Está assim apenas para nao dar erro.
                        //User existe.
                        if(log.Role == UserRole.Manager){
                            Manager manager = Manager.ManagerList.FirstOrDefault(m => m.Id == choice);
                            ManagerController man = new ManagerController(manager);
                            ManagerView.StartManagerView(log.Id);
                            return;
                        }
                        if(log.Role == UserRole.Agent){
                            //AgentController man = new AgentController(agent);
                        }
                        
                        Console.WriteLine($"Benvindo {log.Username}!");

                        
                        return;
                    }else
                    {
                        //User nao existe.
                        Console.Clear();
                        Console.WriteLine($"User {choice} doenst exists.");
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