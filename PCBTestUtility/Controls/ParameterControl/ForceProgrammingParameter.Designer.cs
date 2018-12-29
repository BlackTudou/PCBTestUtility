namespace Microstar.Production.PCBTest.Controls
{
    partial class ForceProgrammingParameter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForceProgrammingParameter));
            this.label1 = new System.Windows.Forms.Label();
            this.i2cChipSelectComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.i2cAddressComboBox = new System.Windows.Forms.ComboBox();
            this.spiAddressComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lengthComboBox = new System.Windows.Forms.ComboBox();
            this.headerGroupBox = new System.Windows.Forms.GroupBox();
            this.headerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // i2cChipSelectComboBox
            // 
            this.i2cChipSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.i2cChipSelectComboBox.FormattingEnabled = true;
            this.i2cChipSelectComboBox.Items.AddRange(new object[] {
            resources.GetString("i2cChipSelectComboBox.Items"),
            resources.GetString("i2cChipSelectComboBox.Items1"),
            resources.GetString("i2cChipSelectComboBox.Items2"),
            resources.GetString("i2cChipSelectComboBox.Items3"),
            resources.GetString("i2cChipSelectComboBox.Items4"),
            resources.GetString("i2cChipSelectComboBox.Items5"),
            resources.GetString("i2cChipSelectComboBox.Items6"),
            resources.GetString("i2cChipSelectComboBox.Items7")});
            resources.ApplyResources(this.i2cChipSelectComboBox, "i2cChipSelectComboBox");
            this.i2cChipSelectComboBox.Name = "i2cChipSelectComboBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // i2cAddressComboBox
            // 
            this.i2cAddressComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.i2cAddressComboBox, "i2cAddressComboBox");
            this.i2cAddressComboBox.Name = "i2cAddressComboBox";
            // 
            // spiAddressComboBox
            // 
            this.spiAddressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spiAddressComboBox.FormattingEnabled = true;
            this.spiAddressComboBox.Items.AddRange(new object[] {
            resources.GetString("spiAddressComboBox.Items"),
            resources.GetString("spiAddressComboBox.Items1"),
            resources.GetString("spiAddressComboBox.Items2"),
            resources.GetString("spiAddressComboBox.Items3"),
            resources.GetString("spiAddressComboBox.Items4")});
            resources.ApplyResources(this.spiAddressComboBox, "spiAddressComboBox");
            this.spiAddressComboBox.Name = "spiAddressComboBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // lengthComboBox
            // 
            this.lengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lengthComboBox.FormattingEnabled = true;
            this.lengthComboBox.Items.AddRange(new object[] {
            resources.GetString("lengthComboBox.Items"),
            resources.GetString("lengthComboBox.Items1")});
            resources.ApplyResources(this.lengthComboBox, "lengthComboBox");
            this.lengthComboBox.Name = "lengthComboBox";
            // 
            // headerGroupBox
            // 
            this.headerGroupBox.Controls.Add(this.i2cChipSelectComboBox);
            this.headerGroupBox.Controls.Add(this.lengthComboBox);
            this.headerGroupBox.Controls.Add(this.label1);
            this.headerGroupBox.Controls.Add(this.label4);
            this.headerGroupBox.Controls.Add(this.label2);
            this.headerGroupBox.Controls.Add(this.spiAddressComboBox);
            this.headerGroupBox.Controls.Add(this.label3);
            this.headerGroupBox.Controls.Add(this.i2cAddressComboBox);
            resources.ApplyResources(this.headerGroupBox, "headerGroupBox");
            this.headerGroupBox.Name = "headerGroupBox";
            this.headerGroupBox.TabStop = false;
            // 
            // ForceProgrammingParameter
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupBox);
            this.Name = "ForceProgrammingParameter";
            this.headerGroupBox.ResumeLayout(false);
            this.headerGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox i2cChipSelectComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox i2cAddressComboBox;
        private System.Windows.Forms.ComboBox spiAddressComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox lengthComboBox;
        private System.Windows.Forms.GroupBox headerGroupBox;
    }
}
