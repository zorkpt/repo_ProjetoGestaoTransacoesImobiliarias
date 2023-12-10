namespace ProjetoTransacoesImobiliarias.Models;


internal class Visits
{
    #region Attributes
    private Client? client;
    private Property? property;
    private DateTime date;
    #endregion

    #region Properties

    public Client? ClientP{get{return client;}set{client = value;}}
    public Property? PropertyP{get{return property;}set{property = value;}}
    public DateTime Date{get{return date;} set{date = value;}}
    public static List<Visits> ListOfVisits = new List<Visits>();
    #endregion

    #region Construtor
    public Visits(Client client, Property property, DateTime date){
        this.ClientP = client;
        this.PropertyP = property;
        this.Date = date;
        ListOfVisits.Add(this);
    }
    #endregion

}
