using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Interfaces;

public interface IUserService
{
    IEnumerable<User> GetAllUsers();
    User GetUserById(int id);
    User CreateUser(string username, string password, string name, UserRole role);
}
