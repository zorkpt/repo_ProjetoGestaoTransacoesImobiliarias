using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ProjetoTransacoesImobiliarias.Controllers
{
    public class AssessmentController : Assessment
    {

        public static List<AssessmentController> AssessmentControllerList = new List<AssessmentController>();

        public AssessmentController(int idProperty, DateAndTime assessmentDate, decimal assessmentValue)
            : base(idProperty, assessmentDate, assessmentValue)
        {
            // ChangeIdEvaluatorAssessment();
            // ChangePropertyIdAssessment(idProperty);
            // ChangeAssessmentDateAssessment(assessmentDate);
            // ChangeAssessmentValueAssessment(assessmentValue);

            AssessmentControllerList.Add(this);
        }

        

        #region Properties

        public int ShowIdEvaluatorAssessment() => GetIdEvaluatorAssessment();
        public int ShowIdPropertyAssessment() => GetIdPropertyAssessment();
        //public DateTime? ShowAssessmentDateAssessment() => GetAssessmentDateAssessment();
        
        public decimal ShowAssessmentValueAssessment() => GetAssessmentValueAssessment();


        public bool ChangeIdEvaluatorAssessment() => SetIdEvaluatorAssessment();
        public bool ChangePropertyIdAssessment(int value) => SetIdPropertyAssessment(value);
        public bool ChangeAssessmentDateAssessment(DateAndTime? value) => SetAssessmentDateAssessment(value);
        public bool ChangeAssessmentValueAssessment(decimal value) => SetAssessmentValueAssessment(value);

        #endregion
    }
}