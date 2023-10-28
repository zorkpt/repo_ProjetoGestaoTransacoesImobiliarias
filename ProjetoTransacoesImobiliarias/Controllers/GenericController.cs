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
        public static void ListView<T>(List<T> l){
            foreach (var item in l)
            {
                if(typeof(T) == typeof(Client)){
                    Client item1 = item as Client;
                    Console.WriteLine($"{item1.Name}");
                }
                if(typeof(T) == typeof(Manager)){
                    Manager item1 = item as Manager;
                    Console.WriteLine($"{item1.Username}");
                }
                
            }
        }
    

        public static int SearchUserById<T>(List<T> list, int searchId){

            foreach (var item in list)
            {
                if(typeof(T) == typeof(Manager)){
                    Manager itemManager = item as Manager;
                    if(itemManager.Id == searchId){

                        return searchId;
                    }
                }
                if(typeof(T) == typeof(Client)){
                    Client itemClient = item as Client;
                    if(itemClient.IdClient == searchId){

                        return searchId;
                    }
                }


            }
            return -1;
        }
    }

}