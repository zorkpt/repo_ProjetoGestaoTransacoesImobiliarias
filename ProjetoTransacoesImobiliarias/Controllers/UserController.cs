using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views;


namespace ProjetoTransacoesImobiliarias.Controllers
{
    public class UserController : User
    {
        public UserController(string username, string password, UserRole role):
            base(username, password, role){
                
        }
        
        
        

        // public static ClientController? AddClientGeneric(string name, string adress, int UserID)
        // {
        //     #region Validations
        //     if(!Access(UserID, 2)) return null;
        //     #endregion

        //     try{
        //         ClientController? a = ClientController.AddClient(name, adress, UserID);
        //         return a;
        //     }
        //     catch(Exception error){
        //         Console.WriteLine(error.Message);
        //         return null;
        //     }
            
        //}


    }
}