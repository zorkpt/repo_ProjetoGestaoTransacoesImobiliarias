using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace ProjetoTransacoesImobiliarias;

public class Proposal
{
    private int ProposalId { get; set; }
    protected int ClientId { get; set; }
    protected int PropertyId { get; set; }
    protected decimal ProposalValue { get; set; }
    protected DateAndTime? ProposalDate {get ; set ;}
    protected DateAndTime? ProposalDateLimit {get ; set ;}
    protected bool Active;
    protected static List<Proposal> ProposalList = new List<Proposal>();
}
