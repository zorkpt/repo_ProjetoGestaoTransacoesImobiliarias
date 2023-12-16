using ProjetoTransacoesImobiliarias;
using ProjetoTransacoesImobiliarias.Services;
namespace TransacoesImobiliariasWinForms
{
    internal static class Program
    {

        private static UserService _userService;
        private static ServiceRepository _serviceRepository;


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}