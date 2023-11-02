using Microsoft.VisualBasic;

namespace ProjetoTransacoesImobiliarias;

public class Assessment
{
    private int idEvaluator;
    private int idProperty;
    private DateAndTime? assessmentDate;
    private decimal assessmentValue;
    private static int contador = 0;
    protected bool Active;

    protected static List<Assessment> AssessmentList = new List<Assessment>();


    protected Assessment(int idProperty, DateAndTime? assessmentDate, decimal assessmentValue)
    {
        this.SetIdEvaluatorAssessment();
        this.SetIdPropertyAssessment(idProperty);
        this.SetAssessmentDateAssessment(assessmentDate);
        this.SetAssessmentValueAssessment(assessmentValue);

        AssessmentList.Add(this);
    }

    #region Propirties
    protected int GetIdEvaluatorAssessment()
    {
        return idEvaluator;
    }

    protected bool SetIdEvaluatorAssessment()
    {
        idEvaluator = contador++;
        return true;
    }

        protected int GetIdPropertyAssessment()
    {
        return idProperty;
    }

    protected bool SetIdPropertyAssessment(int value)
    {
        idProperty = value;
        return true;
    }

    protected DateAndTime? GetAssessmentDateAssessment()
    {
        return assessmentDate;
    }

    protected bool SetAssessmentDateAssessment(DateAndTime? value)
    {
        assessmentDate = value;
        return true;
    }
    protected decimal GetAssessmentValueAssessment()
    {
        return assessmentValue;
    }

    protected bool SetAssessmentValueAssessment(decimal value)
    {
        assessmentValue = value;
        return true;
    }

    #endregion
}
