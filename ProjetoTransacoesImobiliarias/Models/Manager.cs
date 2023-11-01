using System.Dynamic;
using ProjetoTransacoesImobiliarias.Controllers;

namespace ProjetoTransacoesImobiliarias.Models;

public class Manager : Admin
{
    public int NumberOfPropertiesManaged { get; set; }
    protected static List<Manager> ManagerList = new List<Manager>();

    protected Manager(string username, string password)
        : base(username, password, UserRole.Manager)
    {

        ManagerList.Add(this);
    }

    protected Manager(){
        //vazio;
    }

    protected Manager AddManager(string name, string adress, int userID)
    {
        Manager a = new Manager(name, adress);
        return a != null ? a : null;
    }


}

