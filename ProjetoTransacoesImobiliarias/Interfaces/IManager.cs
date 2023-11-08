namespace ProjetoTransacoesImobiliarias.Models;

public interface IManager
{
    Client RegisterClient(string name, string adress, Manager b);
}
