using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;
using ProjetoTransacoesImobiliarias.Views.CLI.Client;

namespace ProjetoTransacoesImobiliarias.Controllers
{
    public class AgentController : UserController
    {
        private readonly Agent _agent;
        private ProposalController proposalController;
        private TransactionController transactionController;
        private AgentView agentView { get; set; }
        private VisitsController visitsController;
        private PropertyController propertyController;

        public AgentController(Agent agent, IUserService userService, IClientService clientService,
            IPropertyService propertyService)
            : base(userService, clientService, propertyService, new ProposalController(), new TransactionController(),
                new PropertyController(), new VisitsController())
        {
            _agent = agent;
            agentView = new AgentView();
        }

        /// <summary>
        /// Executes the menu functionality for the agent user.
        /// </summary>
        public override void MenuStart()
        {
            var exitMenu = false;
            while (!exitMenu)
            {
                var option = AgentView.ShowAgentMenu(_agent);
                switch (option)
                {
                    case "1":
                        SubMenuManageClients();
                        break;
                    case "99":
                        if (_clientService.SaveClientsToJson())
                        {
                            MessageHandler.PressAnyKey("Fechando aplicação...");
                        }

                        break;
                    case "0":
                        exitMenu = true;
                        break;
                    default:
                        MessageHandler.WrongOption();
                        break;
                }
            }
        }

        /// <summary>
        /// Manages the submenu for managing clients.
        /// </summary>
        private void SubMenuManageClients()
        {
            var exitMenu = false;
            while (!exitMenu)
            {
                var option = Menu.ManageClientsMenu();
                switch (option)
                {
                    case "1":
                        var clientData = ClientView.AddClient();
                        _clientService.AddClient(clientData, _agent);
                        break;
                    case "2":
                        EditClient();
                        break;
                    case "3":
                        // DeleteClient();
                        break;
                    case "4":
                        ListClients(false);
                        break;
                    case "5":
                        ListClients();
                        break;
                    case "6":
                        ManageClientOptions();
                        break;
                    case "0":
                        exitMenu = true;
                        break;
                    default:
                        MessageHandler.WrongOption();
                        break;
                }
            }
        }

        /// <summary>
        /// Lists all the clients of the agent.
        /// </summary>
        /// <param name="all"></param>
        private void ListClients(bool all = true)
        {
            var clients = all ? _clientService.GetAllClients() : _agent.GetAgentClients();
            ListClients(clients);
        }
    }
}