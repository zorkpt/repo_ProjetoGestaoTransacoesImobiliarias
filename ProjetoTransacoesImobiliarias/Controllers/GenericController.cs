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
        public static void ListView<T>(List<T> l){
            foreach (var item in l)
            {
                if(typeof(T) == typeof(Client)){
                    Client? item1 = item as Client;
                    Console.WriteLine($"{item1.Name}");
                }
                if(typeof(T) == typeof(Manager)){
                    Manager? item1 = item as Manager;
                    Console.WriteLine($"{item1.Username}");
                }
                
            }
        }
    


        /// <summary>
        /// Searches for a user by their ID in a given list.
        /// </summary>
        /// <typeparam name="T">Generic list</typeparam>
        /// <param name="list"></param>
        /// <param name="searchId"></param>
        /// <returns>The ID of the user if found, or -1 if not found.</returns>
        public static int SearchUserById<T>(List<T> list, int searchId){

            foreach (var item in list)
            {
                if(typeof(T) == typeof(Manager)){
                    Manager? itemManager = item as Manager;
                    if(itemManager.Id == searchId){

                        return searchId;
                    }
                }
                if(typeof(T) == typeof(Client)){
                    Client? itemClient = item as Client;
                    if(itemClient.IdClient == searchId){

                        return searchId;
                    }
                }


            }
            return -1;
        }
    
    #region Client
        /// <summary>
        /// Prints the details of a client based on their ID.
        /// </summary>
        /// <param name="id">Client id</param>
        public static void PrintCientDetails(int id){
            Client? a = Client.ClientList.FirstOrDefault(c => c.IdClient == id);

            if(a != null){
                Console.WriteLine($"Name: {a.Name} {a.IdClient} -> AgentID {a.IdAgent}");
            }
            
        }
    
    #endregion
    }


}