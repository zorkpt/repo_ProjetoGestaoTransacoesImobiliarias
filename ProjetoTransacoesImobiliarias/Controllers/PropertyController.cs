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


        #region Proprities
        public int ShowPropertyId(int userID) => GetIdProperty();

        public string ShowPorpertyAddress() => GetAdressProperty();

        public PropertyType ShowPorpertyType() => GettypeProperty();
        public decimal ShowPorpertyAvaliatorValue() => GetAvaliatorValueProperty();
        public bool ShowForSaleProperty() => GetForSaleProperty();
        public decimal ShowPorpertyWantedValue() => GetWantedValueProperty();
        public double ShowPorpertySquareMeters() => GetSquareMetersProperty();
        public int ShowPorpertyClientID() => GetClienteIDProperty();
        public int ShowPorpertyAgentID() => GetAgentIDProperty();

        public bool ChangePorpertyAddress(string adress) => SetAdressProperty(adress) ? true : false;
        public bool ChangePropertyType(PropertyType type) => SettypeProperty(type) ? true : false;
        public bool ChangePorpertyAvaliatorValue(decimal value) => SetAvaliatorValueProperty(value) ? true : false;
        public bool ChangePorpertyWantedValue(decimal value) => SetWantedValueProperty(value) ? true : false;
        public bool ChangePorpertySquareMeters(double value) => SetSquareMetersProperty(value) ? true : false;
        public bool ChangePorpertyClientID(int value) => SetClienteIDProperty(value) ? true : false;
        public bool ChangePorpertyAgentID(int value) => SetAgentIDProperty(value) ? true : false;


        #endregion Proprities




    }
}