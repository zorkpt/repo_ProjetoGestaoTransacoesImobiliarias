using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class ManagerController
{   
    public static void Menu(Manager manager)
    {
        ManagerView.ShowManagerMenu(manager);
    }
    

    // public bool AddClientByManager(string name, string address, int userID){
    //
    //     this.AddClient(name, address, userID);
    //     return this != null ? true : false;
    //
    // }
    //
    // public bool FindIndexByIdManager<T>(int id, List<T> list){
    //     
    //     int num = this.FindIndexById(list, id);
    //     return num != -1 ? true : false;
    // }
    //
    // public bool RemoveIdFromListManager<T>(List<T> list, int index){
    //     return RemoveIdFromList(list, index);
    // }






}