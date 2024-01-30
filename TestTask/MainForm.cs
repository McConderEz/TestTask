using System.Windows.Forms;
using TestTask.Controller;

namespace TestTask
{
    public partial class MainForm : Form
    {
        readonly ReportController controller;
        string dirPath = "";
        string resultFilePath = "";
        public MainForm()
        {
            InitializeComponent();
            controller = new ReportController();
        }

        //private void LoadFiles_Click(object sender, EventArgs e)
        //{
        //    using (var openFilesDialog = new OpenFileDialog())
        //    {
        //        openFilesDialog.Filter = "XML and CSV Files (*.xml;*.csv)|*.xml;*.csv";
        //        openFilesDialog.Multiselect = true;
        //        if (openFilesDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            string[] filePaths = openFilesDialog.FileNames;
        //            controller.Add(filePaths);
        //            controller.GetData();
        //        }
        //    }
        //}

        private void GenerateReport_Click(object sender, EventArgs e)
        {
            SearchingFiles(dirPath);
            if(!string.IsNullOrWhiteSpace(resultFilePath))
            {
                controller.GenerateReport(resultFilePath);
            }
        }

        private void GenerateReport_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void SelectDirButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    dirPath = dialog.SelectedPath;
                }
            }
        }

        private void SearchingFiles(string dirPath)
        {
            string[] files = Directory.GetFiles(dirPath);

            string[] filePaths = Array.FindAll(files, file => file.ToLower().EndsWith(".xml") || file.ToLower().EndsWith(".csv"));

            controller.Add(filePaths);
            controller.GetData();
        }

        private void resFilePathButton_Click(object sender, EventArgs e)
        {
            using (var saveResultFileDiaglog = new SaveFileDialog())
            {
                saveResultFileDiaglog.DefaultExt = "json";
                saveResultFileDiaglog.Filter = "JSON Files (*.json)|*.json";
                var result = saveResultFileDiaglog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(saveResultFileDiaglog.FileName))
                {
                    resultFilePath = saveResultFileDiaglog.FileName;
                }
            }
        }
    }
}
