using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTransacoesImobiliarias.Views.CLI
{
    public class CliMainView
    {
        public static void Show(){
            Console.Clear();
            Console.WriteLine("\t\tMain View");
            while (true){
                Console.WriteLine("1. LogIn");
                Console.WriteLine("2. Register new user");
                // ... outras opções
                Console.WriteLine("0. Sair");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine(choice);
                switch (choice)
                {
                    case 1:
                        CliLogIn.Show();
                        return;
                        break;
                    case 2:
                        //Registar Novo user
                        CliNewUser.Show();
                        break;
                    
                    case 0:
                        Console.WriteLine("Adeus!");
                        return;  // Sai da aplicação
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