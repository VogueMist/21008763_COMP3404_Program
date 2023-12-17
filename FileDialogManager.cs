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
        public IList<string> FileDialog(bool save)
        {

            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Multiselect = true;
                openDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    TomsLogger.Log(LogType.Log, "User imported some images", GetType().Name, MethodBase.GetCurrentMethod());
                    IList<string> selectedPaths = openDialog.FileNames.ToList();

                    

                    return selectedPaths;
                }
                else
                {
                    TomsLogger.Log(LogType.Warning, "User did not choose images in file dialog", GetType().Name, MethodBase.GetCurrentMethod());
                    MessageBox.Show("You did not select any images to add!");
                    return null;
                }
            }
        }
    }
}
