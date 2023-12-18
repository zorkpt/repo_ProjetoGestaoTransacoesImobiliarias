using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Controllers
{

    public class PaymentController
    {
        private PaymentView? paymentView{ get; set; }
        
        /// <summary>
        /// Initializes a new instance of the PaymentController class.
        /// </summary>
        public PaymentController()
        {
            paymentView = new PaymentView();//vamos ver se é preciso...
        } 

        /// <summary>
        /// Makes a payment.
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool MakePayment(Transactions transaction)
        {
            if(transaction == null) return false;
            Payment payDay = new Payment(transaction);
            if(payDay == null) return false;
            return true;
        }

    }


}