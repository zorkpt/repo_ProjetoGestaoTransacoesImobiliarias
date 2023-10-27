using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class ManagerController
{
    public static void StartView() //podemos passar os dados do user aqui ? 
    {
        ManagerView.StartView();
    }

    public Client AddClient(string name, string adress, int IdAgent)
    {
        Client a = new Client(name, adress, IdAgent);
        return a;
    }

/// <summary>
/// 
/// </summary>
/// <param name="c"></param>
/// <param name="lista"></param>
/// <returns>Return the value of the client if its true or the -1 if doesnt exists</returns>
    public int SearchClientById(Client c, List<Client> clientList){

        foreach(Client cliente in clientList){
            return cliente.IdClient == c.IdClient ? c.IdClient : -1;
        }

        return -1;
    }

    public bool RemoveClientById(Client c, List<Client> clientList)
    {
        
        foreach(Client cliente in clientList){
            return cliente.IdClient == c.IdClient ? true : false;
        }

        return false;
    }

    public bool EditClientNameByID(Client c, string newName, List<Client> clientList)
    {

        
        return false;
    }
    public bool EditClientAdressyID(Client c, string newAdress)
    {


        return false;
    }


    public Client RegisterProperty(string name, string adress, int IdAgent)
    {
        Client a = new Client(name, adress, IdAgent);
        return a;
    }
}