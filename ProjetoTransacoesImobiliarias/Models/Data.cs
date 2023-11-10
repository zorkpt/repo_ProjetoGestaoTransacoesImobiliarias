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
            public List<Admin> Admin { get; set; } = new List<Admin>();

            public List<Manager> Manager { get; set; } = new List<Manager>();
            public List<Client> Client { get; set; } = new List<Client>();
        

        
        public static bool SaveToJsonGeneric<T>(int userID, List<T> list){
            #region validations
            UserRole? log =  UserController.Login(userID);
            if(log == UserRole.Avaliator) return false;
            #endregion

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
        public static bool ReadFromJson<T>(List<T> list){
            string filePath = GetJsonFilePath<T>();

            if(File.Exists(filePath))
            {
                try{
                    string json = File.ReadAllText(filePath);
                    if(json != null){
                        List<T>? deserializedList = JsonSerializer.Deserialize<List<T>>(json);

                        return true;
                    }
                }
                catch( Exception e){
                    Console.WriteLine(e.Message);
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
            if (typeof(T) == typeof(ManagerController))
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

        public static bool ReadAllUserDataFromJson()
        {
            string filePath = "/home/zork/repo/repo_TP-AMS/ProjetoTransacoesImobiliarias/Files/Data.json";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Ficheiro não encontrado");
                return false;
            }

            Console.WriteLine("Ficheiro Lido");
            try
            {
                string json = File.ReadAllText(filePath);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var userData = JsonSerializer.Deserialize<Data>(json, options);

                if (userData == null)
                {
                    Console.WriteLine("Nenhum dado foi encontrado no ficheiro JSON.");
                    return false;
                }

                if (userData.Admin.Any())
                {
                    Models.Admin.AddAdmins(userData.Admin);
                }
                if (userData.Manager.Any())
                {
                    Models.Manager.AddManagers(userData.Manager);
                }
                if (userData.Client.Any())
                {
                    Models.Client.ClientList.AddRange(userData.Client);
                }
              

                return true;
            }
            catch (JsonException e)
            {
                Console.WriteLine("Erro de deserialização: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro desconhecido: " + e.Message);
            }

            return false;
        }


        
        private static bool SaveToSql<T>(List<T> list){
            return false;
        }
        
        
    }
}