using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Views.CLI
{
    public class CliNewUser
    {
        public static void Show(){
            Console.Clear();
            Console.WriteLine("\t\tRegister new user");

            Console.WriteLine("Insert User Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Insert password:");
            string pass = Console.ReadLine();
            
            while(true){
                Console.WriteLine("Choose User role");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Manager");
                Console.WriteLine("3. Agent");
                
                int choice;
                if(int.TryParse(Console.ReadLine(), out choice)){
                    switch (choice){
                        case 1:
                            //admin
                            
                            break;
                        case 2:
                            //Manger
                            Manager a = new Manager(name, pass);
                            return;
                            //ManagerController newManager = new ManagerController(a);

                            break;
                        case 3:
                            //Agent
                            break;
                    }
                }else{
                    //nada? ver melhor
                }
            }

        } 
    }
}