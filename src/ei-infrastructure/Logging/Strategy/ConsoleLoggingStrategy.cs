﻿using ei_core.Interfaces;
using ei_core.LoggingObjects;
using System;

namespace ei_infrastructure.Logging.Strategy
{
    public class ConsoleLoggingStrategy : ILoggingStrategy
    {
        #region Properties
        public ConsoleColor InvokeLogColor { get; set; }
        public ConsoleColor ResultLogColor { get; set; }
        public ConsoleColor ErrorLogColor { get; set; }
        public ConsoleColor WarningLogColor { get; set; }
        public ConsoleColor InformationLogColor { get; set; }
        #endregion /Properties

        public ConsoleLoggingStrategy()
        {
            InvokeLogColor = ConsoleColor.Green;
            ResultLogColor = ConsoleColor.Cyan;
            ErrorLogColor = ConsoleColor.Red;
            WarningLogColor = ConsoleColor.Yellow;
            InformationLogColor = ConsoleColor.Blue;
        }

        #region ILoggingStrategy Members

        public bool Log(LoggingArgument arg)
        {
            if (arg == null)
            {
                return false;
            }

            ConsoleColor oldForeground = Console.ForegroundColor;

            switch (arg.LogType)
            {
                case LoggingType.Invoke:
                    Console.ForegroundColor = InvokeLogColor;
                    break;
                case LoggingType.Result:
                    Console.ForegroundColor = ResultLogColor;
                    break;
                case LoggingType.Error:
                    Console.ForegroundColor = ErrorLogColor;
                    break;
                case LoggingType.Warning:
                    Console.ForegroundColor = WarningLogColor;
                    break;
                case LoggingType.Information:
                    Console.ForegroundColor = InformationLogColor;
                    break;
                default:
                    break;
            }

            Console.WriteLine(arg.ToString());

            Console.ForegroundColor = oldForeground;

            return true;
        }

        #endregion /ILoggingStrategy Members
    }
}
