//Author - Tom 21008763
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21008763_COMP3404_Program
{
    public class FileDialogManager
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public IList<string> FileDialog()
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Multiselect = true;
                openDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    Logger.Info("User imported some images");
                    IList<string> selectedPaths = openDialog.FileNames.ToList();
                    return selectedPaths;
                }
                else
                {
                    Logger.Warn("User did not choose images in file dialog");
                    return null;
                }
            }
        }
    }
}
