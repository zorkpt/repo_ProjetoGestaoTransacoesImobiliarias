using System.Collections.Generic;
using System.Dynamic;
using System.Text.Json.Serialization;
using ProjetoTransacoesImobiliarias.Controllers;

namespace ProjetoTransacoesImobiliarias.Models;

public class Manager : User
{
    public Manager(string username, string password, string name)
        : base(username, password, name, UserRole.Manager)
    {
    }
    
    
    /*public int NumberOfPropertiesManaged { get; set; }
    private static List<Manager> ManagerList = new List<Manager>();
    
    public Manager(string username, string password)
        : base(username, password, UserRole.Manager)
    {
    }
    
    protected Manager AddManager(string name, string adress, int userID)
    {
        Manager a = new Manager(name, adress);
        return a != null ? a : null;
    }

    public static void AddManager(Manager manager)
    {
        ManagerList.Add(manager);
    }
        
    public static void AddManagers(IEnumerable<Manager> managers)
    {
        ManagerList.AddRange(managers);
    }
        
    public static List<Manager> GetManagerList()
    {
        return ManagerList;
    }*/

}

