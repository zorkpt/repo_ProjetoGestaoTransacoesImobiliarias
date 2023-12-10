using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTransacoesImobiliarias.Views.CLI.Proposal
{
    public class ProposalView
    {
        public string? ShowProposalMenu()
        {
            // vale a pensa utilizar isto, não é complicar?
            Menu.ProposalMenu();
            return Console.ReadLine();
        }

        public int ProposalViewIdProperty()
        {
            int id;
            Console.Clear();
            Console.WriteLine("Id da propriedade");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }

        public int ProposalViewIdClient()
        {   
                int id;
                Console.Clear();
                Console.WriteLine("Id do cliente");
                id = Convert.ToInt32(Console.ReadLine());
                return id;
        }

        public decimal ProposalViewProposalValue()
        {
            decimal value;
            Console.Clear();
            Console.WriteLine("Valor");
            value = Convert.ToDecimal(Console.ReadLine());
            return value;
        }

        public void Print <T>(List<T> list)
        {
                foreach (var item in list)
                {
                    Console.Write(item);
                    Console.Write(item);
                }
            
        }

        public void ChooseProposalView()
        {
            Console.Clear();
            Console.WriteLine("========== Escolha o Id da proposta ==========");
        }


    }
}