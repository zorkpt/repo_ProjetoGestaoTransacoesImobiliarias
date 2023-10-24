using ProjetoTransacoesImobiliarias.Interfaces;

namespace ProjetoTransacoesImobiliarias.Models;

public abstract class User : IUser
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }  // Novo campo para o Role

    protected User(int id, string username, string password, UserRole role)
    {
        Id = id;
        Username = username;
        Password = password;
        Role = role;
    }
    
    public virtual string DisplayRoleSpecificInfo()
    {
        return "Comportamento Padrão.";
    }
}
