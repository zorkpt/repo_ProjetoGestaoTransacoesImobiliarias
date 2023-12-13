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
    public class TransactionController
    {
        private TransactionsView transactioView;
        public TransactionController()
        {
            transactioView = new TransactionsView();
            
        }

        public void AddTransaction(Proposal proposal){
            if(proposal == null)
            {
                return;
            }

            if(ExistsTransactionByProperty(proposal)){
                transactioView.TransactionsViewErrorMessage();
                return;
            };
            //adicionar condicao para comparar clientes, se o comprador e o vendedor for o mesmo cliente, acusamos à AT 
            Transactions a = new Transactions(proposal);
            transactioView.TransactionsViewSucessMessage();
            transactioView.TransactionsViewShowReference(a.PaymentRef);
        }
        
        /// <summary>
        /// Checks if a transaction already exists.
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        private bool ExistsTransactionByProperty(Proposal prop)
        {
            //if(prop == null) return false;
            //Verifica se a propriedade está ja tem transicao.
            bool exist = Transactions.TransactionList.Exists(x => x.proposal.Property.Id == prop.Property.Id);
            if (exist) return true;
            
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
        /// <summary>
        /// Chooses a transaction from the list.
        /// </summary>
        /// <returns></returns>
        public Transactions? ChooseTransaction()
        {
            int? id = transactioView.ChooseTransactionView();

            if(id == -1){
                return null;
            }else{
                Transactions? transaction = Transactions.TransactionList.Find(x => x.TransactionId == id);
                return transaction;
            }
        }

    }
}