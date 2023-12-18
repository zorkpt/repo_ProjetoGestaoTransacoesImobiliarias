namespace ProjetoTransacoesImobiliarias.Views.CLI;

public static class MessageHandler
{
    /// <summary>
    /// Shows a message when the user enters an invalid option.
    /// </summary>
    public static void WrongOption()
    {
        Console.WriteLine("Opção inválida.");
        PressAnyKey();
    }

    /// <summary>
    /// Shows a message when we want to clear console and press any key to continue.
    /// </summary>
    /// <param name="message"></param>
    public static void PressAnyKey(string message = "")
    {
        Console.WriteLine(message);
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey(); // Comentei apenas para fazer debug, não estaá a dar no VSCode
    }
}