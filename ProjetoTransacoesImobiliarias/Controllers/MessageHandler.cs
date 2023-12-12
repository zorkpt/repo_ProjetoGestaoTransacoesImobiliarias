namespace ProjetoTransacoesImobiliarias.Views.CLI;

public static class MessageHandler
{
    public static void WrongOption()
    {
        Console.WriteLine("Opção inválida.");
        PressAnyKey();
    }

    public static void PressAnyKey(string message = "")
    {
        Console.WriteLine(message);
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey(); // Comentei apenas para fazer debug, não estaá a dar no VSCode
    }
}