using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Microstar.Production.PCBTest
{
    /// <summary>
    /// 对串口进行操作的类，其中包括写和读操作
    /// </summary>
    public class SerialOperation
    {       
        SerialPort _serialPort = null;
        //定义委托
        //public delegate void SerialPortDataReceiveEventArgs(object sender, SerialDataReceivedEventArgs e, byte[] bits);
        public delegate void SerialPortDataReceiveEventHandler(object sender, SerialDataReceivedEventArgs e, byte[] bits);
        //定义接收数据事件
        public event SerialPortDataReceiveEventHandler DataReceived;
        //public event SerialPortDataReceiveEventArgs DataReceived;


        /// <summary>
        /// 默认构造函数，操作COM1，速度为9600，没有奇偶校验，8位字节，停止位为1
        /// </summary>
        public SerialOperation()
        {
            _serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            setSerialPort();
        }
        /// <summary>
        /// 构造函数,
        /// </summary>
        /// <param name="comPortName"></param>
        public SerialOperation(string comPortName)
        {
            _serialPort = new SerialPort(comPortName);
            setSerialPort();
        }
        /// <summary>
        /// 构造函数,可以自定义串口的初始化参数
        /// </summary>
        /// <param name="comPortName">需要操作的COM口名称</param>
        /// <param name="baudRate">COM的速度</param>
        /// <param name="parity">奇偶校验位</param>
        /// <param name="dataBits">数据长度</param>
        /// <param name="stopBits">停止位</param>
        public SerialOperation(string comPortName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            _serialPort = new SerialPort(comPortName, baudRate, parity, dataBits, stopBits);
            setSerialPort();
        }

        /// <summary>
        /// 设置串口资源,还需重载多个设置串口的函数
        /// </summary>
        void setSerialPort()
        {
            if (_serialPort != null)
            {
                //设置触发DataReceived事件的字节数为1
                _serialPort.ReceivedBytesThreshold = 1;
                //接收到一个字节时，也会触发DataReceived事件
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                //接收数据出错,触发事件
                _serialPort.ErrorReceived += new SerialErrorReceivedEventHandler(_serialPort_ErrorReceived);
                //打开串口
                openPort();
            }
        }

        /// <summary>
        /// 打开串口资源
        /// </summary>
        bool openPort()
        {
            bool ok = false;
            //如果串口是打开的，先关闭
            if (_serialPort.IsOpen)
                _serialPort.Close();
            try
            {
                //打开串口
                _serialPort.Open();
                ok = true;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return ok;
        }
        /// <summary>
        /// 关闭串口资源,操作完成后,一定要关闭串口
        /// </summary>
        public void closePort()
        {
            //如果串口处于打开状态,则关闭
            if (_serialPort.IsOpen)
                _serialPort.Close();
        }

        /// <summary>
        /// 接收串口数据事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (DataReceived != null)
            {
                byte[] _data = new byte[_serialPort.BytesToRead];
                _serialPort.Read(_data, 0, _data.Length);
                DataReceived(sender, e, _data);
            }
        }
        /// <summary>
        /// 接收数据出错事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {

        }

        public void writeData(string dataStr)
        {
            //发送数据,并加加车符
            _serialPort.Write(dataStr + "\r");
        }

        /// <summary>
        /// 获取所有已连接短信猫设备的串口
        /// </summary>
        /// <returns></returns>
        public string[] serialsIsConnected()
        {
            List<string> lists = new List<string>();
            string[] seriallist = getSerials();
            foreach (string s in seriallist)
            {

            }
            return lists.ToArray();
        }
        /// <summary>
        /// 获得当前电脑上的所有串口资源
        /// </summary>
        /// <returns></returns>
        public string[] getSerials()
        {
            return SerialPort.GetPortNames();
        }
        /// <summary>
        /// 把字节型转换成十六进制字符串
        /// </summary>
        /// <param name="InBytes"></param>
        /// <returns></returns>
        public static string ByteToString(byte[] InBytes)
        {
            string StringOut = "";
            foreach (byte InByte in InBytes)
            {
                StringOut = StringOut + String.Format("{0:X2} ", InByte);
            }
            return StringOut;
        }
        /// <summary>
        /// 把十六进制字符串转换成字节型
        /// </summary>
        /// <param name="InString"></param>
        /// <returns></returns>
        public static byte[] StringToByte(string InString)
        {
            string[] ByteStrings;
            ByteStrings = InString.Split(" ".ToCharArray());
            byte[] ByteOut;
            ByteOut = new byte[ByteStrings.Length - 1];
            for (int i = 0; i == ByteStrings.Length - 1; i++)
            {
                ByteOut[i] = Convert.ToByte(("0x" + ByteStrings[i]));
            }
            return ByteOut;
        }

        
    }
}

