using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Views.CLI;

public static class MenuView
{
    public static void ShowUserMenu(UserTest user)
    {
        switch (user)
        {
            case AdminTest admin:
                AdminView.ShowAdminMenu(admin); // Delega para uma classe de view de admin
                break;
            // Casos para outros tipos de usuários...
            
            default:
                Console.WriteLine("Tipo de usuário desconhecido.");
                break;
        }
    }
}