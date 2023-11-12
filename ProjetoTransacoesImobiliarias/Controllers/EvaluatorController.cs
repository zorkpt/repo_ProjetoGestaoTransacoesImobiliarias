using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class EvaluatorController
{
    public static void Menu(Evaluator evaluator)
    {
        EvaluatorView.ShowEvaluatorMenu(evaluator);
    }
}