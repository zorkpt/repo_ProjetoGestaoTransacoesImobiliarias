using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias;

internal class Program
{
    private static void Main(string[] args)
    {

        Console.Clear();
        while(true){
            Console.WriteLine("Choose one option:");
            Console.WriteLine("1. CLI");
            Console.WriteLine("2. WinForms");
            Console.WriteLine("0. Sair");

            int choice;
            if(int.TryParse(Console.ReadLine(), out choice)){
                switch(choice){
                    case 1:
                        CliMainView.Show();
                        return;
                    case 2: 

                        break;
                    case 0:
                        return;
                }
            }else
            {
                Console.WriteLine("Entrada inválida. Por favor, insere um número.");
            }
        }

        
    }
    
}