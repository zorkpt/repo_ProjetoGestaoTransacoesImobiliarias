using ProjetoTransacoesImobiliarias.Controllers;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Models;
using ProjetoTransacoesImobiliarias.Services;

namespace TransacoesImobiliariasWinForms
{
    public partial class LoginForm : Form
    {
        public FormsController _formController;
        public PaymentController _paymentController;

        public LoginForm()
        {
            InitializeComponent();
            LoginButton.MouseMove += LoginButton_MouseMove;
            UserNameTex.TextChanged += UserNameText_TextChanged;
            PasswordTxt.TextChanged += PasswordTxt_TextChanged;
            _formController = new FormsController();
        }



        private void LoginButton_Click(object sender, EventArgs e)
        {

            
            User user = _formController.StartLoginProcess(UserNameTex.Text, PasswordTxt.Text, "sql");
            if (user == null)
            {
                MessageBox.Show("user nulo");
                return;
            }
            _formController.Start(user, this);


        }

        private void LoginButton_MouseMove(object sender, EventArgs e)
        {
            if (UserNameTex.Text == "" || PasswordTxt.Text == "")
            {
                LoginButton.Location = new Point(LoginButton.Location.X + 20, LoginButton.Location.Y + 20);
            }
        }

        private void UserNameText_TextChanged(object sender, EventArgs e)
        {
            LoginButton.Location = new Point(135, 106);
        }
        private void PasswordTxt_TextChanged(object sender, EventArgs e)
        {
            LoginButton.Location = new Point(135, 106);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
