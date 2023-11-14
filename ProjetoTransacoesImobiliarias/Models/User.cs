namespace ProjetoTransacoesImobiliarias.Models;

public abstract class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; } 
    public string Name {get; set;}
    public UserRole Role { get; set; }

    protected User(string username, string password, string name, UserRole role)
    {
        Username = username;
        Password = password; 
        Name = name;
        Role = role;
    }
    
}