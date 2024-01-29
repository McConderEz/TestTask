
namespace TestTask
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoadFiles = new Button();
            openFilesDialog = new OpenFileDialog();
            GenerateReport = new Button();
            SuspendLayout();
            // 
            // LoadFiles
            // 
            LoadFiles.Location = new Point(12, 441);
            LoadFiles.Name = "LoadFiles";
            LoadFiles.Size = new Size(125, 23);
            LoadFiles.TabIndex = 0;
            LoadFiles.Text = "Загрузить файлы";
            LoadFiles.UseVisualStyleBackColor = true;
            LoadFiles.Click += LoadFiles_Click;
            // 
            // openFilesDialog
            // 
            openFilesDialog.FileName = "openFileDialog1";
            openFilesDialog.Multiselect = true;
            // 
            // GenerateReport
            // 
            GenerateReport.Location = new Point(318, 441);
            GenerateReport.Name = "GenerateReport";
            GenerateReport.Size = new Size(138, 23);
            GenerateReport.TabIndex = 1;
            GenerateReport.Text = "Сформировать отчёт";
            GenerateReport.UseVisualStyleBackColor = true;
            GenerateReport.Click += GenerateReport_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 476);
            Controls.Add(GenerateReport);
            Controls.Add(LoadFiles);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }


        #endregion

        private Button LoadFilesButton;
        private Button SelectDirectoryButton;
        private Button GenerateReport;
        private Button LoadFiles;
        private OpenFileDialog openFilesDialog;
    }
}
