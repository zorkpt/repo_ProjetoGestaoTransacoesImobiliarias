using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTransacoesImobiliarias.Controllers
{
    public class AvaliatorController : Evaluator
    {

        private List<AvaliatorController> AvaliatorControllerList = new List<AvaliatorController>();
        
        public AvaliatorController(string name, string address, int userID)
                : base(name)
        {


            this.AvaliatorControllerList.Add(this);
        }

        #region Propirties
        public int ShowIdEvaluator() => GetIdEvaluatorEvaluator();

        public string ShowNameEvaluator() => GetNameEvaluator();
        public bool ChangeNameEvaluator(string name) => SetNameEvaluator(name);        

        public bool ChangeIdEvaluator(int id) => SetIdEvaluatorEvaluator();
        #endregion
    }
}