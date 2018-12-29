using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace MeterTest.UI.Tools
{
    /// <summary>  
    /// <remarks>Xml序列化与反序列化</remarks>  
    /// <creator>zhangdapeng</creator>  
    /// </summary> 
    class XmlSerializeUtil
    {
        #region 反序列化  
        /// <summary>  
        /// 反序列化  
        /// </summary>  
        /// <param name="type">类型</param>  
        /// <param name="xml">XML字符串</param>  
        /// <returns></returns>  
        public static object Deserialize(Type type, string xml)
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xmldes = new XmlSerializer(type);
                return xmldes.Deserialize(sr);
            }
        }
        /// <summary>  
        /// 反序列化  
        /// </summary>  
        /// <param name="type"></param>  
        /// <param name="xml"></param>  
        /// <returns></returns>  
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }
        #endregion

        #region 序列化  
        /// <summary>  
        /// 序列化  
        /// </summary>  
        /// <param name="type">类型</param>  
        /// <param name="obj">对象</param>  
        /// <returns></returns>  
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            //序列化对象  
            xml.Serialize(Stream, obj);
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }

        #endregion
    }

    /// <summary>  
    ///  
    /// </summary>  
    [XmlRoot("skycenter")]
    public class AdsbEntity
    {
        private string _type;

        [XmlAttribute("type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _source;
        [XmlAttribute("source")]
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }
        private string _reality;
        [XmlAttribute("reality")]
        public string Reality
        {
            get { return _reality; }
            set { _reality = value; }
        }
        private string _rcvTime;
        [XmlAttribute("rcvTime")]
        public string RcvTime
        {
            get { return _rcvTime; }
            set { _rcvTime = value; }
        }
        private Head _head;
        //属性的定义  
        [XmlElement("head")]
        public Head Head
        {
            set   //设定属性  
            {
                _head = value;
            }
            get    //从属性获取值  
            {
                return _head;
            }
        }

        private List<Unit> data = new List<Unit>();

        [XmlArray("data")]
        [XmlArrayItem("unit")]
        public List<Unit> Unit
        {
            get { return data; }
        }
        public void addUnit(Unit e)
        {
            data.Add(e);
        }

        private string _msg;

        public string msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
    }

    public class Head
    {

        private string _datagramId;
        [XmlElement("datagramId")]
        public string DatagramId
        {
            set
            {
                _datagramId = value;
            }
            get
            {
                return _datagramId;
            }
        }

        private string _priority;
        [XmlElement("priority")]
        public string Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        private string _an;
        [XmlElement("an")]
        public string An
        {
            get { return _an; }
            set { _an = value; }
        }

        private string _fi;
        [XmlElement("fi")]
        public string Fi
        {
            get { return _fi; }
            set { _fi = value; }
        }

        private string _rcvAddress;
        [XmlElement("rcvAddress")]
        public string RcvAddress
        {
            get { return _rcvAddress; }
            set { _rcvAddress = value; }
        }

        private string _sndAddress;
        [XmlElement("sndAddress")]
        public string SndAddress
        {
            get { return _sndAddress; }
            set { _sndAddress = value; }
        }

        private string _bepTime;
        [XmlElement("bepTime")]
        public string BepTime
        {
            get { return _bepTime; }
            set { _bepTime = value; }
        }

        private string _smi;
        [XmlElement("smi")]
        public string Smi
        {
            get { return _smi; }
            set { _smi = value; }
        }

        private string _dsp;
        [XmlElement("dsp")]
        public string Dsp
        {
            get { return _dsp; }
            set { _dsp = value; }
        }

        private string _rgs;
        [XmlElement("rgs")]
        public string Rgs
        {
            get { return _rgs; }
            set { _rgs = value; }
        }

        private string _msn;
        [XmlElement("msn")]
        public string Msn
        {
            get { return _msn; }
            set { _msn = value; }
        }

        private string _datagramType;
        [XmlElement("datagramType")]
        public string DatagramType
        {
            get { return _datagramType; }
            set { _datagramType = value; }
        }

        private string _icao24;
        [XmlElement("icao24")]
        public string Icao24
        {
            get { return _icao24; }
            set { _icao24 = value; }
        }

        private string _callcode;
        [XmlElement("callcode")]
        public string Callcode
        {
            get { return _callcode; }
            set { _callcode = value; }
        }
    }

    [XmlRootAttribute("unit")]
    public class Unit
    {
        private string _name;

        [XmlAttribute("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _name_value;

        [XmlTextAttribute]
        public string Name_value
        {
            get { return _name_value; }
            set { _name_value = value; }
        }
    }

    class TestXml
    {
        void Test()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(@path + "../../test.xml");
            //Console.WriteLine(xmlDoc.OuterXml);  


            AdsbEntity ad = XmlSerializeUtil.Deserialize(typeof(AdsbEntity), xmlDoc.OuterXml) as AdsbEntity;
            // Console.WriteLine(ad.Head.DatagramId);  
            //Console.WriteLine(ad.Head.Fi);  

            string xml = XmlSerializeUtil.Serializer(typeof(AdsbEntity), ad);
            //Console.WriteLine(xml);  

            //Console.ReadKey();  
        }

    }
}

