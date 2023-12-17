using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace _21008763_COMP3404_Program
{
    public enum LogType
    {
        Log,
        Error,
        Warning
    }
    /// <summary>
    /// Simple logger by Tom to see program flow and more!
    /// </summary>
    public class TomsLogger
    {
        /// <summary>
        /// Method used for logging, it takes the log type, log message, classsname and method name and writes it to console for easier debugging
        /// </summary>
        /// <param name="pType">Passes in the type of log, eg: Error</param>
        /// <param name="pLogMessage">Passes in the message from the log to display in console</param>
        public static void Log(LogType pType, string pLogMessage, string pClass, MethodBase pMethod)
        {
            string _prefix = "";
            ConsoleColor _color = ConsoleColor.White;
            switch (pType) 
            {
                case LogType.Log:
                    _prefix = "[Log]";
                    _color = ConsoleColor.Blue;
                    break;
                case LogType.Error:
                    _prefix = "[Error]";
                    _color = ConsoleColor.Red;
                    break;
                case LogType.Warning:
                    _prefix = "[Warning]";
                    _color = ConsoleColor.Yellow;
                    break;
                default:
                    break;
            }
            Console.WriteLine($"-> {pClass} <- \n-> {pMethod} <-");
            Console.ForegroundColor = _color;
            Console.Write(_prefix);
            Console.ResetColor();
            Console.WriteLine($" {pLogMessage}");
        }
    }
}
