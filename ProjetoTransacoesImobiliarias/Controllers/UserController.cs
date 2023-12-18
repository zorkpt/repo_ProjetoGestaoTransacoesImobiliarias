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

    /// <summary>
    /// Edits a client.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Lists all clients.
    /// </summary>
    /// <param name="clients"></param>
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

    /// <summary>
    /// Lists all users.
    /// </summary>
    /// <param name="userService"></param>
    protected void ListAllUsers(IUserService userService)
    {
        var allUsers = userService.GetAllUsers();
        UserView.DisplayUsers(allUsers);
    }

    /// <summary>
    /// Adds a user.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Deletes a user.
    /// </summary>
    /// <returns></returns>
    protected bool DeleteUser()
    {
        var user = ChooseUser();
        if (user == null)
        {
            return false;
        }else
        {
            bool apagar = _userService.DeleteUser(user);
            if (apagar) return true;
            return false;
        }

    }

    /// <summary>
    /// Chooses a user.
    /// </summary>
    /// <returns></returns>
    protected virtual User ChooseUser()
    {
            string userName = UserView.ChooseUserNameView();
            if (string.IsNullOrEmpty(userName))
            {
                MessageHandler.PressAnyKey("Pf inserir um nome valido");
            }
            var user = _userService.GetUserByUsername(userName);

            if (user != null)
            {
                return user;
            }else
            {
                return null;
            }
    }

    /// <summary>
    /// Chooses a client.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Manage client options.
    /// </summary>
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
                    //Cancelar proposta
                    Proposal? proposal2 = _proposalController.ChooseProposal();
                    if(proposal2 == null) break;

                    if(proposal2.Property.ClientId == client.Id)// comentar se necessario testar
                    {
                        MessageHandler.PressAnyKey("O Proprietário da propriedade não pode cancelar esta proposta");
                        break;
                    }else 
                    {
                        _proposalController.DeclineProposal(proposal2.ProposalId.Value);
                        MessageHandler.PressAnyKey("Proposta cancelada com sucesso.");
                    }

                    break;
                case "3":
                    // Ver propostas feitas por este cliente
                    _proposalController.SeeProposalsByClient(client);
                    break;
                case "4":
                    // Aprovar proposta
                    Proposal? proposal = _proposalController.ChooseProposal();
                    if(proposal == null) break;

                    if(proposal.Property.ClientId != client.Id)// comentar se necessario testar
                    {
                        MessageHandler.PressAnyKey("A propriedade da proposta não pertence a este cliente");
                        break;
                    }else 
                    {
                        //é dono, pode aceitar
                        _proposalController.AcceptProposal(proposal.ProposalId.Value);
                        _transactionController.AddTransaction(proposal);
                        MessageHandler.PressAnyKey("Proposta aprovada com sucesso.");
                    }
                        #region Apenas para testes, aceita proposta mesmo que nao seja o dono
                        // _proposalController.AcceptProposal(proposal.ProposalId.Value);
                        // _transactionController.AddTransaction(proposal);
                        // MessageHandler.PressAnyKey("Proposta aprovada com sucesso.");
                        #endregion

                    break;
                case "5":
                    // Rejeitar proposta
                    Proposal? proposal1 = _proposalController.ChooseProposal();
                    if(proposal1 == null) break;
                    if(proposal1.Property.ClientId != client.Id)// Se não for o dono (comentar se necessario testar)
                    {
                        MessageHandler.PressAnyKey("A propriedade da proposta não pertence a este cliente");
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
                case "6":
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
                case "7":
                    // Fazer pagamento (Não permite pagamentos parciais, vale a pena ??)
                    Transactions? transaction = _transactionController.ChooseTransaction();
                    
                    if(transaction == null)
                    {
                        MessageHandler.PressAnyKey("Transação não encontrada.");
                    }else
                    {
                        if(transaction.proposal.Client.Id != client.Id) {
                            MessageHandler.PressAnyKey("Esta transação não pertence a este cliente");
                            break;
                        }

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

    /// <summary>
    /// Adds a property.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
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