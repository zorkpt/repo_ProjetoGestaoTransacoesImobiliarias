namespace ProjetoTransacoesImobiliarias.Views.CLI;

public static class ErrorHandler
{
    public static void WrongOption()
    {
        Console.WriteLine("Opção inválida.");
        PressAnyKey();
    }

    public static void PressAnyKey()
    {
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}