using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace ProjetoTransacoesImobiliarias.Models
{

    
    public class Data
    {


        public static bool SaveToJson<T>(List<T> list){
            string json = JsonSerializer.Serialize(list);
            {
                if(typeof(T) == typeof(Client)){
                    string FileJson = "Files/ClientJson.json";
                    File.WriteAllText(FileJson, json);
                    return true;
                }
                if(typeof(T) == typeof(Manager)){
                    string FileJson = "Files/ManagerJson.json";
                    File.WriteAllText(FileJson, json);
                    return true;
                }
                if(typeof(T) == typeof(Admin)){
                    string FileJson = "Files/AdminJson.json";
                    File.WriteAllText(FileJson, json);
                    return true;
                }
                
                if(typeof(T) == typeof(Agent)){
                    string FileJson = "Files/AgentJson.json";
                    File.WriteAllText(FileJson, json);
                    return true;
                }
                return false;
            }
        }
        public static bool ReadFromJson<T>(List<T> list){
            string filePath = GetJsonFilePath<T>();

            if(File.Exists(filePath))
            {
                try{
                    string json = File.ReadAllText(filePath);
                    if(json != null){
                        List<T> deserializedList = JsonSerializer.Deserialize<List<T>>(json);

                        return true;
                    }
                }
                catch{
                    return false;
                }
            }

            return false;
        }
    
        private static string GetJsonFilePath<T>()
        {
            if (typeof(T) == typeof(Client))
            {
                return "Files/ClientJson.json";
            }
            if (typeof(T) == typeof(Manager))
            {
                return "Files/ManagerJson.json";
            }
            if (typeof(T) == typeof(Admin))
            {
                return "Files/AdminJson.json";
            }
            if (typeof(T) == typeof(Agent))
            {
                return "Files/AgentJson.json";
            }

            throw new ArgumentException($"Unsupported type: {typeof(T).Name}");
        }

        public static bool SaveToSql<T>(List<T> list){
            

            return false;
        }

    }
}