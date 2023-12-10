using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI.Proposal;
using ProjetoTransacoesImobiliarias.Interfaces;


namespace ProjetoTransacoesImobiliarias.Controllers
{
    public class ProposalController 
    {

        private ProposalView proposalView { get; set; }
        private readonly IClientService _clientService;
        private readonly IPropertyService _propertyService;

        
        public ProposalController(){
            proposalView = new ProposalView();
            
        }

        public bool MakeProposal(){

            int? clientId = proposalView.ProposalViewIdClient();
            int? propertyId = proposalView.ProposalViewIdProperty();
            decimal proposalValue = proposalView.ProposalViewProposalValue();
            Client? client = Client.ClientList.Find(x => x.Id == clientId);
            Property? property = Property.PropertyList.Find(x => x.Id == propertyId);
            if(client == null || property == null){
                Menu.ErrorMessage();
            }
            //Client client = _clientService.GetClientById(clientId);
            //Property property = _propertyService.GetPropertyById(propertyId);
            
            try{
                Proposal? proposal = new Proposal(client, property, proposalValue);

                return true;
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool SeeProposalsByClient(Client Client){
            List<Proposal> List = Proposal.ProposalList.FindAll(x => x.Client.Id == Client.Id).ToList();
            
            if(List == null){
                Menu.ErrorMessage();
                return false;
            }

            proposalView.Print(List);
            return true;
        }
        
        public bool SeeProposalsByProperty(int PropertyId){
            List<Proposal>? List = Proposal.ProposalList.FindAll(x => x.Property.Id == PropertyId).ToList();

            if(List == null){
                Menu.ErrorMessage();
            }

            proposalView.Print(List);
            return true;
        }

        public bool SeeAllProposals(){
            List<Proposal> List = Proposal.ProposalList;

            if(List == null){
                Menu.ErrorMessage();
            }

            proposalView.Print(List);
            return true;
        }

        public bool AcceptProposal(int proposalId){
            
            try{
                Proposal? proposal = Proposal.ProposalList.Find(x => x.ProposalId == proposalId);

                if(proposal == null){
                    Menu.ErrorMessage();
                    return false;
                }
                
                proposal.Active = false;
                proposal.ProposalAceptedDate = DateTime.Now;
                return true;
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }
    
    } 
}