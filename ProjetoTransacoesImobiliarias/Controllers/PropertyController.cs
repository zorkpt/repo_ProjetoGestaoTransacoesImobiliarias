using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Controllers
{



    public class PropertyController : Property
    {
        public static List<PropertyController> PropertyControllerList = new List<PropertyController>();// test readonly

        public PropertyController(string adress, PropertyType type, decimal avaliatorValue, 
                    decimal wantedValue, double squareMeters, int clienteID, int agentID) : base (adress, type, avaliatorValue, wantedValue, squareMeters, clienteID, agentID)
        {
            PropertyControllerList.Add(this);
        }
        


        public static bool CreateProperty(string adress, PropertyType type, decimal avaliatorValue, 
                    decimal wantedValue, double squareMeters, int clienteID, int agentID){
            
            PropertyController a = new PropertyController(adress, type, avaliatorValue, wantedValue, squareMeters, clienteID, agentID);
            return true;
        }
    }
}