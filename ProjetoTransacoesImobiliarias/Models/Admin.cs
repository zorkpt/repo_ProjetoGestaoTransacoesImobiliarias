using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;

namespace ProjetoTransacoesImobiliarias.Models
{
    public class Admin : User
    {
        protected decimal CommissionValue { get; set; }
        private static List<Admin> adminList = new List<Admin>();
        public Admin(){
            //vazio
        }
        public Admin(string username, string password)
            : base(username, password, UserRole.Admin)
        {
            //add list of admin?
        }
        public Admin(string username, string password, UserRole role)
            : base(username, password, role)
        {
            //With this constructor, we can create manager and agents
        }
        protected bool AddClient(string name, string adress, int userID)
        {
            
            ClientController? a = new ClientController(name, adress, userID);
            return a != null;
        }

        /// <summary>
        /// Removes an element from the specified index in the given list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <returns>True if the element was successfully removed; otherwise, false.</returns>
        protected bool RemoveIdFromList<T>(List<T> list, int index)
        {
            if(index < 0) return false;
            if(list.Count < index) return false;

            list.RemoveAt(index);
            return true;
        }

        /// <summary>
        /// Finds the index of an element in a list by its ID.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="id"></param>
        /// <returns>The index of the element with the specified ID in the list, or -1 if not found.</returns>
        protected int FindIndexById<T>(List<T> list, int id)
        {
            int index = -1;
            if(typeof(T) == typeof(ClientController)){
                List<ClientController>? a = list as List<ClientController>;
                index = a.FindIndex(x => x.ShowClientId() == id);
                
            }
            if(typeof(T) == typeof(PropertyController)){
                List<PropertyController>? a = list as List<PropertyController>;
                index = a.FindIndex(x => x.ShowPropertyId(id) == id);
            }
            // if(typeof(T) == typeof(AgentController)){
            //     List<AgentController>? a = list as List<AgentController>;
            //     index = a.FindIndex(x => x.idAgent == id);
            // }
            if(typeof(T) == typeof(ManagerController)){
                List<ManagerController>? a = list as List<ManagerController>;
                index = a.FindIndex(x => x.Id == id);
            }
            if(typeof(T) == typeof(AdminController)){
                List<AdminController>? a = list as List<AdminController>;
                index = a.FindIndex(x => x.Id == id);
            }


            return index < 0 ? -1 : index;

            
        }
        public static void AddAdmin(Admin admin)
        {
            adminList.Add(admin);
        }
        
        public static void AddAdmins(IEnumerable<Admin> admins)
        {
            adminList.AddRange(admins);
        }
        
        public static List<Admin> GetAdminList()
        {
            return adminList;
        }

    }
}