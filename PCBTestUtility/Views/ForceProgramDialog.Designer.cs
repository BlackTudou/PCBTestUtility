namespace Microstar.Production.View
{
    partial class ForceProgramDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForceProgramDialog));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.binSourceFileTextBox = new System.Windows.Forms.TextBox();
            this.readFlashDataTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.startTransmitButton = new System.Windows.Forms.Button();
            this.startCompareButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.stopTransmitButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkSumlabel = new System.Windows.Forms.Label();
            this.save256Button = new System.Windows.Forms.Button();
            this.save512Button = new System.Windows.Forms.Button();
            this.readLengthComboBox = new System.Windows.Forms.ComboBox();
            this.chipSelectComboBox = new System.Windows.Forms.ComboBox();
            this.readLengthLabel = new System.Windows.Forms.Label();
            this.chipSelectLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.transmitForceProgram = new Microstar.Production.PCBTest.ForceProgram();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.forceProgram1 = new Microstar.Production.PCBTest.ForceProgram();
            this.openFilebutton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.framesInformationTextBox = new System.Windows.Forms.TextBox();
            this.fileTransmitInfoLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.transmitProgressBar = new System.Windows.Forms.ProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.writeSpiBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.readSpiBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.binSourceFileTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.readFlashDataTextBox);
            // 
            // binSourceFileTextBox
            // 
            resources.ApplyResources(this.binSourceFileTextBox, "binSourceFileTextBox");
            this.binSourceFileTextBox.Name = "binSourceFileTextBox";
            this.binSourceFileTextBox.ReadOnly = true;
            // 
            // readFlashDataTextBox
            // 
            resources.ApplyResources(this.readFlashDataTextBox, "readFlashDataTextBox");
            this.readFlashDataTextBox.Name = "readFlashDataTextBox";
            this.readFlashDataTextBox.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.fileNameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            resources.ApplyResources(this.fileNameTextBox, "fileNameTextBox");
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.ReadOnly = true;
            // 
            // startTransmitButton
            // 
            resources.ApplyResources(this.startTransmitButton, "startTransmitButton");
            this.startTransmitButton.Name = "startTransmitButton";
            this.startTransmitButton.UseVisualStyleBackColor = true;
            this.startTransmitButton.Click += new System.EventHandler(this.transmitButton_Click);
            // 
            // startCompareButton
            // 
            resources.ApplyResources(this.startCompareButton, "startCompareButton");
            this.startCompareButton.Name = "startCompareButton";
            this.startCompareButton.UseVisualStyleBackColor = true;
            this.startCompareButton.Click += new System.EventHandler(this.startCompareButton_Click);
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Name = "label13";
            // 
            // stopTransmitButton
            // 
            resources.ApplyResources(this.stopTransmitButton, "stopTransmitButton");
            this.stopTransmitButton.Name = "stopTransmitButton";
            this.stopTransmitButton.UseVisualStyleBackColor = true;
            this.stopTransmitButton.Click += new System.EventHandler(this.stopTransmitButton_Click);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Name = "label14";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.checkSumlabel);
            this.panel1.Controls.Add(this.save256Button);
            this.panel1.Controls.Add(this.save512Button);
            this.panel1.Controls.Add(this.readLengthComboBox);
            this.panel1.Controls.Add(this.chipSelectComboBox);
            this.panel1.Controls.Add(this.readLengthLabel);
            this.panel1.Controls.Add(this.chipSelectLabel);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.fileNameTextBox);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Controls.Add(this.openFilebutton);
            this.panel1.Controls.Add(this.startCompareButton);
            this.panel1.Controls.Add(this.stopTransmitButton);
            this.panel1.Controls.Add(this.startTransmitButton);
            this.panel1.Name = "panel1";
            // 
            // checkSumlabel
            // 
            resources.ApplyResources(this.checkSumlabel, "checkSumlabel");
            this.checkSumlabel.BackColor = System.Drawing.Color.LightGreen;
            this.checkSumlabel.ForeColor = System.Drawing.Color.Red;
            this.checkSumlabel.Name = "checkSumlabel";
            // 
            // save256Button
            // 
            resources.ApplyResources(this.save256Button, "save256Button");
            this.save256Button.Name = "save256Button";
            this.save256Button.UseVisualStyleBackColor = true;
            // 
            // save512Button
            // 
            resources.ApplyResources(this.save512Button, "save512Button");
            this.save512Button.Name = "save512Button";
            this.save512Button.UseVisualStyleBackColor = true;
            // 
            // readLengthComboBox
            // 
            this.readLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.readLengthComboBox.FormattingEnabled = true;
            this.readLengthComboBox.Items.AddRange(new object[] {
            resources.GetString("readLengthComboBox.Items"),
            resources.GetString("readLengthComboBox.Items1")});
            resources.ApplyResources(this.readLengthComboBox, "readLengthComboBox");
            this.readLengthComboBox.Name = "readLengthComboBox";
            // 
            // chipSelectComboBox
            // 
            this.chipSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chipSelectComboBox.FormattingEnabled = true;
            this.chipSelectComboBox.Items.AddRange(new object[] {
            resources.GetString("chipSelectComboBox.Items"),
            resources.GetString("chipSelectComboBox.Items1"),
            resources.GetString("chipSelectComboBox.Items2"),
            resources.GetString("chipSelectComboBox.Items3"),
            resources.GetString("chipSelectComboBox.Items4"),
            resources.GetString("chipSelectComboBox.Items5"),
            resources.GetString("chipSelectComboBox.Items6"),
            resources.GetString("chipSelectComboBox.Items7")});
            resources.ApplyResources(this.chipSelectComboBox, "chipSelectComboBox");
            this.chipSelectComboBox.Name = "chipSelectComboBox";
            // 
            // readLengthLabel
            // 
            resources.ApplyResources(this.readLengthLabel, "readLengthLabel");
            this.readLengthLabel.Name = "readLengthLabel";
            // 
            // chipSelectLabel
            // 
            resources.ApplyResources(this.chipSelectLabel, "chipSelectLabel");
            this.chipSelectLabel.Name = "chipSelectLabel";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.transmitForceProgram);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // transmitForceProgram
            // 
            this.transmitForceProgram.CheckSum = "";
            this.transmitForceProgram.CustomerCode = "";
            resources.ApplyResources(this.transmitForceProgram, "transmitForceProgram");
            this.transmitForceProgram.MeterType = Microstar.Production.PCBTest.ConnectionType.SinglePhase;
            this.transmitForceProgram.Name = "transmitForceProgram";
            this.transmitForceProgram.ProgramChip = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.forceProgram1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // forceProgram1
            // 
            this.forceProgram1.CheckSum = "";
            this.forceProgram1.CustomerCode = "";
            resources.ApplyResources(this.forceProgram1, "forceProgram1");
            this.forceProgram1.MeterType = Microstar.Production.PCBTest.ConnectionType.SinglePhase;
            this.forceProgram1.Name = "forceProgram1";
            this.forceProgram1.ProgramChip = 1;
            // 
            // openFilebutton
            // 
            this.openFilebutton.Image = global::Microstar.Production.PCBTest.Properties.Resources.folder_document;
            resources.ApplyResources(this.openFilebutton, "openFilebutton");
            this.openFilebutton.Name = "openFilebutton";
            this.openFilebutton.UseVisualStyleBackColor = true;
            this.openFilebutton.Click += new System.EventHandler(this.openFilebutton_Click);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.framesInformationTextBox);
            this.panel2.Name = "panel2";
            // 
            // framesInformationTextBox
            // 
            resources.ApplyResources(this.framesInformationTextBox, "framesInformationTextBox");
            this.framesInformationTextBox.Name = "framesInformationTextBox";
            // 
            // fileTransmitInfoLabel
            // 
            resources.ApplyResources(this.fileTransmitInfoLabel, "fileTransmitInfoLabel");
            this.fileTransmitInfoLabel.ForeColor = System.Drawing.Color.Red;
            this.fileTransmitInfoLabel.Name = "fileTransmitInfoLabel";
            // 
            // panel5
            // 
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.transmitProgressBar);
            this.panel5.Name = "panel5";
            // 
            // transmitProgressBar
            // 
            resources.ApplyResources(this.transmitProgressBar, "transmitProgressBar");
            this.transmitProgressBar.Name = "transmitProgressBar";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // writeSpiBackgroundWorker
            // 
            this.writeSpiBackgroundWorker.WorkerReportsProgress = true;
            this.writeSpiBackgroundWorker.WorkerSupportsCancellation = true;
            this.writeSpiBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.writeSpiBackgroundWorker_DoWork);
            this.writeSpiBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.writeSpiBackgroundWorker_ProgressChanged);
            this.writeSpiBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.writeSpiBackgroundWorker_RunWorkerCompleted);
            // 
            // readSpiBackgroundWorker
            // 
            this.readSpiBackgroundWorker.WorkerReportsProgress = true;
            this.readSpiBackgroundWorker.WorkerSupportsCancellation = true;
            this.readSpiBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.readSpiBackgroundWorker_DoWork);
            this.readSpiBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.readSpiBackgroundWorker_ProgressChanged);
            this.readSpiBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.readSpiBackgroundWorker_RunWorkerCompleted);
            // 
            // ForceProgramDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.fileTransmitInfoLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ForceProgramDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ForceProgramDialog_FormClosing);
            this.Load += new System.EventHandler(this.ForceProgramForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Button openFilebutton;
        private System.Windows.Forms.Button startTransmitButton;
        private System.Windows.Forms.Button startCompareButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button stopTransmitButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label fileTransmitInfoLabel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox binSourceFileTextBox;
        private System.Windows.Forms.TextBox readFlashDataTextBox;
        private System.Windows.Forms.TextBox framesInformationTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private PCBTest.ForceProgram transmitForceProgram;
        private PCBTest.ForceProgram forceProgram1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label chipSelectLabel;
        private System.Windows.Forms.Label readLengthLabel;
        private System.Windows.Forms.ComboBox chipSelectComboBox;
        private System.Windows.Forms.ComboBox readLengthComboBox;
        private System.Windows.Forms.Button save512Button;
        private System.Windows.Forms.Button save256Button;
        private System.Windows.Forms.ProgressBar transmitProgressBar;
        private System.ComponentModel.BackgroundWorker writeSpiBackgroundWorker;
        private System.ComponentModel.BackgroundWorker readSpiBackgroundWorker;
        private System.Windows.Forms.Label checkSumlabel;
    }
}