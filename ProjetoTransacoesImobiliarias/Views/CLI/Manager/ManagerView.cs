using System;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias.Views;

public class ManagerView
{

    public static void ShowManagerMenu(Manager manager)
    {
        Console.WriteLine("Menu de Gestão");
        Console.WriteLine($"Bem-Vindo {manager.Username} com id {manager.Id}");
    }


}