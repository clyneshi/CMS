﻿using CMS.DAL.Models;
using CMS.BL.Enums;
using CMS.BL.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CMS
{
    public partial class AccountSetting_R : Form
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IKeywordService _keywordService;
        private readonly IConferenceService _conferenceService;
        private readonly IApplicationStrategy _applicationStrategy;

        private readonly BindingList<Keyword> _selectedKeywords = new BindingList<Keyword>();
        private readonly List<Keyword> _removedKeywords = new List<Keyword>();

        public AccountSetting_R(IUserService userService,
            IRoleService roleService,
            IKeywordService keywordService,
            IConferenceService conferenceService,
            IApplicationStrategy applicationStrategy)
        {
            _userService = userService;
            _roleService = roleService;
            _keywordService = keywordService;
            _conferenceService = conferenceService;
            _applicationStrategy = applicationStrategy;

            InitializeComponent();
            Init();
        }

        public void Init()
        {
            InitForm();
            DisplayKeywords();
            DisplaySelectedKeywords();
        }

        private void DisplayKeywords()
        {
            var keywords = _keywordService.GetKeyWords();

            dataGridView_keyword.DataSource = keywords.ToList();
            dataGridView_keyword.Columns[0].Visible = false;
            dataGridView_keyword.Columns[3].Visible = false;
            dataGridView_keyword.Columns[4].Visible = false;
            dataGridView_keyword.Columns[5].Visible = false;
        }

        private void DisplaySelectedKeywords()
        {
            var expertises = _keywordService.GetExpertiseByUser(_applicationStrategy.GetLoggedInUserInfo().User.Id);

            foreach (var expertise in expertises)
            {
                _selectedKeywords.Add(new Keyword 
                { 
                    Id = expertise.KeywordId, 
                    Name = expertise.Keyword.Name 
                });
            }

            listBox_selectedKeywords.DataSource = _selectedKeywords;
            listBox_selectedKeywords.DisplayMember = "Name";
            listBox_selectedKeywords.ValueMember = "Id";
        }

        private void InitForm()
        {
            var currentUserInfo = _applicationStrategy.GetLoggedInUserInfo();

            textBox_name.Text = currentUserInfo.User.Name;
            textBox_email.Text = currentUserInfo.User.Email;
            textBox_contact.Text = currentUserInfo.User.Contact;
            comboBox_role.Text = _roleService.GetRoleById(currentUserInfo.User.RoleId).Type;

            if (currentUserInfo.User.RoleId == (int)RoleTypesEnum.Reviewer
                || currentUserInfo.User.RoleId == (int)RoleTypesEnum.Author)
                comboBox_conf.Text = _conferenceService.GetConferenceById(currentUserInfo.ConferenceId.Value).Title;
        }

        private void btn_addKeyword_Click(object sender, EventArgs e)
        {
            var index = dataGridView_keyword.CurrentRow.Index;
            var test = dataGridView_keyword.Rows[index];
            if (index >= 0)
            {
                var find = false;
                foreach (var keyword in _selectedKeywords)
                {
                    if (keyword.Id == (int)dataGridView_keyword.Rows[index].Cells["Id"].Value)
                        find = true;
                }
                if (!find)
                {
                    _selectedKeywords.Add(new Keyword
                    {
                        Id = (int)dataGridView_keyword.Rows[index].Cells["Id"].Value,
                        Name = (string)dataGridView_keyword.Rows[index].Cells["Name"].Value
                    });
                    listBox_selectedKeywords.SelectedIndex = listBox_selectedKeywords.Items.Count - 1;
                }
            }
        }

        private void btn_removeKeyword_Click(object sender, EventArgs e)
        {
            if (listBox_selectedKeywords.SelectedIndex >= 0)
            {
                _removedKeywords.Add(new Keyword { Id = (int)listBox_selectedKeywords.SelectedValue });
                _selectedKeywords.Remove((Keyword)listBox_selectedKeywords.SelectedItem);
            }
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            await _userService.UpdateUser(textBox_name.Text, textBox_email.Text, textBox_contact.Text, textBox_oldPassword.Text, textBox_newPassword.Text);
            await _keywordService.UpdateExpertise(_applicationStrategy.GetLoggedInUserInfo().User.Id, _removedKeywords, _selectedKeywords.ToList());
            MessageBox.Show("Update completed");
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
