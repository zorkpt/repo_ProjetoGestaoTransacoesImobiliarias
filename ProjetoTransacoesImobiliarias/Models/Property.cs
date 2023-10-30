using Microsoft.VisualBasic;
using ProjetoTransacoesImobiliarias.Controllers;
namespace ProjetoTransacoesImobiliarias.Models;

public class Property
{
    private static int Contador = 0;
    private int IdProperty { get; set;}
    private string Adress { get; set; }
    private PropertyType type { get; set;}
    private decimal AvaliatorValue { get; set; }
    private decimal WantedValue { get; set; }
    private double SquareMeters { get; set; }
    private int ClienteID { get; set; }
    private int AgentID { get; set; }
    private bool ForSale { get; set;}
    private static List<Property> PropertyList = new List<Property>();// test readonly


    protected Property(string adress, PropertyType type, decimal avaliatorValue, 
                    decimal wantedValue, double squareMeters, int clienteID, int userID){

        if(!UserController.Access(userID, 2)){
            throw new InvalidOperationException("Acess denied");
        }

        this.IdProperty = Contador++;
        this.Adress = adress;
        this.type = type;
        this.AvaliatorValue = avaliatorValue;
        this.WantedValue = wantedValue;
        this.SquareMeters = squareMeters;
        this.ClienteID = clienteID;
        this.AgentID = userID;
        
        if(avaliatorValue != 0)
        {
            this.ForSale = true;
        }else
        {
            this.ForSale = false;
        }

        PropertyList.Add(this);

    }

}