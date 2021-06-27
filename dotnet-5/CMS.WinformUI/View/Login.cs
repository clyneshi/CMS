using CMS.Service.Service;
using CMS.WinformUI.Utils;
using Microsoft.Extensions.DependencyInjection;
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

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            var use = _userService.AuthenticateUser(textBox_userName.Text, textBox_passwrd.Text);

            if (use != null)
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
            var reg = _formUtil.GetForm<Register>();
            this.Hide();
            reg.Show();
        }
    }
}
