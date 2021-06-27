using CMS.Library.App_Start;
using CMS.Library.Service;
using System;
using System.Windows.Forms;
using Unity;

namespace CMS
{
    public partial class Login : Form
    {
        private readonly IUserService _userService;

        public Login(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            var use = _userService.AuthenticateUser(textBox_userName.Text, textBox_passwrd.Text);

            if (use != null)
            {
                Main main = new Main();
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("Incorrect user info!");
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            var reg = UnityConfig.UIContainer.Resolve<Register>();
            this.Hide();
            reg.Show();
        }
    }
}
