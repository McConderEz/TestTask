using System.Windows.Forms;
using TestTask.Controller;

namespace TestTask
{
    public partial class MainForm : Form
    {
        private HashSet<string> processedFiles = new HashSet<string>();
        readonly ReportController controller;
        string dirPath = "";
        string resultFilePath = "";
        public MainForm()
        {
            InitializeComponent();
            controller = new ReportController();
            controller.ReportReady += ControllerReportReadyHandler;
            GenerateReport.Enabled = false;
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
                     
            if(!string.IsNullOrWhiteSpace(resultFilePath))
            {
                Invoke((MethodInvoker)delegate
                {
                    controller.GenerateReport(resultFilePath);
                    GenerateReport.Enabled = false;
                });
            }
        }

        private void GenerateReport_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private async void SelectDirButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    dirPath = dialog.SelectedPath;
                    await SearchingFiles(dirPath);
                }
            }
        }

        private async Task SearchingFiles(string dirPath)
        {
            while (true)
            {
                await Task.Run(() =>
                {
                    string[] files = Directory.GetFiles(dirPath);

                    string[] filePaths = Array.FindAll(files, file => file.ToLower().EndsWith(".xml") || file.ToLower().EndsWith(".csv"));

                    List<string> newFiles = new List<string>();

                    foreach(string filePath in filePaths)
                    {
                        if (!processedFiles.Contains(filePath))
                        {
                            newFiles.Add(filePath);
                            processedFiles.Add(filePath);
                        }
                    }

                    if (newFiles.Count > 0)
                    {
                        controller.Add(newFiles.ToArray());
                        controller.GetData();
                        controller.SearchingData();
                    }
                });
            }
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

        private void ControllerReportReadyHandler(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                GenerateReport.Enabled = true;
            });
        }
    }
}
