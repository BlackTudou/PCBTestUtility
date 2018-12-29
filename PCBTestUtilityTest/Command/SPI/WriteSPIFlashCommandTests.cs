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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microstar.Production.Comms.PCB;
using Microstar.Production.PCBTest.Command;

namespace Microstar.Production.PCBTest.Tests
{
    /// <summary>
    /// 写SPI Flash命令
    /// </summary>
    [TestClass()]
    public class WriteSPIFlashCommandTests : UnitTestBase
    {
        /// <summary>
        /// 执行写SPI Flash命令
        /// </summary>
        [TestMethod()]
        public void ExcuteTest()
        {
            using (var client = PcbTesterClient.Create(PortName, BaudRate))
            {
                client.Open();

                var eraseCommand = new EraseSPIFlashCommand();
                var eraseParameter = new AddressCommandParameter(0x0u);
                CommandResult eraseResult = eraseCommand.Execute(client, eraseParameter, null);

                var readcommand0 = new ReadSPIFlashCommand();
                var readParameter0 = new AddressCommandParameter(0x0u, 4);

                CommandResult readResult0 = readcommand0.Execute(client, readParameter0, null);

                client.Write("0-0:199.128.8", new byte[] { 0x10 }, 0x0u);
#if false
                var readcommand0 = new ReadSPIFlashCommand();
                var readParameter0 = new AddressCommandParameter(0x00020000u, 4);

                CommandResult readResult0 = readcommand0.Execute(client, readParameter0, null);

                var eraseCommand = new EraseSPIFlashCommand();
                var eraseParameter = new AddressCommandParameter(0x00020000u);
                CommandResult eraseResult = eraseCommand.Execute(client, eraseParameter, null);

                var readcommand = new ReadSPIFlashCommand();
                // var parameter = new AddressCommandParameter(0x00u, 2, "FFFF");
                //var parameter = new AddressCommandParameter(0x00020000u, 4, "FFFFFFFF");
                var readParameter = new AddressCommandParameter(0x00020000u, 4);

                CommandResult readResult = readcommand.Execute(client, readParameter, null);

                var command = new WriteSPIFlashCommand();

                // var parameter = new AddressCommandParameter(0x00020000u, "00000000");

                //string writeData = "000000000000000000000000000000000000000000000000000001A650000000505000000050500000005050000000505000000050500000005050000000505000000050500000005050000000505000000050500000005050000000505000000050500000005050000000505000000050000000000000000000000000000000";
                string writeData = "FF"; 
                var writeParameter = new AddressCommandParameter(0x00020000u, writeData);
                CommandResult result = command.Execute(client, writeParameter, null);

                //writeParameter = new AddressCommandParameter(0x01, writeData);
                //result = command.Execute(client, writeParameter, null);


                var readcommand1 = new ReadSPIFlashCommand();
                // var parameter = new AddressCommandParameter(0x00u, 2, "FFFF");
                //var parameter = new AddressCommandParameter(0x00020000u, 4, "FFFFFFFF");
                var readParameter1 = new AddressCommandParameter(0x00020000u, 1);

                CommandResult readResult1 = readcommand.Execute(client, readParameter1, null);
#endif    
               // Assert.AreEqual(result.Success, true);
                //Assert.AreEqual(result.Message, "");
            }
        }
    }
}