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

}

