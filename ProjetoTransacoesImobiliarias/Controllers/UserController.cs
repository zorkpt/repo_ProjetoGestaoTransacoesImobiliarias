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
    protected PaymentController _paymentController;

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
        _paymentController = new PaymentController();
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
            int clientId = AdminView.ChooseClientIdView();// Em vez de passar o ID, passamos o nome? para quem utiliza é mais facil...

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
                    // Aprovar proposta
                    Proposal? proposal = _proposalController.ChooseProposal();
                    if(proposal == null)
                    {
                        break;
                    }else
                    {
                        _proposalController.AcceptProposal(proposal.ProposalId.Value);
                        _transactionController.AddTransaction(proposal);
                        MessageHandler.PressAnyKey("Proposta aprovada com sucesso.");
                    }

                    break;
                case "3":
                    // Rejeitar proposta
                    Proposal? proposal1 = _proposalController.ChooseProposal();
                    if(proposal1 == null)
                    {
                        break;
                    }else{
                        bool rej = _proposalController.DeclineProposal(_proposalController.ChooseProposal().ProposalId.Value);
                        if (rej)
                        {
                            MessageHandler.PressAnyKey("Proposta rejeitada com sucesso.");
                        }else{
                            MessageHandler.PressAnyKey("Erro ao rejeitar proposta.");
                        }
                    }
                    break;
                case "4":
                    // Ver propostas por cliente
                    _proposalController.SeeProposalsByClient(client);
                    break;
                case "5":
                    // Marcar visita
                    var allProperties = _propertyService.GetAllProperties();
                    PropertyView.DisplayAllProperties(allProperties);
                    Property? property = _propertyController.ChooseProperty();

                    if (property == null){
                        MessageHandler.PressAnyKey("Nenhuma propriedade encontrada.");
                        break;
                    }
                    DateTime date = _visitsController.ChooseDate();
                    if(date == null){
                        MessageHandler.PressAnyKey("Data inválida.");
                        break;
                    }
                    if(_visitsController.MakeVisit(property, client, date))
                    {
                        MessageHandler.PressAnyKey("Visita marcada com sucesso.");
                        break;
                    }else{
                        MessageHandler.PressAnyKey("Erro ao marcar visita.");
                    }
                    break;
                case "6":
                    // Fazer pagamento
                    Transactions? transaction = _transactionController.ChooseTransaction();
                    if(transaction == null)
                    {
                        MessageHandler.PressAnyKey("Transação não encontrada.");
                    }else
                    {
                        if(_paymentController.MakePayment(transaction))
                        {
                            MessageHandler.PressAnyKey("Pagamento efetuado com sucesso.");
                        }else
                        {
                            MessageHandler.PressAnyKey("Pagamento falhou.");
                        }
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