namespace Microstar.Production.PCBTest.Controls
{
    partial class Pager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pager));
            this.label3 = new System.Windows.Forms.Label();
            this.totalCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.firstButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.lastButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.pageCountLabel = new System.Windows.Forms.Label();
            this.pageNumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.currentPageLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pageSizeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // totalCountLabel
            // 
            resources.ApplyResources(this.totalCountLabel, "totalCountLabel");
            this.totalCountLabel.Name = "totalCountLabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // goButton
            // 
            resources.ApplyResources(this.goButton, "goButton");
            this.goButton.Name = "goButton";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // firstButton
            // 
            this.firstButton.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.firstButton, "firstButton");
            this.firstButton.Name = "firstButton";
            this.firstButton.UseVisualStyleBackColor = false;
            this.firstButton.Click += new System.EventHandler(this.firstButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.previousButton, "previousButton");
            this.previousButton.Name = "previousButton";
            this.previousButton.UseVisualStyleBackColor = false;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // lastButton
            // 
            this.lastButton.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.lastButton, "lastButton");
            this.lastButton.Name = "lastButton";
            this.lastButton.UseVisualStyleBackColor = false;
            this.lastButton.Click += new System.EventHandler(this.lastButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.nextButton, "nextButton");
            this.nextButton.Name = "nextButton";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // pageCountLabel
            // 
            resources.ApplyResources(this.pageCountLabel, "pageCountLabel");
            this.pageCountLabel.Name = "pageCountLabel";
            // 
            // pageNumberTextBox
            // 
            resources.ApplyResources(this.pageNumberTextBox, "pageNumberTextBox");
            this.pageNumberTextBox.Name = "pageNumberTextBox";
            this.pageNumberTextBox.TextChanged += new System.EventHandler(this.pageNumberTextBox_TextChanged);
            this.pageNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pageNumberTextBox_KeyPress);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // currentPageLabel
            // 
            resources.ApplyResources(this.currentPageLabel, "currentPageLabel");
            this.currentPageLabel.Name = "currentPageLabel";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // pageSizeComboBox
            // 
            this.pageSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pageSizeComboBox.FormattingEnabled = true;
            this.pageSizeComboBox.Items.AddRange(new object[] {
            resources.GetString("pageSizeComboBox.Items"),
            resources.GetString("pageSizeComboBox.Items1"),
            resources.GetString("pageSizeComboBox.Items2")});
            resources.ApplyResources(this.pageSizeComboBox, "pageSizeComboBox");
            this.pageSizeComboBox.Name = "pageSizeComboBox";
            this.pageSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.pageSizeComboBox_SelectedIndexChanged);
            // 
            // Pager
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pageSizeComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.currentPageLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.totalCountLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.firstButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.lastButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.pageCountLabel);
            this.Controls.Add(this.pageNumberTextBox);
            this.Name = "Pager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button firstButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button lastButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label pageCountLabel;
        private System.Windows.Forms.TextBox pageNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label currentPageLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox pageSizeComboBox;
    }
}
