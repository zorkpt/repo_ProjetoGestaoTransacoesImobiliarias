namespace ProjetoTransacoesImobiliarias.Controllers;

public class AppController
{
    public static void Run()
    {
        while (true)  
        {
            Console.WriteLine("Escolhe o tipo de utilizador:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Manager");
            // ... outras opções
            Console.WriteLine("0. Sair");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine(choice);
                switch (choice)
                {
                    case 1:
                        //AdminController.StartView();
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