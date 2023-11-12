namespace ProjetoTransacoesImobiliarias.Views;

public class LoginView
{
    public string username;
    public string password;
    
    public LoginView Start()
    {
        Console.WriteLine("Por favor, insira o seu nome de utilizador:");
        username = Console.ReadLine();
        Console.WriteLine("Por favor, insira a sua senha:");
        password = Console.ReadLine();

        return this;
    }
}