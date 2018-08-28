namespace MeterTest
{
    partial class SerialSettingsDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPortNumber = new System.Windows.Forms.ComboBox();
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.cmbDataBit = new System.Windows.Forms.ComboBox();
            this.cmbCheckBit = new System.Windows.Forms.ComboBox();
            this.cmbStopBit = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbStopBit);
            this.groupBox1.Controls.Add(this.cmbCheckBit);
            this.groupBox1.Controls.Add(this.cmbDataBit);
            this.groupBox1.Controls.Add(this.cmbBaud);
            this.groupBox1.Controls.Add(this.cmbPortNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // btnConfirm
            // 
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConfirm.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Image = global::MeterTest.Properties.Resources.ok_900200;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.Location = new System.Drawing.Point(20, 260);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 31);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Image = global::MeterTest.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(138, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "波特率:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "数据位:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "校验位:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "停止位:";
            // 
            // cmbPortNumber
            // 
            this.cmbPortNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortNumber.FormattingEnabled = true;
            this.cmbPortNumber.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4"});
            this.cmbPortNumber.Location = new System.Drawing.Point(86, 25);
            this.cmbPortNumber.Name = "cmbPortNumber";
            this.cmbPortNumber.Size = new System.Drawing.Size(121, 23);
            this.cmbPortNumber.TabIndex = 1;
            // 
            // cmbBaud
            // 
            this.cmbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.cmbBaud.Location = new System.Drawing.Point(86, 68);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(121, 23);
            this.cmbBaud.TabIndex = 1;
            // 
            // cmbDataBit
            // 
            this.cmbDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBit.FormattingEnabled = true;
            this.cmbDataBit.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cmbDataBit.Location = new System.Drawing.Point(86, 111);
            this.cmbDataBit.Name = "cmbDataBit";
            this.cmbDataBit.Size = new System.Drawing.Size(121, 23);
            this.cmbDataBit.TabIndex = 1;
            // 
            // cmbCheckBit
            // 
            this.cmbCheckBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCheckBit.FormattingEnabled = true;
            this.cmbCheckBit.Items.AddRange(new object[] {
            "ODD",
            "EVEN",
            "NONE"});
            this.cmbCheckBit.Location = new System.Drawing.Point(86, 154);
            this.cmbCheckBit.Name = "cmbCheckBit";
            this.cmbCheckBit.Size = new System.Drawing.Size(121, 23);
            this.cmbCheckBit.TabIndex = 1;
            // 
            // cmbStopBit
            // 
            this.cmbStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBit.FormattingEnabled = true;
            this.cmbStopBit.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbStopBit.Location = new System.Drawing.Point(86, 197);
            this.cmbStopBit.Name = "cmbStopBit";
            this.cmbStopBit.Size = new System.Drawing.Size(121, 23);
            this.cmbStopBit.TabIndex = 1;
            // 
            // SerialSettingsDialog
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(236, 304);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SerialSettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "串口设置";
            this.Load += new System.EventHandler(this.SerialSettingsDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPortNumber;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.ComboBox cmbDataBit;
        private System.Windows.Forms.ComboBox cmbStopBit;
        private System.Windows.Forms.ComboBox cmbCheckBit;
    }
}