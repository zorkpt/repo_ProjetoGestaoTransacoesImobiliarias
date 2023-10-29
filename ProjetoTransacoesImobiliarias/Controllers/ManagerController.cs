using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class ManagerController : AdminController
{
    Manager Manager1;
    List<Client> ClientList;


    public ManagerController(){
        //vazio
    }
    public ManagerController(Manager manager){
        Manager1 = manager;
        //ClientList = new List<Client>(); // Ver se isto é mesmo preciso.
    }

    public void SeeList(List<Client> l){
        
        GenericController.ListView(l);
    }



    // public Client AddClient(string name, string adress)
    // {
    //     Client a = new Client(name, adress, Manager1.Id);
    //     this.ClientList.Add(a);
    //     return a;
    // }

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
        c.Name = newName;
        
        return true;
    }
    public bool EditClientAdressyID(Client c, string newAdress)
    {
        c.Adress = newAdress;

        return false;
    }


    public Client RegisterProperty(string name, string adress, int IdAgent)
    {
        Client a = new Client(name, adress, IdAgent);
        return a;
    }
}