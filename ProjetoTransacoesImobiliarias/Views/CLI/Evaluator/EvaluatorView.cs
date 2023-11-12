
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Views.CLI;

public class EvaluatorView
{
    public static void ShowEvaluatorMenu(Evaluator evaluator)
    {
        Console.WriteLine("Menu de Gestão");
        Console.WriteLine($"Bem-Vindo {evaluator.Username} com id {evaluator.Id}");
    }
}