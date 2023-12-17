using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using NLog.Config;

namespace _21008763_COMP3404_Program
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //NLog initialisation code
            var config = new XmlLoggingConfiguration("NLog.config");
            LogManager.Configuration = config;

            IServer server = new Server();
            Application.Run(new AssetViewer(server));
        }
    }
}
