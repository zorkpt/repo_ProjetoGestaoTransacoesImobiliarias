using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Reflection.Metadata;
using ProjetoTransacoesImobiliarias.Controllers;

namespace ProjetoTransacoesImobiliarias.Models
{

    
    public class Data
    {
        public List<User> User { get; set; } = new();
            
        public static bool SaveToJsonGeneric<T>(int userID, List<T> list){
            if(SaveToJson(list)) return true;
            return false;
        }

        /// <summary>
        /// Saves a list of objects to a JSON file.
        /// </summary>
        /// <typeparam name="T">Generic list defined in the class</typeparam>
        /// <param name="list">Generic list</param>
        /// <returns>True if the list was successfully saved to a JSON file. False otherwise.</returns>
        private static bool SaveToJson<T>(List<T> list){

            string json = JsonSerializer.Serialize(list);

            {
                if(typeof(T) == typeof(ClientController)){
                    json = JsonSerializer.Serialize(value: list);
                    string FileJson = "Files/ClientJson.json";
                    File.WriteAllText(FileJson, json);
                    return true;
                }
                if(typeof(T) == typeof(Manager)){
                    string FileJson = "Files/ManagerJson.json";
                    File.WriteAllText(FileJson, json);
                    return true;
                }
                if(typeof(T) == typeof(ManagerController)){
                    string FileJson = "Files/ManagerJson.json";
                    File.WriteAllText(FileJson, json);
                    return true;
                }
                if(typeof(T) == typeof(AdminController)){
                    string FileJson = "Files/AdminJson.json";
                    File.WriteAllText(FileJson, json);
                    return true;
                }
                
                if(typeof(T) == typeof(Agent)){
                    string FileJson = "Files/AgentJson.json";
                    File.WriteAllText(FileJson, json);
                    return true;
                }

                if(typeof(T) == typeof(PropertyController)){
                    string FileJson = "Files/PropertyJson.json";
                    File.WriteAllText(FileJson, json);
                    return true;
                }
                
                return false;
            }
        }
        
        
        private static bool SaveToSql<T>(List<T> list){
            return false;
        }
        
        
    }
}