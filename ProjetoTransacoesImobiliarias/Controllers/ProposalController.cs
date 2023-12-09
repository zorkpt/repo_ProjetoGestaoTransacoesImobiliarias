using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Views.CLI.Proposal;


namespace ProjetoTransacoesImobiliarias.Controllers
{
    public class ProposalController 
    {

        private ProposalView proposalView { get; set; }

        
        public ProposalController(){
            
            proposalView = new ProposalView();
            
        }

        public bool MakeProposal(){

            int clientId = proposalView.ProposalViewIdClient();
            int propertyId = proposalView.ProposalViewIdProperty();
            decimal proposalValue = proposalView.ProposalViewProposalValue();
            
            try{
                Proposal proposal = new Proposal(clientId, propertyId, proposalValue);

                return true;
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool SeeProposalsByClient(int ClientId){
            List<Proposal> List = Proposal.ProposalList.FindAll(x => x.ClientId == ClientId).ToList();
            
            if(List == null){
                Menu.ErrorMessage();
                return false;
            }

            proposalView.Print(List);
            return true;
        }
        
        public bool SeeProposalsByProperty(int PropertyId){
            List<Proposal>? List = Proposal.ProposalList.FindAll(x => x.PropertyId == PropertyId).ToList();

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