using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views;


namespace ProjetoTransacoesImobiliarias.Controllers
{
    public class UserController : Admin
    {
        public int UserID;


        /// <summary>
        /// Determines whether the specified user has access at the given level.
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="level"></param>
        /// <returns> `true` if the user has access at the given level; otherwise, `false`.</returns>
        protected static bool Access(int UserID, int level){
            
            User? log = User.UserList.FirstOrDefault(u => u.Id == UserID);

            if(log == null){
                //Não existe
                return false;
            }else{
                if(log.Role <= (UserRole)level){
                    if(level < 0 ) return false;
                    return true;
                }else{
                    return false;
                }
            }
        }

        public static UserRole? Login(int userID){
            User? log = User.UserList.FirstOrDefault(u => u.Id == userID);
            if (log == null) return null;

            if(log.Role == (UserRole)0){
                return UserRole.Admin;
            }
            if(log.Role == (UserRole) 1){
                return UserRole.Manager;
            }
            if(log.Role == (UserRole)2){
                return UserRole.Agent;
            }
            if(log.Role == (UserRole)3){
                return UserRole.Avaliator;
            }

            return null;
            
        }
        

        public static Client? AddClientGeneric(string name, string adress, int UserID)
        {
            #region Validations
            if(!Access(UserID, 2)) return null;
            #endregion
            
            Client? a = Admin.AddClient(name, adress, UserID);
            
            return a;
        }


    }
}