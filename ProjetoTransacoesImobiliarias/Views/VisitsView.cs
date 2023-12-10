using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTransacoesImobiliarias.Views
{
    public class VisitsView
    {
        public DateTime ChooseDateView(){
            Console.Clear();
            Console.WriteLine("Inserir data:");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Data invalida. Tente novamente:");
            }

            return date;            
        }
    }
}