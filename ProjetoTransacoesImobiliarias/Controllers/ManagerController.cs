using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class ManagerController : Manager
{

    public static List<ManagerController> ManagerControllerList = new List<ManagerController>();


    public ManagerController(string userName, string password)
        : base(userName, password)
    {
        ManagerControllerList.Add(this);
    }


    public static List<Manager> GetManagerList{//em principio já não é preciso 

      get{ return ManagerList; }

      set{}
    } 


}