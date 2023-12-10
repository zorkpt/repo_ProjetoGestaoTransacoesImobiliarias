using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ProjetoTransacoesImobiliarias.Models
{
    internal class Transactions//Transaction is a reserved name 
    {
        private static int IdCounter = 0;
        public int? TransactionId { get; set; }
        public int ProposalId { get; set; }
        public Proposal proposal { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime RejectionDate { get; set; }

        public int PaymentRef { get; set; }
        public enum TransactionState{// Mudar para novo ficheiro? Vale a pena?
            Rejected,
            WaitingPayment,
            Paid
        }
        public TransactionState State { get{ return State;}
            set{
                if(value == TransactionState.Rejected)
                {
                    RejectionDate = DateTime.Now;
                }
                if(value == TransactionState.Paid)
                {
                    PaidDate = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Teste para tabela hash
        /// </summary>
        public static Hashtable TransactionsMap = new Hashtable(); // Neste caso não é a melhor opcao. 
        //Se quisermos saber se uma propriendade tem ou nao transicao, temos de correr fazer foreach.
        public static List<Transactions> TransactionList = new List<Transactions>();
        public Transactions(Proposal proposal)
        {
            TransactionId = IdCounter++;
            this.proposal = proposal;
            State = TransactionState.WaitingPayment;
            CreateDate = DateTime.Now;
            PaymentRef = RandomNumberGenerator.GetInt32(0, 999999);// mais vale nao usar ;)
            TransactionsMap.Add(TransactionId, this); // Ver com pessoal se vale a pena...
            TransactionList.Add(this);
        }

    }
}