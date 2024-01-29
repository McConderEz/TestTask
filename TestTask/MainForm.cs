using System.Windows.Forms;
using TestTask.Controller;

namespace TestTask
{
    public partial class MainForm : Form
    {
        readonly ReportController controller;
        public MainForm()
        {
            InitializeComponent();
            controller = new ReportController();
        }

        private void LoadFiles_Click(object sender, EventArgs e)
        {
            var openFilesDialog = new OpenFileDialog();
            openFilesDialog.Filter = "XML and CSV Files (*.xml;*.csv)|*.xml;*.csv";
            openFilesDialog.Multiselect = true;

            if (openFilesDialog.ShowDialog() == DialogResult.OK)
            {
                string[] filePaths = openFilesDialog.FileNames;
                controller.Add(filePaths);
                controller.GetCards();
                controller.GetUsers();
            }
        }

        private void GenerateReport_Click(object sender, EventArgs e)
        {
            controller.GenerateReport();
        }

    }
}
