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
                
                foreach (var item in Enum.GetValues(typeof(UserRole)))
                {
                    Console.WriteLine($"{(int) item} - {item}");                    
                }


                int choice;
                if(int.TryParse(Console.ReadLine(), out choice)){
                    switch (choice){
                        case 0:
                            //admin
                            AdminController? admin1 = new AdminController(name, pass);
                            Console.Clear();
                            if(Data.SaveToJsonGeneric(admin1.Id, AdminController.AdminControllersList)) Console.WriteLine("Admin list saved");
                            return;
                        case 1:
                            //Manger
                            ManagerController? hugo = new (name, pass);
                            
                            Console.Clear();
                            if(Data.SaveToJsonGeneric(hugo.Id, ManagerController.ManagerControllerList)) Console.WriteLine("Manager list saved");

                            return;

                        case 2:
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