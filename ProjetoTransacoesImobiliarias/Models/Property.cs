using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using Microsoft.VisualBasic;
using ProjetoTransacoesImobiliarias.Controllers;
namespace ProjetoTransacoesImobiliarias.Models;

public class Property
{
    private static int _counter = 0;
    private int _propertyId;
    private string _address;
    private PropertyType _propertyType;
    private decimal _evaluatorValue;
    private bool _forSale;
    private decimal _wantedValue;
    private double _squareMeters;
    private int _clientId;
    private int _agentId;

    private static List<Property> PropertyList = new List<Property>();// test readonly

    /// <summary>
    /// A constructor for the Property class that initializes its properties with the given values.
    /// </summary>
    /// <param name="address"></param>
    /// <param name="propertyType"></param>
    /// <param name="evaluatorValue"></param>
    /// <param name="wantedValue"></param>
    /// <param name="squareMeters"></param>
    /// <param name="clientId"></param>
    /// <param name="userId"></param>
    /// <exception cref="InvalidOperationException"></exception>
    protected Property(string address, PropertyType propertyType, decimal evaluatorValue, 
                    decimal wantedValue, double squareMeters, int clientId, int userId){

        // if(!UserController.Access(userID, 2)){//talvez não seja necessário por aqui mas sim no controller, ver com pessoal
        //     throw new InvalidOperationException("Acess denied");
        // }

        this.SetIdProperty(_counter++);
        this.SetAddressProperty(address);
        this.SetTypeProperty(propertyType);
        this.SetEvaluatorValueProperty(evaluatorValue);
        this.SetWantedValueProperty(wantedValue);
        this.SetSquareMetersProperty(squareMeters);
        this.SetClientIdProperty(clientId);
        this.SetAgentIdProperty(userId);
        
        PropertyList.Add(this);

    }

    #region Proprities
            protected int GetIdProperty()
            {
                return _propertyId;
            }

            protected bool SetIdProperty(int value)
            {
                if(!int.TryParse(value.ToString(), out int number));
                if(number < 0) return false;

                _propertyId = number;
                return true;
            }
            
            protected string GetAddressProperty()
            {
                return _address;
            }

            protected bool SetAddressProperty(string value)
            {
                if(value == null) return false;
                _address = value;
                return true;
            }

            protected PropertyType GettypeProperty()
            {
                return _propertyType;
            }

            protected bool SetTypeProperty(PropertyType value)
            {
                if(value == null) return false;
                _propertyType = value;
                return true;
            }
            protected decimal GetEvaluatorValueProperty()
            {
                return _evaluatorValue;
            }

            protected bool SetEvaluatorValueProperty(decimal value)
            {
                if(value < 0) return false;
                _evaluatorValue = value;
                return true;
            }


            protected decimal GetWantedValueProperty()
            {
                return _wantedValue;
            }

            protected bool SetWantedValueProperty(decimal value)
            {
                if(value < 0) return false;
                _wantedValue = value;
                return true;
            }


            protected double GetSquareMetersProperty()
            {
                return _squareMeters;
            }

            protected bool SetSquareMetersProperty(double value)
            {
                if(value < 0) return false;
                _squareMeters = value;
                return true;
            }


            protected int GetClientIdProperty()
            {
                return _clientId;
            }

            protected bool SetClientIdProperty(int value)
            {
                if(value < 0) return false;
                _clientId = value;
                return true;
            }


            protected int GetAgentIdProperty()
            {
                return _agentId;
            }

            protected bool SetAgentIdProperty(int value)
            {
                if(value < 0) return false;
                _agentId = value;
                return true;
            }


            protected bool GetForSaleProperty()
            {
                return _forSale;
            }

            protected bool SetForSaleProperty(bool value)
            {
                if(GetEvaluatorValueProperty() != 0)
                {
                    this.SetForSaleProperty(true);
                    return true;
                }else
                {
                    this.SetForSaleProperty(false);
                    return false;
                }
            }

    #endregion Proprities

}