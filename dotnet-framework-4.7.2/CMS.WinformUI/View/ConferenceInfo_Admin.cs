﻿using CMS.Library.Enums;
using CMS.Library.Service;
using System.Windows.Forms;

namespace CMS
{
    public partial class ConferenceInfo_Admin : Form
    {
        private readonly IUserService _userService;
        private readonly IPaperService _paperService;
        private readonly IConferenceService _conferenceService;

        public ConferenceInfo_Admin(IUserService userService, IPaperService paperService, IConferenceService conferenceService, int type)
        {
            _userService = userService;
            _paperService = paperService;
            _conferenceService = conferenceService;
            InitializeComponent();
            Init(type);
        }

        public void Init(int type)
        {
            switch (type)
            {
                case (int)ConferenceViewTypesEnum.ConferenceMembers:
                    dataGridView1.DataSource = _conferenceService.GetConferenceWithChair();
                    break;
                case (int)ConferenceViewTypesEnum.UserInfo:
                    dataGridView1.DataSource = _userService.GetUsersWithRole();
                    break;
                case (int)ConferenceViewTypesEnum.Papers:
                    dataGridView1.DataSource = _paperService.GetPapersWithAuthor();
                    break;
                default:
                    break;
            }
        }
    }
}
