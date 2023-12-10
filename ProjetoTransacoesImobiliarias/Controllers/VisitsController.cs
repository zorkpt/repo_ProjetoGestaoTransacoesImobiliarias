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

        public bool MakeVisit(Property property, Client client, DateTime date)
        {
            if (property == null || client == null) return false;

            var visit = new Visits(client, property, date);
            return true;
        }

        public DateTime ChooseDate(){
            
            return visitsView.ChooseDateView();
            
        }
    }
}