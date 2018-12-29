using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microstar.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microstar.Production.PCBTest.Model;
using Microstar.Production.PCBTest.Command;

namespace Microstar.Utility.Tests
{
    [TestClass()]
    public class SerializeHelperTests
    {
        [TestMethod()]
        public void SerializeXMLTest()
        {
            var commandList = new CommandDescriptions();
            List<CommandDescription> command = new List<CommandDescription>();

            CommandDescription commandDescription = new CommandDescription();
            commandDescription.Name = "Phase A power consumption";
            commandDescription.TestTargetType = Production.PCBTest.TestTargetType.Meter;
            commandDescription.ResoureId = "Item_PhaseAPowerConsumption";
            //commandDescription.CommandType = new MeasureActivePowerCommand();
            commandDescription.CommandType = "MeasureActivePowerCommand";
            commandDescription.ErrorControlType = "RangeSelector";

            var commandParameter = new MeasureParameter();
            commandParameter.LowerLimit = 0.6m;
            commandParameter.UpperLimit = 1.0m;
            commandParameter.Phase = Phase.A;
            commandParameter.PinNumber = 0;
            commandParameter.CurrentRange = CurrentRange.All;
            commandDescription.CommandParameter = commandParameter;


            command.Add(commandDescription);
            commandList.Command = command;
            SerializeHelper.SerializeXML<CommandDescriptions>(commandList, @"H:\WorkSpace\rPCBT\PCBTestUtility\Xml\XmlTest.xml");
            //Assert.Fail();
        }
    }
}