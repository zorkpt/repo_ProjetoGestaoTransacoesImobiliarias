using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Interfaces;

public interface IClientService
{
    IEnumerable<Client> GetAllClients();
    Client CreateClient(string name, string address, string phoneNumber, User addedBy);
}
