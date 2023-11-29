using System;
using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Services;
using ProjetoTransacoesImobiliarias.Views.CLI;

namespace ProjetoTransacoesImobiliarias;

internal class Program
{
    private static UserService _userService;
    private static ServiceRepository _serviceRepository;

    private static void Main(string[] args)
    {
        _serviceRepository = new ServiceRepository();

        if (!_serviceRepository.StartServices())
        {
            Console.WriteLine("Não foi possível iniciar os serviços. A aplicação será encerrada.");
            return;
        }

        var user = _serviceRepository.AuthenticationService.StartLoginProcess();
        var appController = new AppController(_serviceRepository.UserService, _serviceRepository.ClientService, _serviceRepository.PropertyService);
        appController.Start(user);
    }
}