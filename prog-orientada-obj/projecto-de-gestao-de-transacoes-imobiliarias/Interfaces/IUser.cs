namespace Projeto_de_Gestao_de_Transacoes_Imobiliarias.Interfaces;

public interface IUser
{
    int Id { get; set; }
    string Username { get; set; }
    string Password { get; set; }
}