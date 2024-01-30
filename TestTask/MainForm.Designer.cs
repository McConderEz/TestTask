
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
            openFilesDialog = new OpenFileDialog();
            GenerateReport = new Button();
            SelectDirButton = new Button();
            saveResultFileDialog = new SaveFileDialog();
            resFilePathButton = new Button();
            SuspendLayout();
            // 
            // GenerateReport
            // 
            GenerateReport.Location = new Point(269, 441);
            GenerateReport.Name = "GenerateReport";
            GenerateReport.Size = new Size(187, 23);
            GenerateReport.TabIndex = 1;
            GenerateReport.Text = "Сформировать отчёт";
            GenerateReport.UseVisualStyleBackColor = true;
            GenerateReport.EnabledChanged += GenerateReport_EnabledChanged;
            GenerateReport.Click += GenerateReport_Click;
            // 
            // SelectDirButton
            // 
            SelectDirButton.Location = new Point(12, 441);
            SelectDirButton.Name = "SelectDirButton";
            SelectDirButton.Size = new Size(205, 23);
            SelectDirButton.TabIndex = 2;
            SelectDirButton.Text = "Указать директорию для загрузки";
            SelectDirButton.UseVisualStyleBackColor = true;
            SelectDirButton.Click += SelectDirButton_Click;
            // 
            // resFilePathButton
            // 
            resFilePathButton.Location = new Point(269, 402);
            resFilePathButton.Name = "resFilePathButton";
            resFilePathButton.Size = new Size(187, 23);
            resFilePathButton.TabIndex = 3;
            resFilePathButton.Text = "Указать путь выходного файла";
            resFilePathButton.UseVisualStyleBackColor = true;
            resFilePathButton.Click += resFilePathButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 476);
            Controls.Add(resFilePathButton);
            Controls.Add(SelectDirButton);
            Controls.Add(GenerateReport);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
        }


        #endregion

        private Button LoadFilesButton;
        private Button SelectDirectoryButton;
        private Button GenerateReport;
        private Button LoadFiles;
        private OpenFileDialog openFilesDialog;
        private Button SelectDirButton;
        private SaveFileDialog saveResultFileDialog;
        private Button button1;
        private Button resFilePathButton;
    }
}
