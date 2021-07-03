using CMS.BL.Services.Interface;
using CMS.WinformUI.Utils;
using System;
using System.Windows.Forms;

namespace CMS
{
    public partial class Login : Form
    {
        private readonly IFormUtil _formUtil;
        private readonly IUserService _userService;

        public Login(IFormUtil formUtil, IUserService userService)
        {
            _formUtil = formUtil;
            _userService = userService;
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (_userService.AuthenticateUser(textBox_userName.Text, textBox_password.Text))
            {
                var main = _formUtil.GetForm<Main>();
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
            var register = _formUtil.GetForm<Register>();
            this.Hide();
            register.Show();
        }
    }
}
