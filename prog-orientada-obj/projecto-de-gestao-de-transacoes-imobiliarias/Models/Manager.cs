namespace Projeto_de_Gestao_de_Transacoes_Imobiliarias.Models;

public class Manager : User
{
    public int NumberOfPropertiesManaged { get; set; }

    public Manager(int id, string username, string password)
        : base(id, username, password, UserRole.Manager)
    {
    }
    
    public bool RegisterClient()
    {
        Console.WriteLine("A adicionar um novo cliente");
        return true;
    }
    
    public override string DisplayRoleSpecificInfo()
    {
        return "Fiz Override. Sou Manager";
    }

}
