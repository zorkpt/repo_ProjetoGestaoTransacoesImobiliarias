using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Models;

namespace ProjetoTransacoesImobiliarias.Controllers
{
    public class AgentController : UserController
    {
        Agent Agent1;

        public AgentController(Agent agent)
        {
            Agent1 = agent;
        }
    }
}