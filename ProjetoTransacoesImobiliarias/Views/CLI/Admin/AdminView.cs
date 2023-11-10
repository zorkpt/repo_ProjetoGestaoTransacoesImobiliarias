using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Views.CLI;

public static class AdminView
{
    public static void ShowAdminMenu(AdminTest admin)
    {
        Console.WriteLine("Menu de Admin");
        Console.WriteLine($"Bem-Vindo {admin.Username} com id {admin.Id}");
    }
}