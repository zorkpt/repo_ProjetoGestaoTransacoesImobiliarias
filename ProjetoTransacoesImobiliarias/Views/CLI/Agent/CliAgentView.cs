using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTransacoesImobiliarias.Views.CLI
{
    public class CliAgentView
    {
        public static void StartAgentView(int userID)
        {
            Console.Clear();
            Console.WriteLine($"\t\tAgent view: (Log with: {userID})");
            
        }
    }
}