using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Views;

public class ManagerView
{

    public static void StartManagerView(int userID) //podemos passar os dados do user aqui ? 
    {
        Console.Clear();
        Console.WriteLine($"\t\tManager (number {userID}) view:");
        while (true)  
                {
                    
                    Console.WriteLine("Options:");
                    Console.WriteLine("1. Client");
                    Console.WriteLine("2. Property");

                    Console.WriteLine("3. Manager");
                    // ... outras opções
                    Console.WriteLine("0. Exit");

                    int choice;
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine(choice);
                        switch (choice)
                        {
                            case 1:
                                //Client

                                CliClientOptions.Show(userID);
                                break;
                            case 2:
                                //
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