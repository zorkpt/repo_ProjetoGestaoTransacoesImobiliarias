using ProjetoTransacoesImobiliarias.Models;

public class Menu
{
    public static void AdminMenu(Admin admin)
    {
        Console.Clear();
        Console.WriteLine("========== Menu de Administração ==========");
        Console.WriteLine($"Bem-Vindo {admin.Username}");
        Console.WriteLine("1. Gerir Clientes");
        Console.WriteLine("2. Gerir Utilizadores");
        Console.WriteLine("3. Gerir Transação");
        Console.WriteLine("4. Gerir Propriedades");
        Console.WriteLine("0. Sair");
        Console.Write("Escolha uma opção: ");
    }


    public static void ManageUsers()
    {
        Console.Clear();
        Console.WriteLine("========== Gerir Utilizadores ==========");
        Console.WriteLine("1. Adicionar Utilizador");
        Console.WriteLine("2. Editar Utilizador");
        Console.WriteLine("3. Eliminar Utilizador");
        Console.WriteLine("4. Listar Utilizadores");
        Console.WriteLine("0. Voltar ao Menu Principal");
        Console.Write("Escolha uma opção: ");
    }

    public static void ManageProperties()
    {
        Console.Clear();
        Console.WriteLine("========== Gerir Propriedades ==========");
        Console.WriteLine("1. Adicionar Propriedade");
        Console.WriteLine("2. Editar Propriedade");
        Console.WriteLine("3. Eliminar Propriedade");
        Console.WriteLine("4. Ver Todas Propriedades");
        Console.WriteLine("0. Voltar ao Menu Principal");
        Console.Write("Escolha uma opção: ");
    }

    public static void ManageClients()
    {
        Console.Clear();
        Console.WriteLine("========== Gerir Clientes ==========");
        Console.WriteLine("1. Adicionar Cliente");
        Console.WriteLine("2. Editar Cliente");
        Console.WriteLine("3. Eliminar Cliente");
        Console.WriteLine("4. Ver meus Cliente");
        Console.WriteLine("5. Ver todos Clientes");
        Console.WriteLine("6. Gerir cliente"); //novo
        Console.WriteLine("0. Voltar ao Menu Principal");
        Console.Write("Escolha uma opção: ");
    }

    public static void ManageTransactions()
    {
        Console.Clear();
        Console.WriteLine("========== Gerir Transações ==========");
        Console.WriteLine("1. Nova Visita");
        Console.WriteLine("2. Nova Transação");
        Console.WriteLine("3. Editar Transação");
        Console.WriteLine("0. Voltar ao Menu Principal");
        Console.Write("Escolha uma opção: ");
    }


    /// <summary>
    /// Everything, but the ability to manage users.
    /// </summary>
    /// <param name="agent"></param>
    public static void AgentMenu(Agent agent)
    {
        Console.Clear();
        Console.WriteLine("========== Agent menu ==========");
        Console.WriteLine($"Bem-Vindo {agent.Username}");
        Console.WriteLine("1. Gerir Clientes");
    }

    #region Manager menu

    public static void ManagerMenu(Manager manager)
    {
        Console.Clear();
        Console.WriteLine("========== Manager Menu ==========");
        Console.WriteLine($"Bem-Vindo {manager.Username}");
        Console.WriteLine("1. Gerir Clientes");
        //Console.WriteLine("2. Gerir Utilizadores");
        Console.WriteLine("2. Gerir Transação");
        Console.WriteLine("3. Gerir Propriedades");
        Console.WriteLine("0. Sair");
        Console.Write("Escolha uma opção: ");
    }

    /// <summary>
    /// Everything related to managing clients, but with out the ability to see ALL clients.
    /// </summary>
    public static void ManageClientsAgentView()
    {
        Console.Clear();
        Console.WriteLine("========== Gerir Clientes ==========");
        Console.WriteLine("1. Adicionar Cliente");
        Console.WriteLine("2. Editar Cliente");
        Console.WriteLine("3. Eliminar Cliente");
        Console.WriteLine("4. Ver meus Cliente");
        //Console.WriteLine("5. Ver todos Clientes");
        Console.WriteLine("0. Voltar ao Menu Principal");
        Console.Write("Escolha uma opção: ");
    }

    #endregion

    #region Proposal menu
    public static void ProposalMenu()
    {
        Console.Clear();
        Console.WriteLine("========== Proposta ==========");
        Console.WriteLine("1. Fazer Proposta");
        Console.WriteLine("2. Responder Proposta");
        Console.WriteLine("3. Ver Todas Propostas");
        Console.WriteLine("4. Gerir Propriedades");
        Console.WriteLine("0. Sair");
        Console.Write("Escolha uma opção: ");
    }

    public static void MensagemSucesso(){
        Console.Clear();
        Console.WriteLine("========== Feito com sucesso ==========");
    }

    public static void ErrorMessage(){
        Console.Clear();
        Console.WriteLine("========== Algo de errado não está certo ==========");
    }



    

    #endregion

    #region Managing clients menu

    public static void ManageClientsView(string nomeCLiente)
    {

        //Console.Clear();
        Console.WriteLine("========== ========== ========== ==========");
        Console.WriteLine("Cliente " + nomeCLiente);
        Console.WriteLine("1 Fazer proposta");
        Console.WriteLine("2 Aprovar proposta");
        Console.WriteLine("3 Rejeitar proposta");
        Console.WriteLine("4 Listar propostas");
        Console.WriteLine("5 Marcar visita");
        Console.WriteLine("0 Sair");
        Console.Write("Escolha uma opção: ");
        
    }
    #endregion
}