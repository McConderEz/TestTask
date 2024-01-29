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
            openFilesDialog.Filter = "XML Files (*.xml)|*.xml|CSV Files (*.csv)|*.csv";

            if (openFilesDialog.ShowDialog() == DialogResult.OK)
            {
                string[] filePaths = openFilesDialog.FileNames;
                controller.Add(filePaths);//TODO:������� ��� ���� ����������
            }
        }

        private void GenerateReport_Click(object sender, EventArgs e)
        {

        }

        //TODO: ��� �������� ���� � ��������� ������ ������������ ����� ����������
        //��� �������� � ������������ ������ ��� ���������� ������ ����������� ������� 
        //��� �������� ������ ������ �� xml � csv ������������ ��������� ������

    }
}
