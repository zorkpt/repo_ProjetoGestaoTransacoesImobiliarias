namespace ProjetoTransacoesImobiliarias.Models;

public abstract class UserTest
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; } 
    public UserRole Role { get; set; }

    protected UserTest(string username, string password, UserRole role)
    {
        Username = username;
        Password = password; 
        Role = role;
    }
    
}