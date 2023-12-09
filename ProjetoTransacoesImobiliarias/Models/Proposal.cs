using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace ProjetoTransacoesImobiliarias;

public class Proposal
{
    private static int ProposalIdCounter = 0;
    public int ProposalId { get; set; }
    public int ClientId { get; set; }
    public int PropertyId { get; set; }
    protected decimal ProposalValue { get; set; }
    public DateTime? ProposalDate {get ; set ;}
    public DateTime? ProposalAceptedDate {get ; set ;}
    public DateTime? ProposalDateLimit {get ; set ;}
    public bool Active;
    public static List<Proposal> ProposalList = new List<Proposal>();

    public Proposal( int clientId, int propertyId, decimal proposalValue)
    {
        ProposalId = ProposalIdCounter++;
        ClientId = clientId;
        PropertyId = propertyId;
        ProposalValue = proposalValue;
        //ProposalDate = proposalDate;
        //ProposalDateLimit = proposalDateLimit;
        Active = true;
        ProposalList.Add(this);
    }
    public Proposal()
    {
        //Empty necessario?
    }

}
