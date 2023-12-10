using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI.Proposal;
using ProjetoTransacoesImobiliarias.Interfaces;


namespace ProjetoTransacoesImobiliarias.Controllers
{
    internal class ProposalController 
    {

        private ProposalView proposalView { get; set; }
        private readonly IClientService _clientService;
        private readonly IPropertyService _propertyService;

        
        public ProposalController(){
            proposalView = new ProposalView();
            
        }

        public bool MakeProposal(int numClient){
            int? clientId;
            if(numClient == -1){
                clientId = proposalView.ProposalViewIdClient();            
            }
            else
            {
                clientId = numClient;
            }
            int? propertyId = proposalView.ProposalViewIdProperty();
            decimal proposalValue = proposalView.ProposalViewProposalValue();
            Client? client = Client.ClientList.Find(x => x.Id == clientId);
            Property? property = Property.PropertyList.Find(x => x.Id == propertyId);
            if(client == null || property == null){
                Menu.ErrorMessage();
            }else
            {    
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
            return false;
        }

        public bool SeeProposalsByClient(Client Client){
            List<Proposal> List = Proposal.ProposalList.FindAll(x => x.Client.Id == Client.Id).ToList();
            
            if(List == null){
                Menu.ErrorMessage();
                return false;
            }
            foreach (Proposal proposal in List)
            {
                //eviar para as views...
                Console.WriteLine("Lista de Todos os Utilizadores:");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("| ID | Username |                 Descrição  |              ProposalDate  | Proposal Acepted Date                        |");
                Console.WriteLine("---------------------------------------------------");
                Console.Write(proposal.ProposalId + "   ");
                Console.Write(proposal.Client.Name + "   ");
                Console.Write(proposal.Property.Description + "   ");
                Console.Write(proposal.ProposalDate + "   ");
                Console.Write(proposal.ProposalAceptedDate);
                Console.WriteLine("-----".PadRight(50, '-'));
            }
            //proposalView.Print(List);
            return true;
        }
        
        public bool SeeProposalsByProperty(int PropertyId){
            List<Proposal>? List = Proposal.ProposalList.FindAll(x => x.Property.Id == PropertyId).ToList();

            if(List == null){
                Menu.ErrorMessage();
            }else
            {
                proposalView.Print(List);
            }
            return true;
        }

        public bool SeeAllProposals(){
            List<Proposal> List = Proposal.ProposalList;

            if(List == null){
                Menu.ErrorMessage();
            }

            foreach (Proposal proposal in List)
            {
                Console.Write(proposal.ProposalId);
                Console.Write(proposal.Client.Name);
                Console.Write(proposal.Property.Address);
                Console.Write(proposal.ProposalDate);
                Console.Write(proposal.ProposalAceptedDate);
            }
            //proposalView.Print(List);
            return true;
        }


        public Proposal ChooseProposal()
        {
            while (true)
            {
                SeeAllProposals();
                proposalView.ChooseProposalView();
                int proposalId = Convert.ToInt32(Console.ReadLine());
                Proposal? proposal = Proposal.ProposalList.Find(x => x.ProposalId == proposalId);
                if(proposal == null){
                    Menu.ErrorMessage();
                }else{
                    return proposal;
                }
            }
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
    
        public bool DeclineProposal(int proposalId){
            Proposal? proposal = Proposal.ProposalList.Find(x => x.ProposalId == proposalId);
            if (proposal == null) return false;
            proposal.Active = false;
            proposal.ProposalRejectedDate = DateTime.Now;
            return true;
        }

    } 
}