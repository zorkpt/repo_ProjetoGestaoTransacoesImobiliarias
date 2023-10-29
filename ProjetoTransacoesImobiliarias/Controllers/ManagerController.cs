using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class ManagerController : Manager
{
  //  Manager Manager1;
//    List<Client> ClientList;


    public ManagerController(string userName, string password)
        : base(userName, password)
    {
        
    }


    public static List<Manager> GetManagerList{

      get{ return ManagerList; }

      set{}
    } 


}