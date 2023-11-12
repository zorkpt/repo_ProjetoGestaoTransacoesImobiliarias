using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Views.CLI;

public class AgentView
{
    public static void ShowAgentMenu(Agent agent)
    {
        Console.WriteLine("Menu de Gestão");
        Console.WriteLine($"Bem-Vindo {agent.Username} com id {agent.Id}");
    }
}