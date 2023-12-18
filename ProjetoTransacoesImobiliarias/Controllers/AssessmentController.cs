using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Controllers
{
    public class AssessmentController
    {

        /// <summary>
        /// Initializes a new instance of the AssessmentController class.
        /// </summary>
        public AssessmentController()
        {
            
        }

        #region Methods

        // Add new assessment to property
        public static void AddAssessmentToProperty(Evaluator evaluator, Property property, DateTime assessmentDate, decimal assessmentValue)
        {
            Assessment assessment = new Assessment(evaluator, property, assessmentDate, assessmentValue);
        }

        // Change assessment value
        public static void ChangeAssessmentValue(Assessment assessment, decimal newAssessmentValue)
        {
            assessment.assessmentValue = newAssessmentValue;
        }


        #endregion
    }
}