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
        
        public PaymentController()
        {
            paymentView = new PaymentView();//vamos ver se é preciso...
        } 

        public bool MakePayment(Transactions transaction)
        {
            if(transaction == null) return false;
            Payment payDay = new Payment(transaction);
            if(payDay == null) return false;
            return true;
        }

    }


}