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
using Microstar.Production.PCBTest.Command;
using Microstar.Production.PCBTest.Properties;
using Microstar.Production.Tools;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Microstar.Production.View
{
    /// <summary>
    /// 强制编程对话款
    /// </summary>
    public partial class ForceProgramDialog : Form
    {
        //每次读出或者写入SPI Flash的字节数
        private int bytesPerTransmit = Settings.Default.ForceProgramDialog_BytesPerTransmit;
        private int startAddress = 0;
        private uint fileCRC32 = 0; //本地文件CRC32
        private uint spiDataCRC32 = 0; //从Flash读出来的bin文件的CRC32

        /// <summary>
        ///  初始化强制编程对话款上的控件
        /// </summary>
        public ForceProgramDialog()
        {
            InitializeComponent();
        }   

        /// <summary>
        /// 加载强制编程对话框界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForceProgramForm_Load(object sender, EventArgs e)
        {
            this.fileNameTextBox.Text = Settings.Default.ForceProgramDialog_FileName;
            this.binSourceFileTextBox.Text = Settings.Default.ForceProgramDialog_BinFileContent;
            this.readLengthComboBox.SelectedIndex = 0;
            this.chipSelectComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// 关闭强制编程对话款
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DisableEnableUI(bool enabled)
        {
            this.startTransmitButton.Enabled = enabled;
            this.startCompareButton.Enabled = enabled;
            this.save256Button.Enabled = enabled;
            this.save512Button.Enabled = enabled;
        }

        /// <summary>
        /// 打开bin文件显示在TextBox中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFilebutton_Click(object sender, EventArgs e)
        {
            //显示打开文件对话框
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.fileNameTextBox.Text = openFileDialog1.FileName;
                this.checkSumlabel.Text = string.Format("{0:X8}", CRC32Helper.GetFileCRC32(openFileDialog1.FileName));

                fileCRC32 = CRC32Helper.GetFileCRC32(this.fileNameTextBox.Text);

                using (FileStream stream = File.Open(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] src = binaryReader.ReadBytes((int)stream.Length);

                    StringBuilder builder = new StringBuilder();

                    for (uint i = 0; i < src.Length; i += 16)
                    {
                        builder.AppendFormat("{0:X8}:  ", i); 
                        for (uint j = 0; j < 16; j++)
                        {
                            builder.AppendFormat("{0:X2}", src[i + j]);
                            if (j < 15)
                            {
                                builder.Append(" ");
                            }
                        }
                        if (i < src.Length - 16)
                        {
                            builder.Append("\r\n");
                        }
                    }
                    this.binSourceFileTextBox.Text = builder.ToString();
                }               
            }
        }

        /// <summary>
        /// 关闭强编对话框，保存配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForceProgramDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.ForceProgramDialog_FileName = this.fileNameTextBox.Text;
            Settings.Default.ForceProgramDialog_BinFileContent = this.binSourceFileTextBox.Text;
            Settings.Default.Save();
        }

        /// <summary>
        /// 将选中的Bin文件写入SPI指定地址中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void transmitButton_Click(object sender, EventArgs e)
        {
            this.startTransmitButton.Enabled = false;
            this.stopTransmitButton.Enabled = true;

            using (FileStream stream = File.Open(this.fileNameTextBox.Text, FileMode.Open, FileAccess.Read, FileShare.Read)) 
            {            
                this.transmitProgressBar.Maximum = (int)stream.Length / bytesPerTransmit;               
            }
            uint spiAddress = (uint)ForceProgramHelper.CalculateSpiAddress((uint)this.transmitForceProgram.ProgramChip);
            this.writeSpiBackgroundWorker.RunWorkerAsync(new AddressCommandParameter(spiAddress));  //触发DoWork事件     
        }

        /// <summary>
        /// 将SPI Flash里的bin文件读出来，与磁盘上的bin文件做对比
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startCompareButton_Click(object sender, EventArgs e)
        {
            this.startCompareButton.Enabled = false;
            this.stopTransmitButton.Enabled = true;
            this.readFlashDataTextBox.Clear();
            this.startAddress = 0;

            uint spiAddress = (uint)ForceProgramHelper.CalculateSpiAddress((uint)this.transmitForceProgram.ProgramChip);
            if (!int.TryParse(this.readLengthComboBox.SelectedItem.ToString(), out int readLength)) //此时从UI上获取的读取长度是以KB为单位
            {
                return;
            }
            this.transmitProgressBar.Maximum = readLength * 1024 / bytesPerTransmit;
            this.readSpiBackgroundWorker.RunWorkerAsync(new AddressCommandParameter(spiAddress, (uint)readLength));
        }

        /// <summary>
        /// 取消传输
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopTransmitButton_Click(object sender, EventArgs e)
        {
            this.writeSpiBackgroundWorker.CancelAsync();
            this.readSpiBackgroundWorker.CancelAsync();
            DisableEnableUI(true);
        }

        /// <summary>
        /// 往SPI Flash写入bin文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void writeSpiBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            using (var client = PcbTesterClient.Create(Settings.Default.PortName, Settings.Default.BaudRate))
            {               
                client.Open();

                var addressParameter = new AddressCommandParameter();
                if (e.Argument != null)
                {
                    addressParameter = (AddressCommandParameter)e.Argument;
                }

                //1.擦除选中SPI 地址上的内容
                var eraseSpiFlashCommand = new EraseSPIFlashCommand();
               
                var eraseResult = eraseSpiFlashCommand.Execute(client, new AddressCommandParameter(addressParameter.Address), null);
                if (!eraseResult.Success)
                {
                    e.Result = eraseResult;
                    return;
                }

                //2.将文件逐帧写入Flash
                using (FileStream stream = File.Open(this.fileNameTextBox.Text, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                   
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] readBytes = binaryReader.ReadBytes((int)stream.Length);             

                    int framesCount = readBytes.Length / bytesPerTransmit;  //算出共多少帧

                    StringBuilder builder = new StringBuilder();
                    var writeSPIFlashCommand = new WriteSPIFlashCommand();
                    for (int i = 0; i < readBytes.Length; i += bytesPerTransmit)
                    {
                        //如果用户取消了任务就跳出
                        if (backgroundWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }

                        backgroundWorker.ReportProgress(i / bytesPerTransmit + 1, framesCount);

                        builder.Clear();
                        for (int j = 0; j < bytesPerTransmit; j++)
                        {
                            builder.AppendFormat("{0:X2}", readBytes[i + j]);
                        }

                        var writeResult = writeSPIFlashCommand.Execute(client, new AddressCommandParameter(addressParameter.Address, builder.ToString()), null);
                        addressParameter.Address += (uint)bytesPerTransmit; //更新下次写的SPI起始地址
                        if (!writeResult.Success) //写入失败
                        {
                            e.Result = writeResult;
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 将写的进度实时显示在UI上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void writeSpiBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.transmitProgressBar.Value = e.ProgressPercentage;
            this.fileTransmitInfoLabel.Text = string.Format(Resources.ForceProgramDialog_FramesCountFormat, (int)e.UserState, e.ProgressPercentage);
        }

        /// <summary>
        /// 写入完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void writeSpiBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //判断是否出错
            if (e.Error != null)
            {
                MessageBoxHelper.ShowError(e.Error.Message);
                return;
            }
            //判断用户是否取消了操作
            if (e.Cancelled)
            {
                this.fileTransmitInfoLabel.Text = Resources.ForceProgramDialog_CancelTransmit;
            }
            else
            {
                this.fileTransmitInfoLabel.Text = Resources.ForceProgramDialog_WriteSpiCompleted;
            }

            if (e.Result as CommandResult != null)
            {
                var commandResult = e.Result as CommandResult;
                MessageBoxHelper.ShowError(commandResult.Message);
            }

            this.startTransmitButton.Enabled = true;
            this.stopTransmitButton.Enabled = false;
        }

        /// <summary>
        /// 读SPI Flash线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readSpiBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            using (var client = PcbTesterClient.Create(Settings.Default.PortName, Settings.Default.BaudRate))
            {
                client.Open();

                if (e.Argument as AddressCommandParameter == null)
                {
                    return;
                }
                var addressParameter = e.Argument as AddressCommandParameter;

                StringBuilder builder = new StringBuilder();
                int framesCount = (int)addressParameter.Length * 1024 / bytesPerTransmit;
                for (int i = 0; i < framesCount; i++)
                {
                    //如果用户取消了任务就跳出
                    if (backgroundWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    var command = new ReadSPIFlashCommand();
                    CommandResult readResult = command.Execute(client, new AddressCommandParameter(addressParameter.Address , (uint)bytesPerTransmit), null);
                    addressParameter.Address += (uint)bytesPerTransmit; //更新下次读的SPI起始地址
                    builder.AppendFormat("{0:X}", readResult.Data);
                    var data = new AddressCommandParameter();
                    data.Length = (uint)framesCount;
                    data.Data = readResult.Data;
                    backgroundWorker.ReportProgress(i + 1, data);
                    System.Threading.Thread.Sleep(50); //50ms发一次读命令帧
                }
                e.Result = builder.ToString();
            }
        }

        /// <summary>
        /// 将读到的数据显示在UI上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readSpiBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState as AddressCommandParameter == null)
            {
                return;
            }
            var data = e.UserState as AddressCommandParameter;
          
            string[] readData = ForceProgramHelper.SplitString(data.Data);
            int i = 0;
            StringBuilder builder = new StringBuilder();
            for (i = 0; i < readData.Length; i += 16)
            {
                builder.AppendFormat("{0:X8}:  ", startAddress + i);
                for (int j = 0; j < 16; j++)
                {
                    builder.AppendFormat("{0:X2}", readData[i + j]);
                    if (j < 15)
                    {
                        builder.Append(" ");
                    }
                }
                
                builder.Append("\r\n");
            }
            startAddress += i;
            this.readFlashDataTextBox.AppendText(builder.ToString()); //将从Flash读出来的内容显示在TextBox上

            this.transmitProgressBar.Value = e.ProgressPercentage;
            this.fileTransmitInfoLabel.Text = string.Format(Resources.ForceProgramDialog_FramesCountFormat, data.Length, e.ProgressPercentage);
        }

        /// <summary>
        /// 读Flash完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readSpiBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            startAddress = 0;
            //判断是否出错
            if (e.Error != null)
            {
                MessageBoxHelper.ShowError(e.Error.Message);
                return;
            }
            //判断用户是否取消了操作
            if (e.Cancelled)
            {
                this.fileTransmitInfoLabel.Text = Resources.ForceProgramDialog_CancelTransmit;
                return;
            }
  
            this.fileTransmitInfoLabel.Text = Resources.ForceProgramDialog_ReadSpiCompleted;


            if (e.Result != null)
            {
                spiDataCRC32 = CRC32Helper.CalculateCRC32(e.Result.ToString());
                if (spiDataCRC32 != fileCRC32)
                {
                    MessageBoxHelper.ShowError(Resources.ForceProgramDialog_CRC32Failed);
                }
                else
                {
                    MessageBoxHelper.ShowInfo(Resources.ForceProgramDialog_CRC32Success);
                }
            }

            this.startCompareButton.Enabled = true;
            this.stopTransmitButton.Enabled = false;
        }
    }
}
 