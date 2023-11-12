namespace ProjetoTransacoesImobiliarias.Models;

public abstract class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; } 
    public UserRole Role { get; set; }

    protected User(string username, string password, UserRole role)
    {
        Username = username;
        Password = password; 
        Role = role;
    }
    
}