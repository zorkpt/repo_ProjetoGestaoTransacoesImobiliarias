
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Views.CLI;

public class EvaluatorView
{
    public static string? ShowEvaluatorMenu(Evaluator evaluator)
    {
        Menu.EvaluatorMenu(evaluator);
        return Console.ReadLine();
    }

    /// <summary>
    /// O menu desta função pergunta qual é o ID da propriedade a avaliar.
    /// </summary>
    /// <param name="evaluator"></param>
    /// <returns></returns>
    public static int? EvaluateAddAssessmentPropertyView(Evaluator evaluator)
    {
        Menu.EvaluateAddAssessmentPropertyMenu(evaluator);
        if (int.TryParse(Console.ReadLine(), out int propertyId))
        {
            return propertyId;
        }
        else
        {
            return null;
        }
    }
}