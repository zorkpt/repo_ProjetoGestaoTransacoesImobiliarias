namespace ProjetoTransacoesImobiliarias.Models;

public class Manager : User
{
    public int NumberOfPropertiesManaged { get; set; }
    public static List<Manager> ManagerList = new List<Manager>();

    public Manager(string username, string password)
        : base(username, password, UserRole.Manager)
    {

        ManagerList.Add(this);
    }


    
    public override string DisplayRoleSpecificInfo()
    {
        return "Fiz Override. Sou Manager";
    }

}
