using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Controllers
{
    public class TransactionController
    {
        public TransactionController(){

        }

        public Transactions AddTransaction(Proposal proposal){
            if(proposal == null){
                return null;
            }
            Transactions a = new Transactions(proposal);
            return a;
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
            return true;
        }

    }
}