using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ProjetoTransacoesImobiliarias.Views.CLI.Transactions
{
    public class TransactionsView
    {
        public TransactionsView()
        {
            
        }

        public void TransactionsViewSucessMessage()
        {
            Console.WriteLine("Transação adicionada com sucesso");
        }

        public void TransactionsViewErrorMessage()
        {
            Console.WriteLine("Algo de errado não está certo");
        }

        public void TransactionsViewShowReference(int reference)
        {
            Console.WriteLine($"Referencia para pagamento: {reference}");
        }

        public int? ChooseTransactionView()
        {
            Console.WriteLine("========== Escolha uma transação ==========");
            //aceitar quando for um numero 
            bool valido = false;
            while (!valido)
            {
                Console.Write("Escolha uma opção: ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Opcão inválida. Tente novamente.");
                }
            }
            return -1;
        }

    }
}