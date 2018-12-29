namespace Microstar.Production.View
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Microstar.Production.PCBTest.CurrentRating currentRating1 = new Microstar.Production.PCBTest.CurrentRating();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionalCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onAnalogVolCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onThreeVolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onAVolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.on5VolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.on12VolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.open485ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSecondsSignalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.moreCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.startTestButton = new System.Windows.Forms.Button();
            this.pnlPassNum = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.meterNumberTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.runningItemtoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.testInterface1 = new Microstar.Production.PCBTest.TestInterface();
            this.landing1 = new Microstar.Production.PCBTest.Controls.Landing();
            this.menuStrip1.SuspendLayout();
            this.pnlPassNum.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.additionalCommandToolStripMenuItem,
            this.userManagementToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.printToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            resources.ApplyResources(this.printToolStripMenuItem, "printToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialSettingsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            // 
            // serialSettingsToolStripMenuItem
            // 
            this.serialSettingsToolStripMenuItem.Name = "serialSettingsToolStripMenuItem";
            resources.ApplyResources(this.serialSettingsToolStripMenuItem, "serialSettingsToolStripMenuItem");
            this.serialSettingsToolStripMenuItem.Click += new System.EventHandler(this.serialSettingsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // additionalCommandToolStripMenuItem
            // 
            this.additionalCommandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onAnalogVolCurrentToolStripMenuItem,
            this.onThreeVolToolStripMenuItem,
            this.onAVolToolStripMenuItem,
            this.on5VolToolStripMenuItem,
            this.on12VolToolStripMenuItem,
            this.open485ToolStripMenuItem,
            this.openSecondsSignalToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.toolStripSeparator1,
            this.moreCommandToolStripMenuItem});
            this.additionalCommandToolStripMenuItem.Name = "additionalCommandToolStripMenuItem";
            resources.ApplyResources(this.additionalCommandToolStripMenuItem, "additionalCommandToolStripMenuItem");
            // 
            // onAnalogVolCurrentToolStripMenuItem
            // 
            resources.ApplyResources(this.onAnalogVolCurrentToolStripMenuItem, "onAnalogVolCurrentToolStripMenuItem");
            this.onAnalogVolCurrentToolStripMenuItem.Name = "onAnalogVolCurrentToolStripMenuItem";
            this.onAnalogVolCurrentToolStripMenuItem.Click += new System.EventHandler(this.onAnalogVolCurrentToolStripMenuItem_Click);
            // 
            // onThreeVolToolStripMenuItem
            // 
            this.onThreeVolToolStripMenuItem.Name = "onThreeVolToolStripMenuItem";
            resources.ApplyResources(this.onThreeVolToolStripMenuItem, "onThreeVolToolStripMenuItem");
            // 
            // onAVolToolStripMenuItem
            // 
            this.onAVolToolStripMenuItem.Name = "onAVolToolStripMenuItem";
            resources.ApplyResources(this.onAVolToolStripMenuItem, "onAVolToolStripMenuItem");
            // 
            // on5VolToolStripMenuItem
            // 
            this.on5VolToolStripMenuItem.Name = "on5VolToolStripMenuItem";
            resources.ApplyResources(this.on5VolToolStripMenuItem, "on5VolToolStripMenuItem");
            this.on5VolToolStripMenuItem.Click += new System.EventHandler(this.on5VolToolStripMenuItem_Click);
            // 
            // on12VolToolStripMenuItem
            // 
            this.on12VolToolStripMenuItem.Name = "on12VolToolStripMenuItem";
            resources.ApplyResources(this.on12VolToolStripMenuItem, "on12VolToolStripMenuItem");
            // 
            // open485ToolStripMenuItem
            // 
            this.open485ToolStripMenuItem.Name = "open485ToolStripMenuItem";
            resources.ApplyResources(this.open485ToolStripMenuItem, "open485ToolStripMenuItem");
            this.open485ToolStripMenuItem.Click += new System.EventHandler(this.open485ToolStripMenuItem_Click);
            // 
            // openSecondsSignalToolStripMenuItem
            // 
            this.openSecondsSignalToolStripMenuItem.Name = "openSecondsSignalToolStripMenuItem";
            resources.ApplyResources(this.openSecondsSignalToolStripMenuItem, "openSecondsSignalToolStripMenuItem");
            this.openSecondsSignalToolStripMenuItem.Click += new System.EventHandler(this.openSecondsSignalToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resources.ApplyResources(this.resetToolStripMenuItem, "resetToolStripMenuItem");
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // moreCommandToolStripMenuItem
            // 
            this.moreCommandToolStripMenuItem.Name = "moreCommandToolStripMenuItem";
            resources.ApplyResources(this.moreCommandToolStripMenuItem, "moreCommandToolStripMenuItem");
            this.moreCommandToolStripMenuItem.Click += new System.EventHandler(this.moreCommandToolStripMenuItem_Click);
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            resources.ApplyResources(this.userManagementToolStripMenuItem, "userManagementToolStripMenuItem");
            this.userManagementToolStripMenuItem.Click += new System.EventHandler(this.userManagementToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            resources.ApplyResources(this.databaseToolStripMenuItem, "databaseToolStripMenuItem");
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // nextButton
            // 
            resources.ApplyResources(this.nextButton, "nextButton");
            this.nextButton.Name = "nextButton";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.nextButton_MouseDown);
            // 
            // forwardButton
            // 
            resources.ApplyResources(this.forwardButton, "forwardButton");
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // startTestButton
            // 
            resources.ApplyResources(this.startTestButton, "startTestButton");
            this.startTestButton.Name = "startTestButton";
            this.startTestButton.UseVisualStyleBackColor = true;
            this.startTestButton.Click += new System.EventHandler(this.btnStartCheck_Click);
            // 
            // pnlPassNum
            // 
            resources.ApplyResources(this.pnlPassNum, "pnlPassNum");
            this.pnlPassNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPassNum.Controls.Add(this.label13);
            this.pnlPassNum.Controls.Add(this.label12);
            this.pnlPassNum.Controls.Add(this.label11);
            this.pnlPassNum.Controls.Add(this.label10);
            this.pnlPassNum.Controls.Add(this.label9);
            this.pnlPassNum.Controls.Add(this.label8);
            this.pnlPassNum.Name = "pnlPassNum";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Name = "label8";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = " ";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // meterNumberTextBox
            // 
            resources.ApplyResources(this.meterNumberTextBox, "meterNumberTextBox");
            this.meterNumberTextBox.Name = "meterNumberTextBox";
            this.meterNumberTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.meterNumberTextBox_KeyDown);
            this.meterNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.meterNumberTextBox_KeyPress);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runningItemtoolStripStatusLabel});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // runningItemtoolStripStatusLabel
            // 
            resources.ApplyResources(this.runningItemtoolStripStatusLabel, "runningItemtoolStripStatusLabel");
            this.runningItemtoolStripStatusLabel.ForeColor = System.Drawing.Color.Blue;
            this.runningItemtoolStripStatusLabel.Name = "runningItemtoolStripStatusLabel";
            // 
            // testInterface1
            // 
            this.testInterface1.BaudRate = 9600;
            this.testInterface1.Current = "";
            this.testInterface1.CustomerCode = "";
            resources.ApplyResources(this.testInterface1, "testInterface1");
            this.testInterface1.MeterNumberAutoIncrement = true;
            this.testInterface1.Name = "testInterface1";
            this.testInterface1.Voltage = new decimal(new int[] {
            220,
            0,
            0,
            0});
            // 
            // landing1
            // 
            this.landing1.BaudRate = 9600;
            currentRating1.Ib = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            currentRating1.Imax = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            this.landing1.Current = currentRating1;
            this.landing1.CustomerCode = "";
            resources.ApplyResources(this.landing1, "landing1");
            this.landing1.MeterNumberAllowAlphabetic = false;
            this.landing1.MeterNumberDigits = 8;
            this.landing1.MeterPassword = "666666";
            this.landing1.MeterType = Microstar.Production.PCBTest.ConnectionType.SinglePhase;
            this.landing1.Name = "landing1";
            this.landing1.Protocol = Microstar.Production.PCBTest.MeterProtocol.IEC62056_21;
            this.landing1.TestItemID = 0;
            this.landing1.Voltage = new decimal(new int[] {
            220,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.landing1);
            this.Controls.Add(this.meterNumberTextBox);
            this.Controls.Add(this.testInterface1);
            this.Controls.Add(this.pnlPassNum);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.startTestButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.nextButton);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlPassNum.ResumeLayout(false);
            this.pnlPassNum.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem additionalCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onThreeVolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onAVolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem on5VolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem on12VolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem open485ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSecondsSignalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem moreCommandToolStripMenuItem;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button startTestButton;
        private System.Windows.Forms.Panel pnlPassNum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.TextBox meterNumberTextBox;
        private System.Windows.Forms.ToolStripMenuItem onAnalogVolCurrentToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private PCBTest.TestInterface testInterface1;
        private System.Windows.Forms.ToolStripStatusLabel runningItemtoolStripStatusLabel;
        private PCBTest.Controls.Landing landing1;
    }
}