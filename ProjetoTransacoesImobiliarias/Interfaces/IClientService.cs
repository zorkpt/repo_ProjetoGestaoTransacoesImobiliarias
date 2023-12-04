using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI.Client;

namespace ProjetoTransacoesImobiliarias.Interfaces;

public interface IClientService
{
    IEnumerable<Client> GetAllClients();
    Client GetClientById(int id);
    Client CreateClient(string name, string address, string phoneNumber, User addedBy);
    bool SaveClientsToJson();
    Client AddClient(ClientView.ClientData clientData, User user);
}
