using System.Dynamic;

namespace ProjetoTransacoesImobiliarias.Models;

public class Manager : User
{
    public int NumberOfPropertiesManaged { get; set; }
    protected static List<Manager> ManagerList = new List<Manager>();

    protected Manager(string username, string password)
        : base(username, password, UserRole.Manager)
    {

        ManagerList.Add(this);
    }
    


}
