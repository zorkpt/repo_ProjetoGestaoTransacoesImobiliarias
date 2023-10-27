namespace ProjetoTransacoesImobiliarias.Models;

public class Manager : User
{
    public int NumberOfPropertiesManaged { get; set; }
    public Manager(string username, string password)
        : base(username, password, UserRole.Manager)
    {

    }


    public bool AddManagerList(Manager manager){
        List<Manager> lista = new List<Manager>();
        lista.Add(manager);   
        return true;
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
