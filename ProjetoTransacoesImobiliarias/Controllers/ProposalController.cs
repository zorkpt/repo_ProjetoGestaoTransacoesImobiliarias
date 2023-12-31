using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI.Proposal;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Views.CLI;


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

        /// <summary>
        /// Makes a proposal.
        /// </summary>
        /// <param name="numClient"></param>
        /// <returns></returns>
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

            //Valida se este cliente já tem proposta para esta propriedade
            bool hasProposal = Proposal.ProposalList.Exists(p => p.Client.Id == client.Id && p.Property.Id == property.Id && p.Active);
            if (hasProposal)
            {
                // Cliente já tem proposta para esta propriedade
                MessageHandler.PressAnyKey($"Cliente ({client.Name}) já fez proposta a esta propriedade, esta proposta foi cancelada");
                return false;
            }
            //Valida se o cliente é o dono da propriedade
            if (client.Id == property.Client.Id)
            {
                //Cliente não é dono da propriedade
                MessageHandler.PressAnyKey($"Cliente ({client.Name}) é dono da propriedade não pode voltar a comprar");
                return false;
            }


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

        /// <summary>
        /// See all proposals by a client.
        /// </summary>
        /// <param name="Client"></param>
        /// <returns></returns>
        public bool SeeProposalsByClient(Client Client){
            List<Proposal> List = Proposal.ProposalList.FindAll(x => x.Client.Id == Client.Id).ToList();
            
            if(List == null || List.Count == 0){
                Menu.ErrorMessage();
                return false;
            }

            Console.WriteLine("Lista de Todos os Utilizadores:");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("| ID | Username |                 Descrição  |              ProposalDate  | Proposal Acepted Date | Reject date                       |");
            Console.WriteLine("---------------------------------------------------");
            foreach (Proposal proposal in List)
            {
                //eviar para as views...

                Console.Write(proposal.ProposalId + "   | ");
                Console.Write(proposal.Client.Name + "   | ");
                Console.Write(proposal.Property.Description + "   | ");
                Console.Write(proposal.ProposalDate + "   | ");
                Console.Write(proposal.ProposalAceptedDate);
                Console.Write(proposal.ProposalRejectedDate);
                if(proposal.Active)
                {
                    Console.Write("   | ");
                }else{
                    Console.Write(" Proposta cancelada");
                }
                Console.WriteLine("-----".PadRight(50, '-'));
            }
            //proposalView.Print(List);
            return true;
        }
        
        /// <summary>
        /// See all proposals by a property.
        /// </summary>
        /// <param name="PropertyId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// See all proposals.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Choose a proposal.
        /// </summary>
        /// <returns></returns>
        public Proposal? ChooseProposal()
        {
            if(Proposal.ProposalList.Count == 0){
                MessageHandler.PressAnyKey("Sem Propostas");
                return null;
            }
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

        /// <summary>
        /// Accept a proposal.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <returns></returns>
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
    
        /// <summary>
        /// Decline a proposal.
        /// </summary>
        /// <param name="proposalId"></param>
        /// <returns></returns>
        public bool DeclineProposal(int proposalId){
            Proposal? proposal = Proposal.ProposalList.Find(x => x.ProposalId == proposalId);
            if (proposal == null) return false;
            proposal.Active = false;
            proposal.ProposalRejectedDate = DateTime.Now;
            return true;
        }

    } 
}