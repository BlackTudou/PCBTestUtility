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

using Microstar.Production.PCBTest.Business;
using Microstar.Production.PCBTest.Command;
using Microstar.Production.PCBTest.Model;
using Microstar.Production.PCBTest.Properties;
using Microstar.Production.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Microstar.Production.Tools;

namespace Microstar.Production.PCBTest.Controls
{
    /// <summary>
    /// 选择检测项目加载界面
    /// </summary>
    public partial class Landing : UserControl
    {       
        private CurrentRating current = new CurrentRating(Settings.Default.Landing_Ib, Settings.Default.Landing_Imax);
        private List<TestItemInfo> selectedMeterDetect = new List<TestItemInfo>();
        private List<TestItemInfo> selectedPowerDetect = new List<TestItemInfo>();
        private List<TestItemInfo> selectedTestItems = new List<TestItemInfo>();

        private int i = 0;

        /// <summary>
        /// 检测项目ID，由于选中的检测项目会有重复的，用ID作为唯一标识
        /// </summary>
        public int TestItemID { get; set; } = 0;

        /// <summary>
        /// 选中的电表线路板检测项目
        /// </summary>
        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<TestItemInfo> SelectedMeterDetect
        {
            get { return selectedMeterDetect; }
            set { this.selectedMeterDetect = value; }
        }

        /// <summary>
        /// 选中的开关电源板检测项目
        /// </summary>
        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<TestItemInfo> SelectedPowerDetect
        {
            get { return selectedPowerDetect; }
            set { this.selectedPowerDetect = value; }
        }

        /// <summary>
        /// 选中的检测功能
        /// </summary>
        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<TestItemInfo> SelectedTestItems
        {
            get
            {
                this.selectedTestItems = selectedMeterDetect.Concat(selectedPowerDetect).ToList();
                return selectedTestItems;
            }
            set
            {
                selectedTestItems.Clear();
                this.selectedTestItems = value;
                InitSelectedFuncTreeViewNodes();              
                selectedMeterDetect.Clear();
                selectedPowerDetect.Clear();
                            
                foreach (TestItemInfo testItemInfo in selectedTestItems)
                {
                    TreeNode node = new TreeNode();
                    if (testItemInfo.TestTargetType == TestTargetType.Meter)
                    {
                        selectedMeterDetect.Add(testItemInfo);
                        TreeNode tn = selectedFuncTreeView.Nodes[0];
                        tn.Nodes.Add(testItemInfo.Name);
                    }
                    else if (testItemInfo.TestTargetType == TestTargetType.PowerSource)
                    {
                        selectedPowerDetect.Add(testItemInfo);
                        TreeNode tn = selectedFuncTreeView.Nodes[1];
                        tn.Nodes.Add(testItemInfo.Name);
                    }
                }
                selectedFuncTreeView.ExpandAll();
            }
        }

        /// <summary>
        /// 电压规格
        /// </summary>
        public decimal Voltage
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.volComboBox.SelectedItem.ToString()))
                {
                    this.volComboBox.SelectedItem = Settings.Default.Landing_Voltage.ToString();
                }

                return Convert.ToDecimal(this.volComboBox.SelectedItem.ToString());
            }
            set { this.volComboBox.SelectedItem = value.ToString(); }
        }

        /// <summary>
        /// 电流规格
        /// </summary>
        [Description("电流规格")]
        [TypeConverter(typeof(CurrentConverter))]
        public CurrentRating Current
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.currentComboBox.SelectedItem.ToString()))
                {
                    current.Ib = Settings.Default.Landing_Ib;
                    current.Imax = Settings.Default.Landing_Imax;
                    this.currentComboBox.SelectedItem = current.ToString();
                }
                current.Update(this.currentComboBox.SelectedItem.ToString());
                return current;
            }
            set
            {
                current = value;
                this.currentComboBox.SelectedItem = current.ToString();
            }
        }

        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.baudRateComboBox.SelectedItem.ToString()))
                {
                    this.volComboBox.SelectedItem = Settings.Default.Landing_BaudRate.ToString();
                }

                return Convert.ToInt32(this.baudRateComboBox.SelectedItem.ToString());
            }
            set { this.baudRateComboBox.SelectedItem = value.ToString(); }
        }

        /// <summary>
        /// 客户代码
        /// </summary>
        public string CustomerCode
        {
            get { return this.costomerCodeComboBox.Text; }
            set { this.costomerCodeComboBox.Text = value; }
        }


        /// <summary>
        /// 电表表号的位数
        /// </summary>
        public int MeterNumberDigits
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.meterNumDigitsComboBox.SelectedItem.ToString()))
                {
                    this.meterNumDigitsComboBox.SelectedItem = Settings.Default.Landing_MeterNumberDigits.ToString();
                }
                return Convert.ToInt32(this.meterNumDigitsComboBox.SelectedItem.ToString());    
            }
            set
            {
                this.meterNumDigitsComboBox.SelectedItem = value.ToString();
            }
        }

        /// <summary>
        /// 当前检测的电表的0级密码
        /// </summary>
        public string MeterPassword
        {
            get { return this.meterPasswdTextBox.Text; }
            set { this.meterPasswdTextBox.Text = value; }
        }

        /// <summary>
        /// 电表协议
        /// </summary>
        public MeterProtocol Protocol
        {
            get
            {
                if (this.protocolComboBox.SelectedIndex == -1)
                {
                    this.protocolComboBox.SelectedIndex = 0;
                }

                return (MeterProtocol)this.protocolComboBox.SelectedIndex;              
            }
            set { this.protocolComboBox.SelectedIndex = value.GetHashCode(); }
        }

        /// <summary>
        /// 电表类型
        /// </summary>
        public ConnectionType MeterType
        {
            get
            {
                if (this.meterTypeComboBox.SelectedIndex == -1)
                {
                    this.meterTypeComboBox.SelectedIndex = 0;
                }

                return (ConnectionType)this.meterTypeComboBox.SelectedIndex;
            }
            set { this.meterTypeComboBox.SelectedIndex = value.GetHashCode(); }
        }

  

        /// <summary>
        /// 是否允许电表表号输入'A'~'F'的HEX码
        /// </summary>
        public bool MeterNumberAllowAlphabetic
        {
            get { return this.aFCheckBox.Checked; }
            set { this.aFCheckBox.Checked = value; }
        }

        /// <summary>
        /// 构造函数，初始化控件
        /// </summary>
        public Landing()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 将用户输入在UI上的参数保存到对应TestItemInfo中去
        /// </summary>
        public void SaveLastState()
        {
            foreach (var control in this.parameterPanel.Controls)
            {
                var parameterControl = control as IParameterControl;
                if (parameterControl == null)
                {
                    continue;
                }

                var selectedItem = this.SelectedTestItems
                    .Where((item) => item.ID == parameterControl.ID)
                    .FirstOrDefault();

                if (selectedItem == null)
                {
                    return;
                }

                selectedItem.Parameter = parameterControl.Parameter;             
            }           
        }

        /// <summary>
        /// 初始化SelectedFuncTreeView,添加根节点
        /// </summary>
        public void InitSelectedFuncTreeViewNodes()
        {
            this.selectedFuncTreeView.Nodes.Clear();
            this.selectedFuncTreeView.Nodes.Add(Resources.Landing_MeterTestItems);
            this.selectedFuncTreeView.Nodes.Add(Resources.Landing_PowerTestItems);
            this.selectedFuncTreeView.Nodes[0].Name = TestTargetType.Meter.ToString();
            this.selectedFuncTreeView.Nodes[1].Name = TestTargetType.PowerSource.ToString();
        }

        /// <summary>
        /// 删除原先的误差范围控件显示
        /// </summary>
        public void RemoveErrorControl()
        {
            for (int j = this.parameterPanel.Controls.Count; j > 0; j--)
            {
                Control control = this.parameterPanel.Controls[j - 1];
                var parameterControl = control as IParameterControl;
                if (parameterControl == null)
                {
                    continue;
                }
                this.parameterPanel.Controls.Remove(control);
                //control.Dispose();
            }
        }

        /// <summary>
        /// 从设置文件中读取配置，初始化界面显示
        /// </summary>
        public void InitializeInterface()
        {
            this.volComboBox.SelectedItem = Settings.Default.Landing_Voltage.ToString();
            current.Ib = Settings.Default.Landing_Ib;
            current.Imax = Settings.Default.Landing_Imax;
            this.currentComboBox.SelectedItem = current.ToString();
            this.baudRateComboBox.SelectedItem = Settings.Default.Landing_BaudRate.ToString();
            this.meterNumDigitsComboBox.SelectedItem = Settings.Default.Landing_MeterNumberDigits.ToString();
            this.protocolComboBox.SelectedItem = Settings.Default.Landing_Protocol.ToString();
            this.meterTypeComboBox.SelectedItem = Settings.Default.Landing_MeterType.ToString();
            this.costomerCodeComboBox.Text = Settings.Default.Landing_CostomerCode.ToString();

            this.meterPasswdTextBox.Text = Settings.Default.Landing_MeterPassword;  
            this.aFCheckBox.Checked = Settings.Default.Landing_MeterNumberAllowAlphabetic;

            this.optionalFuncTreeView.ExpandAll();
            this.selectedFuncTreeView.ExpandAll();
        }

        /// <summary>
        /// 首次加载界面显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Landing_Load(object sender, EventArgs e)
        {
            InitializeInterface();
        }

        /// <summary>
        /// 载入强编文件对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadFileButton_Click(object sender, EventArgs e)
        {
            ForceProgramDialog forceDialog = new ForceProgramDialog();
            forceDialog.ShowDialog();
        }

        /// <summary>
        /// optionalFuncTreeView双击事件，添加选中的节点到selectedFuncTreeView以及保存到对应的List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionalFuncTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddTestItemsToTreeView();
        }

        /// <summary>
        /// 添加按钮，添加选中检测项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            AddTestItemsToTreeView();
            this.optionalFuncTreeView.HideSelection = false;
        }

        /// <summary>
        /// 判断Treeview选中的节点是否为根节点或者空白地方
        /// </summary>
        /// <param name="node">TreeNode</param>
        /// <returns></returns>
        private bool IsRoot(TreeNode node)
        {
            if (node == null || node.Name == TestTargetType.Meter.ToString() || node.Name == TestTargetType.PowerSource.ToString()) //选中空白地方，选中节点为根节点
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除按钮，在选中功能树中，删除选中的节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TreeNode node = selectedFuncTreeView.SelectedNode;

            if (IsRoot(node))
            {
                return;
            }
       
            TestTargetType nodeType = (TestTargetType)Enum.Parse(typeof(TestTargetType), node.Parent.Name);
            if (nodeType == TestTargetType.Meter)
            {
                selectedMeterDetect.RemoveAt(node.Index);  //先删除list中元素   
                TestItemID--;
            }
            else if (nodeType == TestTargetType.PowerSource)
            {
                selectedPowerDetect.RemoveAt(node.Index);
                TestItemID--;
            }
            this.selectedFuncTreeView.Nodes.Remove(this.selectedFuncTreeView.SelectedNode);
            this.selectedFuncTreeView.HideSelection = false;
            this.selectedFuncTreeView.ExpandAll();

            RemoveErrorControl();
        }

        /// <summary>
        /// 选中检测项树双击事件，显示选中节点的误差控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectedFuncTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode node = selectedFuncTreeView.SelectedNode;

            if (IsRoot(node))
            {
                return;
            }

            SaveLastState();
            RemoveErrorControl();

            int index = node.Index;
            TestTargetType nodeType = (TestTargetType)Enum.Parse(typeof(TestTargetType), node.Parent.Name);
            if (nodeType == TestTargetType.PowerSource)
            {
                index = node.Index + selectedMeterDetect.Count;
            }

            var parameterControl = ProfileManager.Instance.GetParameterControl(node.Text);
            parameterControl.Header = node.Text;
            parameterControl.ID = SelectedTestItems[index].ID;
            parameterControl.Parameter = SelectedTestItems[index].Parameter;
            parameterControl.Location = new System.Drawing.Point(3, 30);
     
            this.parameterPanel.Controls.Add(parameterControl as UserControl);
        }

        /// <summary>
        /// 添加检测项到TreeView中
        /// </summary>
        private void AddTestItemsToTreeView()
        {
            TreeNode newNode = optionalFuncTreeView.SelectedNode;
            if (IsRoot(newNode))
            {
                return;
            }

            InitSelectedFuncTreeViewNodes();
            TestTargetType nodeType = (TestTargetType)Enum.Parse(typeof(TestTargetType), newNode.Parent.Name);
            if (nodeType == TestTargetType.Meter) //添加到对应list
            {
                TestItemID++;
                TestItemInfo itemInfo = new TestItemInfo();
                itemInfo.Name = newNode.Text;
                itemInfo.ID = TestItemID;
                itemInfo.TestTargetType = TestTargetType.Meter;
                itemInfo.Parameter = ProfileManager.Instance.GetCommandParameter(newNode.Text);
                SelectedMeterDetect.Add(itemInfo);
            }
            else if (nodeType == TestTargetType.PowerSource)
            {
                TestItemID++;
                TestItemInfo itemInfo = new TestItemInfo();
                itemInfo.Name = newNode.Text;
                itemInfo.ID = TestItemID;
                itemInfo.TestTargetType = TestTargetType.PowerSource;
                itemInfo.Parameter = ProfileManager.Instance.GetCommandParameter(newNode.Text);
                SelectedPowerDetect.Add(itemInfo);
            }

            TreeNode tn = selectedFuncTreeView.Nodes[0];
            foreach (TestItemInfo item in SelectedMeterDetect)
            {
                tn.Nodes.Add(item.Name);
            }

            tn = selectedFuncTreeView.Nodes[1];
            foreach (TestItemInfo item in SelectedPowerDetect)
            {
                tn.Nodes.Add(item.Name);
            }

            selectedFuncTreeView.ExpandAll();
        }
    }
}
