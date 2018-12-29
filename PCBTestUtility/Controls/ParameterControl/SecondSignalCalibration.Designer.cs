namespace Microstar.Production.PCBTest.Controls
{
    partial class SecondSignalCalibration
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.headerGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lowerLimitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.upperLimitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.settingGroupBox = new System.Windows.Forms.GroupBox();
            this.activateSecondCheckBox = new System.Windows.Forms.CheckBox();
            this.secondsCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.secondsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.parityComboBox = new System.Windows.Forms.ComboBox();
            this.databitsComboBox = new System.Windows.Forms.ComboBox();
            this.baudRateComboBox = new System.Windows.Forms.ComboBox();
            this.comPortComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.delayTimeLabel = new System.Windows.Forms.Label();
            this.delayTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.headerGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitNumericUpDown)).BeginInit();
            this.settingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondsNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayTimeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupBox
            // 
            this.headerGroupBox.Controls.Add(this.groupBox2);
            this.headerGroupBox.Controls.Add(this.settingGroupBox);
            this.headerGroupBox.Controls.Add(this.groupBox1);
            this.headerGroupBox.Location = new System.Drawing.Point(1, 3);
            this.headerGroupBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.headerGroupBox.Name = "headerGroupBox";
            this.headerGroupBox.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.headerGroupBox.Size = new System.Drawing.Size(340, 417);
            this.headerGroupBox.TabIndex = 3;
            this.headerGroupBox.TabStop = false;
            this.headerGroupBox.Text = "Header";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lowerLimitNumericUpDown);
            this.groupBox2.Controls.Add(this.upperLimitNumericUpDown);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(1, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 63);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Error Range";
            // 
            // lowerLimitNumericUpDown
            // 
            this.lowerLimitNumericUpDown.DecimalPlaces = 1;
            this.lowerLimitNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.lowerLimitNumericUpDown.Location = new System.Drawing.Point(150, 13);
            this.lowerLimitNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.lowerLimitNumericUpDown.Name = "lowerLimitNumericUpDown";
            this.lowerLimitNumericUpDown.Size = new System.Drawing.Size(157, 21);
            this.lowerLimitNumericUpDown.TabIndex = 5;
            // 
            // upperLimitNumericUpDown
            // 
            this.upperLimitNumericUpDown.DecimalPlaces = 1;
            this.upperLimitNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.upperLimitNumericUpDown.Location = new System.Drawing.Point(150, 39);
            this.upperLimitNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.upperLimitNumericUpDown.Name = "upperLimitNumericUpDown";
            this.upperLimitNumericUpDown.Size = new System.Drawing.Size(157, 21);
            this.upperLimitNumericUpDown.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(22, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Upper limit：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(22, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Lower limit：";
            // 
            // settingGroupBox
            // 
            this.settingGroupBox.Controls.Add(this.delayTimeNumericUpDown);
            this.settingGroupBox.Controls.Add(this.delayTimeLabel);
            this.settingGroupBox.Controls.Add(this.activateSecondCheckBox);
            this.settingGroupBox.Controls.Add(this.secondsCheckBox);
            this.settingGroupBox.Controls.Add(this.label5);
            this.settingGroupBox.Controls.Add(this.secondsNumericUpDown);
            this.settingGroupBox.Location = new System.Drawing.Point(1, 17);
            this.settingGroupBox.Name = "settingGroupBox";
            this.settingGroupBox.Size = new System.Drawing.Size(338, 193);
            this.settingGroupBox.TabIndex = 6;
            this.settingGroupBox.TabStop = false;
            this.settingGroupBox.Text = "Settings";
            // 
            // activateSecondCheckBox
            // 
            this.activateSecondCheckBox.AutoSize = true;
            this.activateSecondCheckBox.Location = new System.Drawing.Point(16, 20);
            this.activateSecondCheckBox.Name = "activateSecondCheckBox";
            this.activateSecondCheckBox.Size = new System.Drawing.Size(261, 19);
            this.activateSecondCheckBox.TabIndex = 4;
            this.activateSecondCheckBox.Text = "Whether need to activate the second signal";
            this.activateSecondCheckBox.UseVisualStyleBackColor = true;
            // 
            // secondsCheckBox
            // 
            this.secondsCheckBox.Checked = true;
            this.secondsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.secondsCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.secondsCheckBox.Location = new System.Drawing.Point(16, 39);
            this.secondsCheckBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.secondsCheckBox.Name = "secondsCheckBox";
            this.secondsCheckBox.Size = new System.Drawing.Size(321, 40);
            this.secondsCheckBox.TabIndex = 0;
            this.secondsCheckBox.Text = "Whether to automatically compensate the signal when detecting the second signal";
            this.secondsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(16, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(319, 60);
            this.label5.TabIndex = 1;
            this.label5.Text = "The number of seconds the meter will test when detecting the second signal: (incl" +
    "uding no compensation is performed)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // secondsNumericUpDown
            // 
            this.secondsNumericUpDown.Location = new System.Drawing.Point(16, 168);
            this.secondsNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.secondsNumericUpDown.Name = "secondsNumericUpDown";
            this.secondsNumericUpDown.Size = new System.Drawing.Size(140, 21);
            this.secondsNumericUpDown.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.parityComboBox);
            this.groupBox1.Controls.Add(this.databitsComboBox);
            this.groupBox1.Controls.Add(this.baudRateComboBox);
            this.groupBox1.Controls.Add(this.comPortComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 135);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Meter Communication Settings";
            // 
            // parityComboBox
            // 
            this.parityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parityComboBox.FormattingEnabled = true;
            this.parityComboBox.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.parityComboBox.Location = new System.Drawing.Point(112, 109);
            this.parityComboBox.Name = "parityComboBox";
            this.parityComboBox.Size = new System.Drawing.Size(121, 23);
            this.parityComboBox.TabIndex = 1;
            // 
            // databitsComboBox
            // 
            this.databitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databitsComboBox.FormattingEnabled = true;
            this.databitsComboBox.Items.AddRange(new object[] {
            "7",
            "8"});
            this.databitsComboBox.Location = new System.Drawing.Point(112, 78);
            this.databitsComboBox.Name = "databitsComboBox";
            this.databitsComboBox.Size = new System.Drawing.Size(121, 23);
            this.databitsComboBox.TabIndex = 1;
            // 
            // baudRateComboBox
            // 
            this.baudRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudRateComboBox.FormattingEnabled = true;
            this.baudRateComboBox.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400"});
            this.baudRateComboBox.Location = new System.Drawing.Point(112, 47);
            this.baudRateComboBox.Name = "baudRateComboBox";
            this.baudRateComboBox.Size = new System.Drawing.Size(121, 23);
            this.baudRateComboBox.TabIndex = 1;
            // 
            // comPortComboBox
            // 
            this.comPortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPortComboBox.FormattingEnabled = true;
            this.comPortComboBox.Items.AddRange(new object[] {
            "RS232",
            "RS485_1",
            "RS485_2",
            "Optical port",
            "Infrared port",
            "PLC"});
            this.comPortComboBox.Location = new System.Drawing.Point(112, 16);
            this.comPortComboBox.Name = "comPortComboBox";
            this.comPortComboBox.Size = new System.Drawing.Size(121, 23);
            this.comPortComboBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Parity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Data bits:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Baud rate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port name:";
            // 
            // delayTimeLabel
            // 
            this.delayTimeLabel.AutoSize = true;
            this.delayTimeLabel.Location = new System.Drawing.Point(16, 84);
            this.delayTimeLabel.Name = "delayTimeLabel";
            this.delayTimeLabel.Size = new System.Drawing.Size(94, 15);
            this.delayTimeLabel.TabIndex = 5;
            this.delayTimeLabel.Text = "Delay time(ms):";
            // 
            // delayTimeNumericUpDown
            // 
            this.delayTimeNumericUpDown.Location = new System.Drawing.Point(124, 82);
            this.delayTimeNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.delayTimeNumericUpDown.Name = "delayTimeNumericUpDown";
            this.delayTimeNumericUpDown.Size = new System.Drawing.Size(120, 21);
            this.delayTimeNumericUpDown.TabIndex = 6;
            // 
            // SecondSignalCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupBox);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SecondSignalCalibration";
            this.Size = new System.Drawing.Size(342, 422);
            this.headerGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitNumericUpDown)).EndInit();
            this.settingGroupBox.ResumeLayout(false);
            this.settingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondsNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayTimeNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox headerGroupBox;
        private System.Windows.Forms.NumericUpDown secondsNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox secondsCheckBox;
        private System.Windows.Forms.CheckBox activateSecondCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comPortComboBox;
        private System.Windows.Forms.ComboBox baudRateComboBox;
        private System.Windows.Forms.ComboBox databitsComboBox;
        private System.Windows.Forms.ComboBox parityComboBox;
        private System.Windows.Forms.GroupBox settingGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown lowerLimitNumericUpDown;
        private System.Windows.Forms.NumericUpDown upperLimitNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label delayTimeLabel;
        private System.Windows.Forms.NumericUpDown delayTimeNumericUpDown;
    }
}
