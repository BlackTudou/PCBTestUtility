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

using Microstar.Production.Comms.PCB;
using Microstar.Production.PCBTest;
using Microstar.Production.PCBTest.Business;
using Microstar.Production.PCBTest.Command;
using Microstar.Production.PCBTest.Model;
using Microstar.Production.PCBTest.Properties;
using Microstar.Production.Tools;
using Microstar.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Microstar.Production.View
{
    /// <summary>
    /// 主界面
    /// </summary>
    public partial class MainForm : Form
    {
        private BackgroundWorker testBackgroundWorker = new BackgroundWorker();
        private List<TestItem> testItemsUI = new List<TestItem>();
        private int progressValue = 0;

        /// <summary>
        /// 初始化主界面上的控件
        /// </summary>
        public MainForm()
        {
            InitializeComponent();         
        }

        /// <summary>
        /// 加载主界面，初始化BackgroundWorker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Settings.Default.IsTestFileAuto) //是否自动载入上次保存的测试文件
            {
                LoadTestFile(Settings.Default.FileName);
            }

            InitializeInterface();

            //BackgroundWorker初始化
            testBackgroundWorker.WorkerReportsProgress = true;
            testBackgroundWorker.WorkerSupportsCancellation = true;
            testBackgroundWorker.DoWork += new DoWorkEventHandler(TestBackgroundWorker_DoWork);
            testBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(TestBackgroundWorker_ProgressChanged);
            testBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TestBackgroundWorker_RunWorkerCompleted);
        }

        /// <summary>
        /// 关闭主界面，更新配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Landing_Voltage = this.landing1.Voltage;
            Settings.Default.Landing_Ib = this.landing1.Current.Ib;
            Settings.Default.Landing_Imax = this.landing1.Current.Imax;
            Settings.Default.Landing_BaudRate = this.landing1.BaudRate;
            Settings.Default.Landing_CostomerCode = this.landing1.CustomerCode;
            Settings.Default.Landing_MeterNumberDigits = this.landing1.MeterNumberDigits;
            Settings.Default.Landing_Protocol = PropertySettingHelper.ProtocalEnumToString(this.landing1.Protocol);
            Settings.Default.Landing_MeterType = PropertySettingHelper.MeterTypeEnumToString(this.landing1.MeterType);
            Settings.Default.Landing_MeterPassword = this.landing1.MeterPassword;
            Settings.Default.Landing_MeterNumberAllowAlphabetic = this.landing1.MeterNumberAllowAlphabetic;
            Settings.Default.MainForm_MeterNumber = this.meterNumberTextBox.Text;
            Settings.Default.Save();
        }

        /// <summary>
        /// 表号输入框，限制输入位数以及输入限制为数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void meterNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.meterNumberTextBox.MaxLength = this.landing1.MeterNumberDigits; //限制textbox输入位数
            //限制meterNumberTextBox只能输入数字
            if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar)) //退格键 数字
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 下一步按钮 进入检测界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.landing1.SaveLastState();
            RemoveItem();
            AddTestItem();
            NextInterface();
            DisableEnableUI(true);
        }

        /// <summary>
        /// 上一步 回到Landing界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forwardButton_Click(object sender, EventArgs e)
        {
            this.meterNumberTextBox.Text = AutoCompleteMeterNumber(this.meterNumberTextBox.Text, this.landing1.MeterNumberDigits); //输入位数不足时，前面自动补零
            ForwardInterface();           
        }
      
        /// <summary>
        /// 开始检测按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartCheck_Click(object sender, EventArgs e)
        {
            Run();
        }

        /// <summary>
        /// 在非UI线程上执行检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgWorker = sender as BackgroundWorker;
    
            using (PcbTesterClient client = PcbTesterClient.Create(Settings.Default.PortName, Settings.Default.BaudRate))
            {
                client.Open();
                progressValue = 0;
                List<CommandResult> commandResultsList = new List<CommandResult>();
                for (int i = 0; i < this.landing1.SelectedTestItems.Count; i++)
                {
                  
                    TestItemInfo testItem = this.landing1.SelectedTestItems[i];
               
                    bgWorker.ReportProgress(i);
                    progressValue = i;
                    var testResult = CommandEngine.Instance.Excute(client, testItem);
                    commandResultsList.Add(testResult);
                    bgWorker.ReportProgress(i, testResult);

                    //在操作的过程中需要检查用户是否取消了当前的操作。
                    if (bgWorker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                }
                e.Result = commandResultsList;
            }
        }

        /// <summary>
        /// 状态栏更新
        /// </summary>
        /// <param name="messageFormat"></param>
        /// <param name="args"></param>
        private void UpdateStatus(string messageFormat, params object[] args)
        {
            this.runningItemtoolStripStatusLabel.Text = string.Format(messageFormat, args);
        }

        /// <summary>
        /// 将执行进度信息以及检测结果显示在UI线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int index = e.ProgressPercentage;

            string name = this.landing1.SelectedTestItems[index].Name;
            UpdateStatus("Run test:{0}...", name);  //更新状态栏

            var commandResult = e.UserState as CommandResult;
            if (commandResult == null) //未执行
            {
                testItemsUI[index].TestResult = TestResult.NotRun.ToString();
                testItemsUI[index].IsTesting = true;
            }
            else
            {
                var result = (CommandResult)e.UserState;

                if (result.Success == true)
                {
                    testItemsUI[index].TestResult = string.Format("{0}:{1}",TestResult.Pass.ToString(), result.Data);
                }
                else
                {
                    testItemsUI[index].TestResult = string.Format("{0}:{1}", TestResult.Failed.ToString(), result.Data);                   
                }
                testItemsUI[index].IsTesting = false;
            }
        }

        private void TestBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //如果用户取消了当前操作
            if (e.Cancelled)
            {               
                foreach (TestItem item in testItemsUI)
                {
                    item.IsTesting = false;
                }
                return;
            }

            //检测已经结束，设置按钮状态。
            DisableEnableUI(true);
            this.startTestButton.Text = Resources.MainForm_StartTest;

            //检测中的异常会被抓住，在这里可以进行处理。
            if (e.Error != null)
            {                                              
                MessageBoxHelper.ShowError(e.Error.Message);
                testItemsUI[progressValue].IsTesting = false;
                testItemsUI[progressValue].TestResult = TestResult.Failed.ToString();
                this.testInterface1.ResultImage = Resources.NOOK;
                return;              
            }

            if (e.Result != null)
            {
                //检测结果数据库处理
                var information = GetTestRecordInstance(e.Result);

                if (this.landing1.SelectedTestItems.Count != 0)
                {
                    TestRecordManager.Instance.InsertTestRecord(information);
                }

                if (information.Result == Resources.Result_Success)  ///图片显示本次检测结果 合格/不合格
                {
                    this.testInterface1.ResultImage = Resources.OK;
                }
                else if (information.Result == Resources.Result_Failed)
                {
                    this.testInterface1.ResultImage = Resources.NOOK;
                }
            }
        }

        /// <summary>
        /// 将检测结果组织成TestRecord实例，传入BLL层
        /// </summary>
        /// <param name="testResult"></param>
        /// <returns></returns>
        private TestRecord GetTestRecordInstance(object testResult)
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            TestRecord information = new TestRecord()
            {
                MeterNumber = this.meterNumberTextBox.Text,
                CustomerCode = this.landing1.CustomerCode,
                Time = currentTime
            };

            User user = UserManager.Instance.SelectUserNumber(Settings.Default.Login_UserName);
            if (user == null)
            {
                MessageBoxHelper.ShowError(Resources.MainForm_NoUser);
                throw new Exception(Resources.MainForm_NoUser);
            }
            information.InspectorNumber = user.Number;

            StringBuilder sb = new StringBuilder();
            foreach (TestItemInfo testItemInfo in this.landing1.SelectedTestItems)
            {
                sb.AppendFormat("{0};", testItemInfo.Name);
            }
            information.Items = sb.ToString();

            List<CommandResult> results = (List<CommandResult>)testResult;

            sb.Clear();
            foreach (CommandResult item in results)
            {
                if (item.Success == false)
                {
                    information.Result = Resources.Result_Failed;
                }
                else if (item.Success == true)
                {
                    information.Result = Resources.Result_Success;
                }
                sb.AppendFormat("{0};", item.Data);
            }
            information.DetailedInformation = sb.ToString();

            return information;
        }

        /// <summary>
        /// 输入表号后按下回车键执行开始检测功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void meterNumberTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Run();
            }
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManageDialog usrDialog = new UserManageDialog();
            usrDialog.ShowDialog();
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataViewer dataViewer = new DataViewer();
            dataViewer.ShowDialog();
        }

        private void serialSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerialSettingsDialog serialDialog = new SerialSettingsDialog();
            serialDialog.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var optionDialog = new OptionDialog();
            optionDialog.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void moreCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdditionalCommandDialog additionalCommandDialog = new AdditionalCommandDialog();
            additionalCommandDialog.ShowDialog();
        }

        /// <summary>
        /// 菜单栏新建按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.landing1.SelectedMeterDetect.Clear();
            this.landing1.SelectedPowerDetect.Clear();
            this.landing1.InitSelectedFuncTreeViewNodes();
            this.landing1.RemoveErrorControl();
            RemoveItem();
            this.landing1.InitializeInterface();
        }

        /// <summary>
        /// 打开文件对话框,将xml文件反序列化到UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //显示打开文件对话框
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadTestFile(openFileDialog1.FileName);
                Settings.Default.FileName = openFileDialog1.FileName;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// 保存文件对话框，将参数设置序列化到xml文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TestProject project = new TestProject();

                project.Voltage = this.landing1.Voltage;
                project.Current = this.landing1.Current;
                project.BaudRate = this.landing1.BaudRate;
                project.CustomerCode = this.landing1.CustomerCode;
                project.Protocol = this.landing1.Protocol;
                project.MeterType = this.landing1.MeterType;
                project.MeterPassword = this.landing1.MeterPassword;
                project.MeterNumberDigits = this.landing1.MeterNumberDigits;
                project.MeterNumberAllowAlphabetic = this.landing1.MeterNumberAllowAlphabetic;
                this.landing1.SaveLastState();
                project.SelectedTestItems = this.landing1.SelectedTestItems;

                SerializeHelper.SerializeXML<TestProject>(project, this.saveFileDialog1.FileName);
            }
        }

       /// <summary>
       /// 检查开始检测前用户的输入
       /// </summary>
       /// <returns></returns>
        private bool CheckPrerequisites()
        {
            if (string.IsNullOrWhiteSpace(this.meterNumberTextBox.Text)) //未输入表号
            {
                MessageBoxHelper.ShowError(Resources.MainForm_InputMeterNumber);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 禁用、启用控件
        /// </summary>
        /// <param name="enabled">true:启用 false:禁用</param>
        private void DisableEnableUI(bool enabled)
        {
            this.forwardButton.Enabled = enabled;
            this.meterNumberTextBox.Enabled = enabled;
            this.testInterface1.EnableMetetNumberIncreasedCheckBox = enabled;
        }

        /// <summary>
        /// 执行检测任务
        /// </summary>
        private void Run()
        {
            bool isStart = ParseButtonText(this.startTestButton.Text);
            
            if (isStart)  //开始检测
            {
                if (!CheckPrerequisites()) //检查开始检测前用户的输入
                {
                    return;
                }
                DisableEnableUI(false);
                this.meterNumberTextBox.Text = AutoCompleteMeterNumber(this.meterNumberTextBox.Text, this.landing1.MeterNumberDigits); //表号输入位数不足 前面自动补零
                this.testInterface1.ResultImage = null;

                this.startTestButton.Text = Resources.MainForm_StopTest; ;  
                
                testBackgroundWorker.RunWorkerAsync();  //触发DoWork事件
            }
            //停止检测
            else
            {
                DisableEnableUI(true);
                this.startTestButton.Text = Resources.MainForm_StartTest;

                for (int j = this.testInterface1.groupBox2.Controls.Count; j > 0; j--)
                {
                    Control ctl = this.testInterface1.groupBox2.Controls[j - 1];
                    if (ctl is TestItem)
                    {
                        var control = ctl as TestItem;
                        control.IsTesting = false;                  
                    }
                }        
                //取消当前操作
                testBackgroundWorker.CancelAsync(); 
            }
        }

        /// <summary>
        /// 将Button上的Text转为Bool进行判断
        /// </summary>
        /// <param name="text">string输入</param>
        /// <returns>按键状态</returns>
        private bool ParseButtonText(string text)
        {
            if (text == Resources.MainForm_StartTest)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 主机面初始化显示
        /// </summary>
        private void InitializeInterface()
        {
            this.landing1.BringToFront();
            this.pnlPassNum.BringToFront();
            this.nextButton.BringToFront();
            this.startTestButton.SendToBack();
            this.forwardButton.SendToBack();
            this.meterNumberTextBox.SendToBack();

            this.meterNumberTextBox.MaxLength = this.landing1.MeterNumberDigits; //限制表号长度     
            

            //this.testInterface1.DataSource = TestRecordManager.Instance.
            //TestRecordManager.Instance.
        }

        /// <summary>
        /// 检测界面加载检测项目
        /// </summary>
        private void AddTestItem()
        { 
            int i = 0;

            foreach (TestItemInfo item in landing1.SelectedTestItems)
            {             
                TestItem testitem = new TestItem();
                if (i < 10)
                {
                    testitem.Location = new System.Drawing.Point(6, 16 + testitem.Height * i);
                }
                else
                {
                    testitem.Location = new System.Drawing.Point(6 + testitem.Width, 16 + testitem.Height * (i - 10));
                }
                testitem.TestName = item.Name + ":";
                testitem.TestResult = TestResult.NotRun.ToString();
                testitem.ID = i;
                testitem.IsTesting = false;
                this.testInterface1.groupBox2.Controls.Add(testitem);
                i++;
                testItemsUI.Add(testitem);
            }
        }

        /// <summary>
        /// 移除检测界面检测项目
        /// </summary>
        private void RemoveItem()
        {
            //问题记录：每次删除一个非最大索引的控件后，剩下控件的索引会发生变化，所以用foreach遍历或者for从0开始删就会出现删不干净的问题
            for (int j = this.testInterface1.groupBox2.Controls.Count; j > 0; j--)
            {
                Control ctl = this.testInterface1.groupBox2.Controls[j - 1];
                if (ctl is TestItem)
                {
                    this.testInterface1.groupBox2.Controls.Remove(ctl);
                    ctl.Dispose();
                }
            }
            testItemsUI.Clear();
            this.testInterface1.ResultImage = null;
        }

        /// <summary>
        /// 进入检测界面显示
        /// </summary>
        private void NextInterface()
        {
            this.testInterface1.BringToFront();
            this.pnlPassNum.BringToFront();
            this.nextButton.SendToBack();
            this.forwardButton.BringToFront();
            this.startTestButton.BringToFront();
            this.meterNumberTextBox.BringToFront();

            this.testInterface1.Voltage = this.landing1.Voltage;
            this.testInterface1.Current = this.landing1.Current.ToString();
            this.testInterface1.BaudRate = this.landing1.BaudRate;                 
            this.testInterface1.CustomerCode = this.landing1.CustomerCode;
            if (Settings.Default.Landing_MeterNumberDigits == this.landing1.MeterNumberDigits)
            {
                this.meterNumberTextBox.Text = Settings.Default.MainForm_MeterNumber;
            }
            else
            {
                this.meterNumberTextBox.Clear();
            }
        }

        /// <summary>
        /// 回到landing界面显示
        /// </summary>
        private void ForwardInterface()
        {
            this.landing1.BringToFront();
            this.pnlPassNum.BringToFront();
            this.nextButton.BringToFront();
            this.forwardButton.SendToBack();
            this.startTestButton.SendToBack();
            this.meterNumberTextBox.SendToBack();
            testItemsUI.Clear();
        }

        /// <summary>
        /// 当输入表号不足表号位数时，前面自动补零
        /// </summary>
        /// <param name="input">要转换的字符串</param>
        /// <param name="digits">目标位数</param>
        /// <returns>转换后的字符串</returns>
        private string AutoCompleteMeterNumber(string input, int digits)
        {       
            if (input.Length < digits && !string.IsNullOrWhiteSpace(input))
            {
                input = input.PadLeft(digits, '0');
            }
            return input;
        }

        /// <summary>
        /// 反序列化xml测试文件到对象中，并对象的值显示在UI上
        /// </summary>
        /// <param name="fileName">文件名</param>
        private void LoadTestFile(string fileName)
        {
            this.landing1.RemoveErrorControl();

            TestProject project = SerializeHelper.DeserializeXML<TestProject>(fileName);
       
            this.landing1.Voltage = project.Voltage;
            this.landing1.Current = project.Current;
            this.landing1.BaudRate = project.BaudRate;
            this.landing1.CustomerCode = project.CustomerCode;
            this.landing1.Protocol = project.Protocol;
            this.landing1.MeterType = project.MeterType;
            this.landing1.MeterPassword = project.MeterPassword;
            this.landing1.MeterNumberDigits = project.MeterNumberDigits;
            this.landing1.MeterNumberAllowAlphabetic = project.MeterNumberAllowAlphabetic;
            this.landing1.SelectedTestItems.Clear();
            this.landing1.SelectedTestItems = project.SelectedTestItems;
            int count = this.landing1.SelectedTestItems.Count;
            this.landing1.TestItemID = this.landing1.SelectedTestItems[count - 1].ID;
                
            RemoveItem();
        }

        /// <summary>
        /// 上5V电 导通5V继电器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void on5VolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PcbTesterClient client = PcbTesterClient.Create(Settings.Default.PortName, Settings.Default.BaudRate))
            {               
                try
                {
                    client.Open();
                    RelayControlHelper.On5V(client);
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError(ex.Message);
                    return;
                }
            }
        }

        /// <summary>
        /// 断电复位 关闭所有继电器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PcbTesterClient client = PcbTesterClient.Create(Settings.Default.PortName, Settings.Default.BaudRate))
            {              
                try
                {
                    client.Open();
                    RelayControlHelper.Reset(client);
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError(ex.Message);
                    return;
                }
            }
        }

        /// <summary>
        /// 打开485（1）通道
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void open485ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PcbTesterClient client = PcbTesterClient.Create(Settings.Default.PortName, Settings.Default.BaudRate))
            {
                try
                {
                    client.Open();
                    RelayControlHelper.ControlRelay(client, new RelayControlCommandParameter(RelayControlAction.OPEN, "19"));
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError(ex.Message);
                    return;
                }
            }
        } 

        /// <summary>
        /// 打开秒信号通道
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openSecondsSignalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 上模拟电压电流，导通5V 模拟电压 模拟电流继电器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onAnalogVolCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PcbTesterClient client = PcbTesterClient.Create(Settings.Default.PortName, Settings.Default.BaudRate))
            {
                try
                {
                    client.Open();
                    RelayControlHelper.ControlRelay(client,new RelayControlCommandParameter(RelayControlAction.OPEN, "0,1,2,3,4,5,6"));
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError(ex.Message);
                    return;
                }
            }
        }
    }
}
