using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Interfaces;

public interface IUserService
{
    IEnumerable<User> GetAllUsers();
}