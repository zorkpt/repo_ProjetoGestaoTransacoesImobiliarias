using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using Microsoft.VisualBasic;
using ProjetoTransacoesImobiliarias.Controllers;
namespace ProjetoTransacoesImobiliarias.Models;

public class Property
{
    private static int Contador = 0;
    private int idProperty;



    private string adress;
    private PropertyType type1;
    private decimal avaliatorValue;
    private bool forSale;
    private decimal wantedValue;
    private double squareMeters;
    private int clienteID;
    private int agentID;




    private static List<Property> PropertyList = new List<Property>();// test readonly

    /// <summary>
    /// A constructor for the Property class that initializes its properties with the given values.
    /// </summary>
    /// <param name="adress"></param>
    /// <param name="type"></param>
    /// <param name="avaliatorValue"></param>
    /// <param name="wantedValue"></param>
    /// <param name="squareMeters"></param>
    /// <param name="clienteID"></param>
    /// <param name="userID"></param>
    /// <exception cref="InvalidOperationException"></exception>
    protected Property(string adress, PropertyType type, decimal avaliatorValue, 
                    decimal wantedValue, double squareMeters, int clienteID, int userID){

        // if(!UserController.Access(userID, 2)){//talvez não seja necessário por aqui mas sim no controller, ver com pessoal
        //     throw new InvalidOperationException("Acess denied");
        // }

        this.SetIdProperty(Contador++);
        this.SetAdressProperty(adress);
        this.SettypeProperty(type);
        this.SetAvaliatorValueProperty(avaliatorValue);
        this.SetWantedValueProperty(wantedValue);
        this.SetSquareMetersProperty(squareMeters);
        this.SetClienteIDProperty(clienteID);
        this.SetAgentIDProperty(userID);
        
        PropertyList.Add(this);

    }

    #region Proprities
            protected int GetIdProperty()
            {
                return idProperty;
            }

            protected bool SetIdProperty(int value)
            {
                if(!int.TryParse(value.ToString(), out int number));
                if(number < 0) return false;

                idProperty = number;
                return true;
            }
            protected string GetAdressProperty()
            {
                return adress;
            }

            protected bool SetAdressProperty(string value)
            {
                if(value == null) return false;
                adress = value;
                return true;
            }

            protected PropertyType GettypeProperty()
            {
                return type1;
            }

            protected bool SettypeProperty(PropertyType value)
            {
                if(value == null) return false;
                type1 = value;
                return true;
            }
            protected decimal GetAvaliatorValueProperty()
            {
                return avaliatorValue;
            }

            protected bool SetAvaliatorValueProperty(decimal value)
            {
                if(value < 0) return false;
                avaliatorValue = value;
                return true;
            }


            protected decimal GetWantedValueProperty()
            {
                return wantedValue;
            }

            protected bool SetWantedValueProperty(decimal value)
            {
                if(value < 0) return false;
                wantedValue = value;
                return true;
            }


            protected double GetSquareMetersProperty()
            {
                return squareMeters;
            }

            protected bool SetSquareMetersProperty(double value)
            {
                if(value < 0) return false;
                squareMeters = value;
                return true;
            }


            protected int GetClienteIDProperty()
            {
                return clienteID;
            }

            protected bool SetClienteIDProperty(int value)
            {
                if(value < 0) return false;
                clienteID = value;
                return true;
            }


            protected int GetAgentIDProperty()
            {
                return agentID;
            }

            protected bool SetAgentIDProperty(int value)
            {
                if(value < 0) return false;
                agentID = value;
                return true;
            }


            protected bool GetForSaleProperty()
            {
                return forSale;
            }

            protected bool SetForSaleProperty(bool value)
            {
                if(GetAvaliatorValueProperty() != 0)
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