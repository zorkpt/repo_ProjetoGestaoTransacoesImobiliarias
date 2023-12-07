namespace ProjetoTransacoesImobiliarias.Models;


public class Visits
{
    #region Attributes
    private Client? client;
    private int clientId;
    private Property? property;
    private DateTime date;
    #endregion

    #region Properties

    public Client? ClientP{get{return client;}set{client = value;}}
    public int ClientId{get{return clientId;}set{clientId = value;}}
    public Property? PropertyP{get{return property;}set{property = value;}}
    public DateTime Date{get{return date;} set{date = value;}}
    public static List<Visits> ListOfVisits = new List<Visits>();
    #endregion

    #region Construtor
    public Visits(Client client, int clientId, Property property, DateTime date){
        this.ClientP = client;
        this.ClientId = clientId;
        this.PropertyP = property;
        this.Date = date;
        ListOfVisits.Add(this);
    }
    #endregion

}
