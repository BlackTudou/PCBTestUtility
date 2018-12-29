namespace Microstar.Production.PCBTest.Controls
{
    partial class RangeSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RangeSelector));
            this.headerGroupBox = new System.Windows.Forms.GroupBox();
            this.lowerLimitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.upperLimitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.headerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupBox
            // 
            resources.ApplyResources(this.headerGroupBox, "headerGroupBox");
            this.headerGroupBox.Controls.Add(this.lowerLimitNumericUpDown);
            this.headerGroupBox.Controls.Add(this.upperLimitNumericUpDown);
            this.headerGroupBox.Controls.Add(this.label1);
            this.headerGroupBox.Controls.Add(this.label2);
            this.headerGroupBox.Name = "headerGroupBox";
            this.headerGroupBox.TabStop = false;
            // 
            // lowerLimitNumericUpDown
            // 
            this.lowerLimitNumericUpDown.DecimalPlaces = 1;
            this.lowerLimitNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.lowerLimitNumericUpDown, "lowerLimitNumericUpDown");
            this.lowerLimitNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.lowerLimitNumericUpDown.Name = "lowerLimitNumericUpDown";
            this.lowerLimitNumericUpDown.ValueChanged += new System.EventHandler(this.lowerLimitNumericUpDown_ValueChanged);
            // 
            // upperLimitNumericUpDown
            // 
            this.upperLimitNumericUpDown.DecimalPlaces = 1;
            this.upperLimitNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.upperLimitNumericUpDown, "upperLimitNumericUpDown");
            this.upperLimitNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.upperLimitNumericUpDown.Name = "upperLimitNumericUpDown";
            this.upperLimitNumericUpDown.ValueChanged += new System.EventHandler(this.upperLimitNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // RangeSelector
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupBox);
            this.Name = "RangeSelector";
            this.headerGroupBox.ResumeLayout(false);
            this.headerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox headerGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown upperLimitNumericUpDown;
        private System.Windows.Forms.NumericUpDown lowerLimitNumericUpDown;
    }
}
