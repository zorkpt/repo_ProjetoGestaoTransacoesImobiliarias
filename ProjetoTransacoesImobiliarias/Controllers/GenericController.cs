using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views;

namespace ProjetoTransacoesImobiliarias.Controllers
{
    public static class GenericController 
    {
        /// <summary>
        /// Iterates over a generic list and prints out specific properties of each item.
        /// </summary>
        /// <typeparam name="T">Generic list</typeparam>
        /// <param name="l">List to iterate</param>
        // public static void ListView<T>(List<T> l){

        //     foreach (var item in l)
        //     {
        //         if(typeof(T) == typeof(ClientController)){
        //             ClientController? item1 = item as ClientController;
        //             if(item1 == null) return;
        //             Console.WriteLine($"ID: {item1.ShowClientId()}");
        //             Console.Write($"Name: {item1.ShowClientName()} ");
        //             Console.Write($"Adress: {item1.ShowClientAdress()} ");
        //             Console.Write($"Agent ID: {item1.ShowClientAgent()} \n");
        //         }
                
        //         if(typeof(T) == typeof(ManagerController)){
        //             ManagerController? item1 = item as ManagerController;
        //             if(item1 == null) return;
        //             Console.WriteLine($"UserName {item1}");
        //         }
                
        //     }
        // }
    

        // / <summary>
        // / Searches for a user by their ID in a given list.
        // / </summary>
        // / <typeparam name="T">Generic list</typeparam>
        // / <param name="list"></param>
        // / <param name="searchId"></param>
        // / <returns>The ID of the user if found, or -1 if not found.</returns>
        // public static int ?SearchUserById<T>(List<T> list, int searchId){
        //     return 0;
        //     foreach (var item in list)
        //     {
        //         if(typeof(T) == typeof(Manager)){
        //             Manager? itemManager = item as Manager;
        //             if(itemManager == null) return null;
        //             if(itemManager.Id == searchId){

        //                 return searchId;
        //             }
        //         }
        //         if(typeof(T) == typeof(ClientController)){
        //             ClientController? itemClient = item as ClientController;
        //             if(itemClient == null) return null;
        //             if(itemClient.ShowClientId() == searchId){

        //                 return searchId;
        //             }
        //         }


        //     }
        //     return -1;
        // }
    
    #region Client
        /// <summary>
        /// Prints the details of a client based on their ID.
        /// </summary>
        // /// <param name="id">Client id</param>
        // public static void PrintCientDetails(int id){
        //     ClientController? a = ClientController.ClientControllerList.FirstOrDefault(c => c.ShowClientId() == id);

        //     if(a != null){
        //         Console.WriteLine($"Name: {a.ShowClientName()} {a.ShowClientId()} -> AgentID {a.ShowClientName()}");
        //     }
            
        }
    
    #endregion

        #region DateTime
   
        #endregion
    }