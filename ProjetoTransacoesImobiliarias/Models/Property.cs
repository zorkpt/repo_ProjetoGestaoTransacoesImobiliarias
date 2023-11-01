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


    protected Property(string adress, PropertyType type, decimal avaliatorValue, 
                    decimal wantedValue, double squareMeters, int clienteID, int userID){

        if(!UserController.Access(userID, 2)){
            throw new InvalidOperationException("Acess denied");
        }

        this.SetIdProperty(Contador++);
        this.SetAdress(adress);
        this.Settype(type);
        this.SetAvaliatorValue(avaliatorValue);
        this.SetWantedValue(wantedValue);
        this.SetSquareMeters(squareMeters);
        this.SetClienteID(clienteID);
        this.SetAgentID(userID);
        
        if(avaliatorValue != 0)
        {
            this.SetForSale(true);
        }else
        {
            this.SetForSale(false);
        }

        PropertyList.Add(this);

    }

    #region Proprities
            private int GetIdProperty()
            {
                return idProperty;
            }

            private void SetIdProperty(int value)
            {
                idProperty = value;
            }
            private string GetAdress()
            {
                return adress;
            }

            private void SetAdress(string value)
            {
                adress = value;
            }

            private PropertyType Gettype()
            {
                return type1;
            }

            private void Settype(PropertyType value)
            {
                type1 = value;
            }
            private decimal GetAvaliatorValue()
            {
                return avaliatorValue;
            }

            private void SetAvaliatorValue(decimal value)
            {
                avaliatorValue = value;
            }


            private decimal GetWantedValue()
            {
                return wantedValue;
            }

            private void SetWantedValue(decimal value)
            {
                wantedValue = value;
            }


            private double GetSquareMeters()
            {
                return squareMeters;
            }

            private void SetSquareMeters(double value)
            {
                squareMeters = value;
            }


            private int GetClienteID()
            {
                return clienteID;
            }

            private void SetClienteID(int value)
            {
                clienteID = value;
            }


            private int GetAgentID()
            {
                return agentID;
            }

            private void SetAgentID(int value)
            {
                agentID = value;
            }


            private bool GetForSale()
            {
                return forSale;
            }

            private void SetForSale(bool value)
            {
                forSale = value;
            }

    #endregion Proprities

}