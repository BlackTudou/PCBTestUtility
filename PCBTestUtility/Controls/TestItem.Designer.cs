namespace Microstar.Production.PCBTest
{
    partial class TestItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestItem));
            this.testNameLabel = new System.Windows.Forms.Label();
            this.testResultTextBox = new System.Windows.Forms.TextBox();
            this.landingPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.landingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // testNameLabel
            // 
            resources.ApplyResources(this.testNameLabel, "testNameLabel");
            this.testNameLabel.Name = "testNameLabel";
            // 
            // testResultTextBox
            // 
            this.testResultTextBox.BackColor = System.Drawing.Color.Lavender;
            resources.ApplyResources(this.testResultTextBox, "testResultTextBox");
            this.testResultTextBox.Name = "testResultTextBox";
            this.testResultTextBox.ReadOnly = true;
            // 
            // landingPictureBox
            // 
            this.landingPictureBox.Image = global::Microstar.Production.PCBTest.Properties.Resources.landing;
            resources.ApplyResources(this.landingPictureBox, "landingPictureBox");
            this.landingPictureBox.Name = "landingPictureBox";
            this.landingPictureBox.TabStop = false;
            // 
            // TestItem
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.landingPictureBox);
            this.Controls.Add(this.testResultTextBox);
            this.Controls.Add(this.testNameLabel);
            this.Name = "TestItem";
            ((System.ComponentModel.ISupportInitialize)(this.landingPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label testNameLabel;
        private System.Windows.Forms.TextBox testResultTextBox;
        private System.Windows.Forms.PictureBox landingPictureBox;
    }
}
