
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Views.CLI;

public class EvaluatorView
{
    public static string? ShowEvaluatorMenu(Evaluator evaluator)
    {
        Menu.EvaluatorMenu(evaluator);
        return Console.ReadLine();
    }
    
    public static string? ManageTransactionsMenu()
    {
        Menu.ManageTransactions();
        return Console.ReadLine();
    }
    
    public static string? ManagePropertiesMenu()
    {
        Menu.ManageProperties();
        return Console.ReadLine();
    }
}