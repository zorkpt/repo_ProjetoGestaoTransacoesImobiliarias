using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;

namespace ProjetoTransacoesImobiliarias.Views.CLI
{
    public class CliClientPrint
    {
        public static void PrintClientDetailsById(){
            Console.Clear();
            Console.WriteLine("\t\tClient details view");
            Console.WriteLine("Client ID:");
            while(true){
                if(!int.TryParse(Console.ReadLine(), out int id)){
                    Console.WriteLine("Id does not exist");
                }else{
                    GenericController.PrintCientDetails(id);
                    return;
                }
            }

        }
    }
}