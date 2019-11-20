using CMSLibrary.Global;
using System.Windows.Forms;

namespace CMS
{
    public partial class ConferenceInfo : Form
    {

        public ConferenceInfo()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            dataGridView1.DataSource = DataProcessor.GetReviewer();

            dataGridView2.DataSource = DataProcessor.GetPaperConferences();
        }
    }
}
