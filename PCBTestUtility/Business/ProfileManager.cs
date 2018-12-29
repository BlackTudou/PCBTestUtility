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

using Microstar.Production.PCBTest.Command;
using Microstar.Production.PCBTest.Controls;
using Microstar.Production.PCBTest.Model;
using Microstar.Production.PCBTest.Properties;
using Microstar.Utility;
using System;
using System.Collections.Generic;
using System.Resources;

namespace Microstar.Production.PCBTest.Business
{
    /// <summary>
    /// 从配置文件建立键值对
    /// </summary>
    public sealed class ProfileManager
    {
        private static Lazy<ProfileManager> instance = new Lazy<ProfileManager>(() => new ProfileManager());

        private Lazy<Dictionary<string, ICommand>> commandDictionary = 
            new Lazy<Dictionary<string, ICommand>>(()=>new Dictionary<string, ICommand>());

        private Lazy<Dictionary<string, CommandParameter>> parameterDictionary =
            new Lazy<Dictionary<string, CommandParameter>>(() => new Dictionary<string, CommandParameter>());

        private Lazy<Dictionary<string, IParameterControl>> errorControlDictionary =
            new Lazy<Dictionary<string, IParameterControl>>(() => new Dictionary<string, IParameterControl>());

        /// <summary>
        /// ProfileManager类的实例
        /// </summary>
        public static ProfileManager Instance
        {
            get
            {
                return instance.Value;
            }
        }

        /// <summary>
        /// 防止直接调用构造函数
        /// </summary>
        private ProfileManager()
        { }

        /// <summary>
        /// 根据检测项获取对应的Command实例
        /// </summary>
        /// <param name="name">检测项名字</param>
        /// <returns>Command实例</returns>
        public ICommand GetCommand(string name)
        {
            InitializeCommandDictionary(); //检测功能名-误差控件名 键值对
            if (!commandDictionary.Value.ContainsKey(name))
            {
                throw new KeyNotFoundException(Resources.ProfileManager_NoProfile);
            }

            return commandDictionary.Value[name];
        }

        /// <summary>
        /// 根据检测项获取对应的误差控件实例
        /// </summary>
        /// <param name="name">检测项名字</param>
        /// <returns>误差控件实例</returns>
        public IParameterControl GetParameterControl(string name)
        {
            InitializeErrorControlDictionary(); //检测功能名-误差控件名 键值对
            if (!errorControlDictionary.Value.ContainsKey(name))
            {
                throw new KeyNotFoundException(Resources.ProfileManager_NoProfile);
            }

            return errorControlDictionary.Value[name];
        }

        /// <summary>
        /// 根据检测项获取相应的误差参数实例
        /// </summary>
        /// <param name="name">检测项名字</param>
        /// <returns>误差参数实例</returns>
        public CommandParameter GetCommandParameter(string name)
        {
            InitializeParameterDictionary();
            if (!parameterDictionary.Value.ContainsKey(name))
            {
                throw new KeyNotFoundException(Resources.ProfileManager_NoProfile);
            }

            return parameterDictionary.Value[name];
        }

        /// <summary>
        /// 从配置文件获取 检测项目、该检测项目所用的检测命令类 键值对
        /// </summary>
        /// <returns></returns>
        private void InitializeCommandDictionary()  //项目名称，该检测项目所用的检测命令类
        {
            ResourceManager manager = new ResourceManager("Microstar.Production.PCBTest.Properties.Resources", typeof(Resources).Assembly);
            var commandList = SerializeHelper.DeserializeXML<CommandDescriptions>(Settings.Default.ProfilePath);

            if (!commandDictionary.IsValueCreated)
            {
                foreach (CommandDescription commandDescription in commandList.Command)
                {
                    object instance = Reflections.CreateInstance("Microstar.Production.PCBTest.Command." + commandDescription.CommandType);

                    commandDictionary.Value.Add(
                        manager.GetString(commandDescription.ResoureId),
                        (ICommand)instance);
                }
            }
        }

        /// <summary>
        /// 根据配置文件生成 检测项目名称-参数实例 键值对
        /// </summary>
        /// <returns></returns>
        private void InitializeParameterDictionary()  //项目名称，参数
        {
            ResourceManager manager = new ResourceManager("Microstar.Production.PCBTest.Properties.Resources", typeof(Resources).Assembly);
            var commandList = SerializeHelper.DeserializeXML<CommandDescriptions>(Settings.Default.ProfilePath);

            if (!parameterDictionary.IsValueCreated)
            {
                foreach (CommandDescription commandDescription in commandList.Command)
                {
                    parameterDictionary.Value.Add(
                        manager.GetString(commandDescription.ResoureId),
                        commandDescription.CommandParameter);
                }
            }
        }

        /// <summary>
        /// 检测项目、误差控件键值对
        /// </summary>
        /// <returns></returns>
        private void InitializeErrorControlDictionary()  //项目名称，误差控件名称
        {
            ResourceManager manager = new ResourceManager("Microstar.Production.PCBTest.Properties.Resources", typeof(Resources).Assembly);

            var commandList = SerializeHelper.DeserializeXML<CommandDescriptions>(Settings.Default.ProfilePath);

            if (!errorControlDictionary.IsValueCreated)
            {
                foreach (CommandDescription commandDescription in commandList.Command)
                {
                    object instance = Reflections.CreateInstance("Microstar.Production.PCBTest.Controls." + commandDescription.ErrorControlType);

                    errorControlDictionary.Value.Add(
                        manager.GetString(commandDescription.ResoureId),
                        (IParameterControl)instance);
                }
            }
        }      
    }
}
