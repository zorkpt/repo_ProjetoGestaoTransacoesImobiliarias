using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Transactions;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI.Transactions;

namespace ProjetoTransacoesImobiliarias.Controllers
{
    internal class TransactionController
    {
        private TransactionsView transactioView;
        public TransactionController()
        {
            transactioView = new TransactionsView();
        }

        public Transactions? AddTransaction(Proposal proposal){
            if(proposal == null){
                return null;
            }

            if(ExistsTransactionByProperty(proposal)) return null;//Propriedade existe, nao pode ter nova transacao
            Transactions a = new Transactions(proposal);
            transactioView.TransactionsViewSucessMessage();
            transactioView.TransactionsViewShowReference(a.PaymentRef);
            return a;
        }

        //TODO: Fazer quando fizer merge com proposal... 
        // Não vou fazer agora para não dar conflito
        private bool ExistsTransactionByProperty(Proposal proposal)
        {
            if(proposal == null) return false;
            //Algo do genero disto:
            //if(Transactions.TransactionsMap.ContainsKey(proposal.property.PropertyId)) return true;
            //Transactions? a = Transactions.TransactionList.Find(t => t.proposal.property.PropertyId == proposal.property.PropertyId);
            //if(a != null) return true;
            return false;
        }

        /// <summary>
        /// Removes a transaction from the list and hashtable.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if the transaction was successfully removed. False otherwise.</returns>
        public bool RemoveTransaction(Transactions item){
            if(item.TransactionId < 0) return false;
            if(item == null) return false;
            Transactions.TransactionList.Remove(item);//Remove from list
            Transactions.TransactionsMap.Remove(item.TransactionId);//Remove from hashtable
            transactioView.TransactionsViewSucessMessage();
            return true;
        }

    }
}