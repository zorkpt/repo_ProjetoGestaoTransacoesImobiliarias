using System.Collections.Concurrent;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Services;
using ProjetoTransacoesImobiliarias.Views;
using ProjetoTransacoesImobiliarias.Views.CLI;
using ProjetoTransacoesImobiliarias.Views.CLI.Client;

namespace ProjetoTransacoesImobiliarias.Controllers;

public class AdminController
{
    private readonly IUserService _userService;
    private readonly IClientService _clientService;
    private readonly Admin _admin;
    private readonly IPropertyService _propertyService;
    private ProposalController proposalController;
    private TransactionController transactionController;
    private AdminView AdminView { get; set; }
    
    public AdminController(Admin admin, IUserService userService, IClientService clientService, IPropertyService propertyService)
    {
        _admin = admin;
        _userService = userService;
        _clientService = clientService;
        _propertyService = propertyService;
        proposalController = new ProposalController(); 
        transactionController = new TransactionController();
        AdminView = new AdminView();
    }

    /// <summary>
    /// Executes the menu functionality for the admin user.
    /// </summary>
    public void Menu()
    {
        var exitMenu = false;
        while (!exitMenu)
        {
            var option = AdminView.ShowAdminMenu(_admin);
            switch (option)
            {
                case "1":
                    SubMenuManageClients();
                    break;
                case "2":
                    SubMenuManageUsers();
                    break;
                case "3":
                    SubMenuManageTransactions();
                    break;
                case "4":
                    SubMenuManageProperties();
                    break;

                case "5":
                    ListClients(false);
                    break;
                case "6":
                    ListClients();
                    break;
                case "7":
                 //   AddClient();
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
            var option = AdminView.ManageClientsMenu();
            switch (option)
            {
                case "1":
                    var clientData = ClientView.AddClient();
                    _clientService.AddClient(clientData, _admin);
                    break;
                case "2":
                    EditClient();
                    break;
                case "3":
                    DeleteClient();
                    break;
                case "4":
                    ListClients(false);
                    break;
                case "5":
                    ListClients();
                    break;
                case "6":
                    ManageClientOptions();//novo
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
    /// Manages the submenu for user management.
    /// </summary>
    private void SubMenuManageUsers()
    {
        var exitMenu = false;
        while (!exitMenu)
        {
            var option = AdminView.ManageUsersMenu();
            switch (option)
            {
                case "1":
                    AddUser();
                    break;
                case "2":
                    // Editar User
                    break;
                case "3":
                    // Eliminar User
                    break;
                case "4":
                    ListAllUsers();
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

    private void SubMenuManageTransactions()
    {
        var exitMenu = false;
        while (!exitMenu)
        {
            var option = AdminView.ManageTransactionsMenu();
            switch (option)
            {
                case "1":
                    // Nova Visita
                    break;
                case "2":
                    // Nova transação
                    break;
                case "3":
                    // Editar Transação
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
    /// Manages the submenu for managing transactions.
    /// </summary>
    private void SubMenuManageProperties()
    {
        var exitMenu = false;
        while (!exitMenu)
        {
            var option = AdminView.ManagePropertiesMenu();
            switch (option)
            {
                case "1":
                    AddProperty();
                    break;
                case "2":
                    // Editar Propriedade
                    break;
                case "3":
                    // Eliminar Propriedade
                    break;
                case "4":
                    var allProperties = _propertyService.GetAllProperties();
                    PropertyView.DisplayAllProperties(allProperties);
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

    private Property? AddProperty()
    {
        var propertyData = AdminView.AddProperty();
        var client = _clientService.GetClientById(propertyData.ClientId);
        var newProperty =
            _propertyService.CreateProperty(propertyData.Address,
                propertyData.Description,
                propertyData.PropertyType,
                propertyData.Size,
                _admin,
              client);
      
        if (newProperty is null)
        {
            return null;
        }

        MessageHandler.PressAnyKey("Propriedade adicionada com sucesso.");
        _admin.AddProperty(newProperty);
        return newProperty;
    }

    /// <summary>
    /// Lists clients based on the specified criteria.
    /// </summary>
    /// <param name="all"></param>
    private void ListClients(bool all = true)
    {
        var clients = all ? _clientService.GetAllClients() : _admin.GetAdminClients();
        if (!clients.Any())
        {
            MessageHandler.PressAnyKey("Sem dados.");
        }
        else
        {
            AdminView.DisplayAllClients(clients);
        }
    }

    /// <summary>
    /// Lists all users.
    /// </summary>
    private void ListAllUsers()
    {
        var allUsers = _userService.GetAllUsers();
        AdminView.DisplayUsers(allUsers);
    }

    /// <summary>
    /// Edits a client and returns the modified client.
    /// </summary>
    /// <returns></returns>
    private Client? EditClient()
    {
        return null;
    }

    /// <summary>
    /// Deletes a client.
    /// </summary>
    /// <returns></returns>
    private Client? DeleteClient()
    {
        return null;
    }

    /// <summary>
    /// Adds a new user to the system.
    /// </summary>
    /// <returns></returns>
    private User AddUser()
    {
        var clientData = AdminView.AddUser();
        var newUser = _userService.CreateUser(clientData.Userame,
                                                        clientData.Password,
                                                        clientData.Name,
                                                        clientData.Role);

        MessageHandler.PressAnyKey("Utilizador Adicionado com sucesso.");
        return newUser;
    }


    public Client ChooseClient(){
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

    /// <summary>
    /// Manages a client. 
    /// </summary>
    public void ManageClientOptions()
    {
        
        Client client = ChooseClient();

        var exitMenu = false;
        while (!exitMenu)
        {
            AdminView.ManageClientOptionsView(client.Name);
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    //Fazer proposta
                    if(proposalController.MakeProposal(client.Id))
                    {
                        MessageHandler.PressAnyKey("Proposta enviada com sucesso.");
                    }
                    
                    //Proposal a = new Proposal(client, property, price);
                    break;
                case "2":
                    //Aprovar proposta
                    //escolher proposta a aprovar 
                    Proposal proposal = proposalController.ChooseProposal();
                    //aceitar proposta
                    proposalController.AcceptProposal(proposal.ProposalId.Value);
                    //Iniciar transação
                    transactionController.AddTransaction(proposal);
                    MessageHandler.PressAnyKey("Proposta aprovada com sucesso.");
                    break;
                case "3":
                    //Rejeitar proposta
                    Proposal proposal1 = proposalController.ChooseProposal();
                    bool a = proposalController.DeclineProposal(proposal1.ProposalId.Value);
                    MessageHandler.PressAnyKey("Proposta rejeitada com sucesso.");
                    break;
                case "4":
                    //Listar propostas
                    proposalController.SeeProposalsByClient(client);
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
}