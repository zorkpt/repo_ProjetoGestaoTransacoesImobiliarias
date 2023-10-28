using ProjetoTransacoesImobiliarias.Interfaces;

namespace ProjetoTransacoesImobiliarias.Models;

public abstract class User : IUser
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }  // Novo campo para o Role
    public int Contador = 0;
    public static List<User> UserList = new List<User>();

    protected User(string username, string password, UserRole role)
    {

        Id = Contador++;
        Username = username;
        Password = password;
        Role = role;

        UserList.Add(this);

    }
    public User(){
        
    }
    
    public virtual string DisplayRoleSpecificInfo()
    {
        return "Comportamento Padrão.";
    }
}
