using System.Collections.Generic;
using Microsoft.VisualBasic;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias;

internal class Proposal
{
    private static int ProposalIdCounter = 0;
    public int? ProposalId { get; set; }
    public Client? Client { get; set; }
    public Property? Property { get; set; }
    protected decimal? ProposalValue { get; set; }
    public DateTime? ProposalDate {get ; set ;}
    public DateTime? ProposalAceptedDate {get ; set ;}
    public DateTime? ProposalRejectedDate {get ; set ;}
    public bool Active;
    public static List<Proposal> ProposalList = new List<Proposal>();

    public Proposal( Client clientId, Property propertyId, decimal proposalValue)
    {
        ProposalId = ProposalIdCounter++;
        Client = clientId;
        Property = propertyId;
        ProposalValue = proposalValue;
        ProposalDate = DateTime.Now;
        //ProposalDateLimit = proposalDateLimit;
        Active = true;
        ProposalList.Add(this);
    }
    public Proposal()
    {
        //Empty necessario?
    }

}
