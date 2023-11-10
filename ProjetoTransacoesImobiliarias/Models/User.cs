using System.Collections.Generic;
using ProjetoTransacoesImobiliarias.Interfaces;

namespace ProjetoTransacoesImobiliarias.Models;

public abstract class User : IUser
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }  // Novo campo para o Role
    
    
    public static int Contador = 0;
    public static List<User> UserList = new List<User>();

    /// <summary>
    /// Initializes a new instance of the User class with the specified username, password, and role.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="role"></param>
    protected User(string username, string password, UserRole role)
    {

        Id = Contador++;
        Username = username;
        Password = password;
        Role = role;
        
        UserList.Add(this);

    }
    
    
    
    /// <summary>
    /// Creates a protected constructor for the User class.
    /// </summary>
    protected User(){
        //empty
    }
    


}
