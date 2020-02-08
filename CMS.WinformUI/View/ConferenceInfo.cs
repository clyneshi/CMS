using CMS.Library.Global;
using CMS.Library.Service;
using System.Windows.Forms;

namespace CMS
{
    public partial class ConferenceInfo : Form
    {
        IPaperService _paperService;

        public ConferenceInfo(IPaperService paperService)
        {
            _paperService = paperService;
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            dataGridView1.DataSource = DataProcessor.GetReviewer();

            dataGridView2.DataSource = _paperService.GetPaperConferences();
        }
    }
}
