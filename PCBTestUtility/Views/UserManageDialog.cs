/*
 * Copyright (C) 1994-2018 Microstar Electric Company Limited
 * 
 * All Rights Reserved.
 * 
 * LEGAL NOTICE: All information contained herein is, and 
 * remains the property of Microstar Electric Company Limited. 
 * The intellectual and technical concepts contained herein 
 * are proprietary to Microstar Electric Company Limited, and 
 * may be covered by patents, patents in process and are 
 * protected by the trade secret or copyright laws. Commercial 
 * use, or disclosure, or dissemination, or reproduction of 
 * the information contained in this file are strictly 
 * forbidden unless official specific written permissions are 
 * obtained from Microstar Electric Company Limited.
 */
using Microstar.Production.PCBTest.Properties;
using Microstar.Production.Tools;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Microstar.Production.View
{
    /// <summary>
    /// 用户管理对话框
    /// </summary>
    public partial class UserManageDialog : Form
    {
        private UserAction action;

        /// <summary>
        /// 初始化用户管理对话框上的控件
        /// </summary>
        public UserManageDialog()
        {
            InitializeComponent();
        }

        private void UserManageDialog_Load(object sender, EventArgs e)
        {
            if (Settings.Default.Login_UserName == "admin")
            {
                ButtonEnabled(true);
            }
            else
            {
                ButtonEnabled(false);
            }
            this.deleteUserButton.Enabled = false;

            string sql1 = "select number as Number,user_name as UserName,name as Name, password as Password from Users";

            using (SqlDataAdapter adapter = new SqlDataAdapter(sql1, SqlHelper.GetSqlConnectionStrings())) //数据适配器
            {
                DataTable dt = new DataTable();

                adapter.Fill(dt); //填充数据到DataTable
                this.dataGridView1.DataSource = dt;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 新建用户修改对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modifyUserButton_Click(object sender, EventArgs e)
        {
            UserEditDialog usermdfDialog = new UserEditDialog();

            usermdfDialog.ShowDialog();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            this.nameTextBox.Text = this.dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            this.userNameTextBox.Text = this.dataGridView1.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
            this.numberTextBox.Text = this.dataGridView1.Rows[e.RowIndex].Cells["Number"].Value.ToString();
            this.passwordTextBox.Text = this.dataGridView1.Rows[e.RowIndex].Cells["Password"].Value.ToString();

            TextBoxReadOnly(true);

            if (this.numberTextBox.Text == "100000")
            {
                this.deleteUserButton.Enabled = false;
            }
            else
            {
                this.deleteUserButton.Enabled = true;
            }
        }

        /// <summary>
        /// 将密码那一列显示为*号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.Value != null && e.Value.ToString().Length > 0)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newUserButton_Click(object sender, EventArgs e)
        {
            this.nameTextBox.Clear();
            this.userNameTextBox.Clear();
            this.numberTextBox.Clear();
            this.passwordTextBox.Clear();

            TextBoxReadOnly(false);

            action = UserAction.Add;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(Resources.UserManageDialog_DeleteUser, Resources.Common_Question, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                string sql = "delete from Users where number=@number";
                SqlParameter paraNumber = new SqlParameter("@number", this.numberTextBox.Text);
                SqlHelper.ExecuteNonQuery(sql, paraNumber);
            }
        }

        private void TextBoxReadOnly(bool isReadOnly)
        {
            this.nameTextBox.ReadOnly = isReadOnly;
            this.userNameTextBox.ReadOnly = isReadOnly;
            this.numberTextBox.ReadOnly = isReadOnly;
            this.passwordTextBox.ReadOnly = isReadOnly;
        }

        private void ButtonEnabled(bool enabled)
        {
            this.deleteUserButton.Enabled = enabled;
            this.newUserButton.Enabled = enabled;
            this.modifyUserButton.Enabled = enabled;
        }
    }
}
