using System.Collections.Generic;
using Microsoft.VisualBasic;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias;

public class Assessment
{
    public Evaluator evaluator { get; set; }   
    public Property property { get; set; }
    public DateTime? assessmentDate { get; set;}
    public decimal assessmentValue { get; set; }

    private static int contador = 0;

    public int Id { get; set; }
    public bool Active { get; set; }

    public static List<Assessment> AssessmentList = new List<Assessment>();


    public Assessment(Evaluator evaluator, Property property, DateTime? assessmentDate, decimal assessmentValue)
    {
        this.evaluator = evaluator;
        this.property = property;
        this.assessmentDate = assessmentDate;
        this.assessmentValue = assessmentValue;
        this.Id = contador++;
        AssessmentList.Add(this);
    }

    


}
