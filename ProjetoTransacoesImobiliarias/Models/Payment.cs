using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTransacoesImobiliarias.Models
{
    public class Payment
    {
        #region Atributes
        private static int IdCounter = 0;
        public List<Payment?>? PaymentsList = new List<Payment?>();
        #endregion
        #region Properties
        public int? PaymentId { get; set; }
        public Transactions? Transaction { get; set; }
        DateTime PaymentDateTime { get; set; }
        public int? PaymentRef { get; set; }
        #endregion
        #region Constructor
        public Payment(Transactions transaction)
        {
            if(transaction == null) throw new ArgumentNullException(nameof(transaction));
            else{
                PaymentId = IdCounter++;
                Transaction = transaction;
                PaymentDateTime = DateTime.Now;
                PaymentRef = transaction.PaymentRef;
                PaymentsList.Add(this);
            }

        }
        #endregion
        #region Methods
        #endregion
    
    }
}