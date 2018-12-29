namespace Microstar.Production.PCBTest
{
    partial class ForceProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForceProgram));
            this.checkSumTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblForceChip = new System.Windows.Forms.Label();
            this.programChipComboBox = new System.Windows.Forms.ComboBox();
            this.customerCodeComboBox = new System.Windows.Forms.ComboBox();
            this.meterTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // checkSumTextBox
            // 
            resources.ApplyResources(this.checkSumTextBox, "checkSumTextBox");
            this.checkSumTextBox.Name = "checkSumTextBox";
            this.checkSumTextBox.ReadOnly = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblForceChip
            // 
            resources.ApplyResources(this.lblForceChip, "lblForceChip");
            this.lblForceChip.Name = "lblForceChip";
            // 
            // programChipComboBox
            // 
            resources.ApplyResources(this.programChipComboBox, "programChipComboBox");
            this.programChipComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.programChipComboBox.FormattingEnabled = true;
            this.programChipComboBox.Items.AddRange(new object[] {
            resources.GetString("programChipComboBox.Items"),
            resources.GetString("programChipComboBox.Items1"),
            resources.GetString("programChipComboBox.Items2"),
            resources.GetString("programChipComboBox.Items3"),
            resources.GetString("programChipComboBox.Items4")});
            this.programChipComboBox.Name = "programChipComboBox";
            // 
            // customerCodeComboBox
            // 
            resources.ApplyResources(this.customerCodeComboBox, "customerCodeComboBox");
            this.customerCodeComboBox.FormattingEnabled = true;
            this.customerCodeComboBox.Name = "customerCodeComboBox";
            // 
            // meterTypeComboBox
            // 
            resources.ApplyResources(this.meterTypeComboBox, "meterTypeComboBox");
            this.meterTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.meterTypeComboBox.FormattingEnabled = true;
            this.meterTypeComboBox.Items.AddRange(new object[] {
            resources.GetString("meterTypeComboBox.Items"),
            resources.GetString("meterTypeComboBox.Items1"),
            resources.GetString("meterTypeComboBox.Items2"),
            resources.GetString("meterTypeComboBox.Items3")});
            this.meterTypeComboBox.Name = "meterTypeComboBox";
            // 
            // ForceProgram
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customerCodeComboBox);
            this.Controls.Add(this.checkSumTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblForceChip);
            this.Controls.Add(this.meterTypeComboBox);
            this.Controls.Add(this.programChipComboBox);
            this.Name = "ForceProgram";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox checkSumTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblForceChip;
        private System.Windows.Forms.ComboBox programChipComboBox;
        private System.Windows.Forms.ComboBox customerCodeComboBox;
        private System.Windows.Forms.ComboBox meterTypeComboBox;
    }
}
