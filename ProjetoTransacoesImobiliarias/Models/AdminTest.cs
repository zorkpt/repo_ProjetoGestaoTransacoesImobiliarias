namespace ProjetoTransacoesImobiliarias.Models;

public class AdminTest : UserTest
{
    public AdminTest(string username, string password) 
        : base(username, password, UserRole.Admin)
    {
    }

}
