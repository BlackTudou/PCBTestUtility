using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Microstar.Production.PCBTest
{
    class Parameter : INIOperationClass
    {
        public static string ParameterIni { get; set; } = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\parameter.ini";

        /// <summary>
        /// 从parameter.ini配置文件读取相关配置，对combBox控件进行初始化显示
        /// </summary>
        /// <param name="sender">对哪个form里的combBox进行初始化显示，通常为this</param>
        /// <param name="iniFile">ini文件</param>
        /// <param name="section">节点名字</param>
        /// <param name="key">传入"comset",表示comboBox初始化显示的key值</param>
        /// <param name="cmbName">comboBox Name属性</param>
        public static void CmbLoad(object sender,string iniFile, string section, string key, string cmbName)
        {
            string temp = INIOperationClass.INIGetStringValue(iniFile, section, "All", "1");
            Debug.WriteLine(temp);

            int comX_num = int.Parse(temp);

            object o = sender.GetType().GetField(cmbName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(sender);

            //Debug.WriteLine("comX_num={0}", comX_num);
            //不加这个if条件，它每打开一次该对话框就会往里面添加一次，因为他打开一次就会调用一次load函数
            if ((o as ComboBox).Items.Count != comX_num)
            {
                for (int i = 1; i <= comX_num; i++)
                {
                    (o as ComboBox).Items.Add(INIOperationClass.INIGetStringValue(iniFile, section, i.ToString(), "1"));
                }
            }
            (o as ComboBox).SelectedItem = INIOperationClass.INIGetStringValue(iniFile, section, key, "1");
        }

        /// <summary>
        /// 从ini文件中读取checkBox控件的初始化显示
        /// </summary>
        /// <param name="sender">哪个form上的CheckBox控件，通常为this</param>
        /// <param name="checkBoxName">checkBox的Name属性</param>
        /// <param name="iniFile">ini文件名</param>
        /// <param name="section">节点</param>
        /// <param name="key">读取指定的key</param>
        public static void CheckBoxLoad(object sender,string checkBoxName,string iniFile, string section, string key)
        {
            object o = sender.GetType().GetField(checkBoxName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(sender);
            if (INIOperationClass.INIGetStringValue(iniFile, section, key, "") == "0")
            {
                (o as CheckBox).Checked = false;
            }
            else if (INIOperationClass.INIGetStringValue(iniFile, section, key, "") == "1")
            {
                (o as CheckBox).Checked = true;
            }
        }

        public static void TextBoxLoad(object sender, string TextBoxName, string iniFile, string section, string key)
        {
            object o = sender.GetType().GetField(TextBoxName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(sender);
            (o as TextBox).Text = INIOperationClass.INIGetStringValue(iniFile, section, key, "");
        }

        /// <summary>
        /// ini文件是以0,1作为checkBox状态，而类中是以Bool保存checkBox状态，此函数将bool类型转为0,1写入ini文件中
        /// </summary>
        /// <param name="b"></param>
        /// <param name="key"></param>
        public static void SetChkFile(string iniFile,string section, string key,bool b)
        {
            if (b == true)
            {
                Debug.WriteLine("SetChkFile:{0}",b);
                INIOperationClass.INIWriteValue(iniFile, section, key, "1");
            }
            else
            {
                Debug.WriteLine("SetChkFile:{0}", b);
                INIOperationClass.INIWriteValue(iniFile, section, key, "0");
            }
        }


#if false
        public void ParameterIniOperation()
        {
            ParameterIni = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\parameter.ini";
            System.Diagnostics.Debug.WriteLine(ParameterIni);

            try
            {
                //写入/更新键值          
                //INIWriteValue(parameterIni, "comX", "All", "4");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //INIWriteValue(parameterIni, "Toolbar", "Items", "Save,Delete,Open");
            //INIWriteValue(parameterIni, "Toolbar", "Dock", "True");

            //写入一批键值
            //INIWriteItems(parameterIni, "Menu", "File=文件\0View=视图\0Edit=编辑");

            //获取文件中所有的节点
            string[] sections = INIGetAllSectionNames(ParameterIni);

            //获取指定节点中的所有项
            string[] items = INIGetAllItems(ParameterIni, "comX");
            foreach(string n in items)
            {
                Debug.WriteLine(n);
            }
            

            //获取指定节点中所有的键
            string[] keys = INIGetAllItemKeys(ParameterIni, "Menu");

            //获取指定KEY的值
            string value = INIGetStringValue(ParameterIni, "comX", "1", null);
            Debug.WriteLine(value);

            //删除指定的KEY
            //INIDeleteKey(parameterIni, "desktop", "color");

            //删除指定的节点
            //INIDeleteSection(parameterIni, "desktop");

            //清空指定的节点
            //INIEmptySection(parameterIni, "toolbar");

        }
#endif
    }
}
