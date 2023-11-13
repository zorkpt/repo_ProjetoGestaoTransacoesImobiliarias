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

        public PropertyController(string address, PropertyType type, decimal evaluatorValue,
            decimal wantedValue, double squareMeters, int clientId, int agentId) : base(address, type, evaluatorValue,
            wantedValue, squareMeters, clientId, agentId)
        {
            PropertyControllerList.Add(this);
        }
        
        #region Proprities
        public int ShowPropertyId(int userID) => GetIdProperty();

        public string ShowPorpertyAddress() => GetAddressProperty();

        public PropertyType ShowPorpertyType() => GettypeProperty();
        public decimal ShowPorpertyAvaliatorValue() => GetEvaluatorValueProperty();
        public bool ShowForSaleProperty() => GetForSaleProperty();
        public decimal ShowPorpertyWantedValue() => GetWantedValueProperty();
        public double ShowPorpertySquareMeters() => GetSquareMetersProperty();
        public int ShowPorpertyClientID() => GetClientIdProperty();
        public int ShowPorpertyAgentID() => GetAgentIdProperty();

        public bool ChangePorpertyAddress(string adress) => SetAddressProperty(adress) ? true : false;
        public bool ChangePropertyType(PropertyType type) => SetTypeProperty(type) ? true : false;
        public bool ChangePorpertyAvaliatorValue(decimal value) => SetEvaluatorValueProperty(value) ? true : false;
        public bool ChangePorpertyWantedValue(decimal value) => SetWantedValueProperty(value) ? true : false;
        public bool ChangePorpertySquareMeters(double value) => SetSquareMetersProperty(value) ? true : false;
        public bool ChangePorpertyClientID(int value) => SetClientIdProperty(value) ? true : false;
        public bool ChangePorpertyAgentID(int value) => SetAgentIdProperty(value) ? true : false;


        #endregion Proprities




    }
}