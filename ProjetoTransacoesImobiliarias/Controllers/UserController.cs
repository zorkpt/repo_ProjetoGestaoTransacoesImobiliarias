using ProjetoTransacoesImobiliarias;
using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;

public abstract class UserController
{
    protected readonly IUserService _userService;
    protected readonly IClientService _clientService;
    protected readonly IPropertyService _propertyService;
    protected readonly ProposalController _proposalController;
    protected TransactionController _transactionController;
    protected PropertyController _propertyController;
    protected VisitsController _visitsController;

    protected UserController(IUserService userService, IClientService clientService, IPropertyService propertyService,
        ProposalController proposalController, TransactionController transactionController, 
        PropertyController propertyController, VisitsController visitsController)
    {
        _userService = userService;
        _clientService = clientService;
        _propertyService = propertyService;
        _proposalController = proposalController;
        _transactionController = transactionController;
        _propertyController = propertyController;
        _visitsController = visitsController;
    }
    public abstract void MenuStart();
    
    #region Clients

    protected Client? EditClient()
    {
        Console.Write("Insira o ID do cliente que deseja editar: ");
        var clientId = int.Parse(Console.ReadLine() ?? string.Empty);

        var client = _clientService.GetClientById(clientId);
        if (client == null)
        {
            Console.WriteLine("Cliente não encontrado.");
            return null;
        }

        Console.Write("Insira o novo nome do cliente: ");
        var newName = Console.ReadLine() ?? string.Empty;

        Console.Write("Insira o novo endereço do cliente: ");
        var newAddress = Console.ReadLine() ?? string.Empty;

        client.Name = newName;
        client.Address = newAddress;

        _clientService.UpdateClient(client);

        return client;
    }

    protected void ListClients(IEnumerable<Client> clients)
    {
        if (!clients.Any())
        {
            MessageHandler.PressAnyKey("Sem dados.");
        }
        else
        {
            UserView.DisplayAllClients(clients);
        }
    }

    #endregion

    #region Users

    protected void ListAllUsers(IUserService userService)
    {
        var allUsers = userService.GetAllUsers();
        UserView.DisplayUsers(allUsers);
    }

    protected User AddUser()
    {
        var clientData = UserView.AddUser();
        var newUser = _userService.CreateUser(clientData.Userame,
            clientData.Password,
            clientData.Name,
            clientData.Role);

        MessageHandler.PressAnyKey("Utilizador Adicionado com sucesso.");
        return newUser;
    }


    protected virtual Client ChooseClient()
    {
        while (true)
        {
            int clientId = AdminView.ChooseClientIdView();

            while (!int.TryParse(clientId.ToString(), out clientId))
            {
                Console.WriteLine("Pf inserir um numero valido");
                clientId = AdminView.ChooseClientIdView();
            }

            Client client = _clientService.GetClientById(clientId);
            if (client != null)
            {
                return client;
            }
        }
    }

    public void ManageClientOptions()
    {
        Client client = ChooseClient();

        var exitMenu = false;
        while (!exitMenu)
        {
            Menu.ManageClientsView(client.Name);
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    if(_proposalController.MakeProposal(client.Id))
                    {
                        MessageHandler.PressAnyKey("Proposta enviada com sucesso.");
                    }
                    break;
                case "2":
                    Proposal proposal = _proposalController.ChooseProposal();
                    _proposalController.AcceptProposal(proposal.ProposalId.Value);
                    _transactionController.AddTransaction(proposal);
                    MessageHandler.PressAnyKey("Proposta aprovada com sucesso.");
                    break;
                case "3":
                    if (_proposalController.DeclineProposal(_proposalController.ChooseProposal().ProposalId.Value))
                    {
                        MessageHandler.PressAnyKey("Proposta rejeitada com sucesso.");
                    }
                    break;
                case "4":
                    _proposalController.SeeProposalsByClient(client);
                    break;
                case "5":
                    // Marcar visita
                    var allProperties = _propertyService.GetAllProperties();
                    PropertyView.DisplayAllProperties(allProperties);
                    Property? property = _propertyController.ChooseProperty();
                    if (property == null) return;
                    DateTime date = _visitsController.ChooseDate();
                    if(_visitsController.MakeVisit(property, client, date))
                    {
                        MessageHandler.PressAnyKey("Visita marcada com sucesso.");
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

    #endregion

    #region Properties

    protected Property? AddProperty(User user)
    {
        var propertyData = UserView.AddProperty();
        var client = _clientService.GetClientById(propertyData.ClientId);
        var newProperty =
            _propertyService.CreateProperty(propertyData.Address,
                propertyData.Description,
                propertyData.PropertyType,
                propertyData.Size,
                user,
                client);

        if (newProperty is null)
        {
            return null;
        }

        MessageHandler.PressAnyKey("Propriedade adicionada com sucesso.");
        user.AddProperty(newProperty);
        return newProperty;
    }

    #endregion
}