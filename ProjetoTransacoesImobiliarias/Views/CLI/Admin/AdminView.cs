using System;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Views.CLI;

public static class AdminView
{
    public static string? ShowAdminMenu(Admin admin)
    {
        Console.Clear();
        Console.WriteLine("========== Menu de Administração ==========");
        Console.WriteLine($"Bem-Vindo {admin.Username}");
        Console.WriteLine("1. Gerir Utilizadores");
        Console.WriteLine("2. Ver Relatórios");
        Console.WriteLine("3. Configurações do Sistema");
        Console.WriteLine("4. Atualizar Perfil");
        Console.WriteLine("0. Sair");
        return Console.ReadLine();
    }
    
    
    
// talvez colocar esta funcao numa classe de utilidades
    public static void WrongOption()
    {
        Console.WriteLine("Opção inválida.");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}