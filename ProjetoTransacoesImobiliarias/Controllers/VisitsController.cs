using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views;

namespace ProjetoTransacoesImobiliarias.Controllers
{
    public class VisitsController
    {
        public VisitsView visitsView { get; set; }
        public VisitsController()
        {
            visitsView = new VisitsView();
        }

        /// <summary>
        /// Makes a visit to a property.
        /// </summary>
        /// <param name="property"></param>
        /// <param name="client"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool MakeVisit(Property property, Client client, DateTime date)
        {
            if (property == null || client == null) return false;

            var visit = new Visits(client, property, date);
            return true;
        }

        /// <summary>
        /// Choose a date to make a visit.
        /// </summary>
        /// <returns></returns>
        public DateTime ChooseDate(){
            
            return visitsView.ChooseDateView();
            
        }
    }
}