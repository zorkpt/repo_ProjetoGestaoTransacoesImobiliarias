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
            string? name; string? pass;
            while(true){
                Console.WriteLine("Insert User Name:");
                name = Console.ReadLine();
                Console.WriteLine("Insert password:");
                pass = Console.ReadLine();
                if(!string.IsNullOrEmpty(name)) break;
                if(!string.IsNullOrEmpty(pass)) break;

            }
            while(true){
                Console.WriteLine("Choose User role");
                // Console.WriteLine("1. Admin");
                // Console.WriteLine("2. Manager");
                // Console.WriteLine("3. Agent");
                
                foreach (var item in Enum.GetValues(typeof(UserRole)))
                {
                    Console.WriteLine($"{(int) item+1} - {item}");                    
                }


                int choice;
                if(int.TryParse(Console.ReadLine(), out choice)){
                    switch (choice){
                        case 1:
                            //admin
                            
                            break;
                        case 2:
                            //Manger
//                            Manager? a = new Manager(name, pass);
                            ManagerController hugo = new ManagerController(name, pass);
                            
                            Console.Clear();
//                            if(Data.SaveToJsonGeneric(hugo.Id, ManagerController.GetManagerList)) Console.WriteLine("Manager list saved");
                            if(Data.SaveToJsonGeneric(hugo.Id, ManagerController.ManagerControllerList)) Console.WriteLine("Manager list saved");

                            return;

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