using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Views;
using ProjetoTransacoesImobiliarias.Views.CLI;


namespace ProjetoTransacoesImobiliarias.Controllers
{
  

    public class UserController
    {
        private readonly IUserService _userService;
        private readonly IClientService _clientService;
        private readonly User _user;
        private readonly IPropertyService _propertyService;
        
        public UserController(User user, IUserService userService, IClientService clientService, IPropertyService propertyService)
        {
            _user = user;
            _userService = userService;
            _clientService = clientService;
            _propertyService = propertyService;
        }

    }
}