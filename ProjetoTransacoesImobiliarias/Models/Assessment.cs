using Microsoft.VisualBasic;

namespace ProjetoTransacoesImobiliarias;

public class Assessment
{
    protected int IdEvaluator { get; set; }
    protected int IdProperty { get; set; }
    protected DateAndTime? AssessmentDate { get; set; }
    protected decimal AssessmentValue { get; set; }
    protected bool Active;

    protected static List<Assessment> AssessmentList = new List<Assessment>();
}
