using System.Collections.Generic;

namespace ProjetoTransacoesImobiliarias;

public class Evaluator
{
    private static int Contador = 0;
    private int idEvaluator;
    private string? name;

    private List<Evaluator> EvaluatorList = new List<Evaluator>();


    protected Evaluator(string? name)
    {
        this.SetNameEvaluator(name);
        this.SetIdEvaluatorEvaluator();

        EvaluatorList.Add(this);

    }


    #region Propirties
        protected string? GetNameEvaluator()
        {
            return name;
        }

        protected bool SetNameEvaluator(string? value)
        {
            name = value;
            return true;
        }

        protected int GetIdEvaluatorEvaluator()
        {
            return idEvaluator;
        }

        protected bool SetIdEvaluatorEvaluator()
        {

            idEvaluator = Contador++;
            return true;
        }

    #endregion
}
