using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NLog;
using System.Windows.Forms;

namespace _21008763_COMP3404_Program
{
    public class Server : IServer
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private Dictionary<string, Image> _imageStore;

        public Server()
        {
            _imageStore = new Dictionary<string, Image>();
            LoadDefaultImages();
        }

        /// <summary>
        /// Method to load the default images found in the Assets folder of the project - This just adds them to the dictionary ready for when the PopulateComboBox method is called in AssetViwer.cs
        /// </summary>
        public void LoadDefaultImages()
        {
            string[] defaultFilePaths = Directory.GetFiles("Assets", "*.png");
            foreach (string filePath in defaultFilePaths)
            {
                string fileName = Path.GetFileName(filePath);
                Image tempImage = Image.FromFile(filePath);
                _imageStore.Add(fileName, tempImage);
            }
        }

        public IList<string> ComboBox()
        {
            return new List<string>(_imageStore.Keys); 
        }

        public IList<string> Load(IList<string> pPathfilenames)
        {
            List<string> uniqueIdentifiers = new List<string>();
            List<string> duplicateImages = new List<string>();
                foreach (string filePath in pPathfilenames) 
                {
                    //Check if each image has already been added to the Dictionary imageStore
                    if (!_imageStore.ContainsKey(Path.GetFileName(filePath)))
                    {
                        Image image = Image.FromFile(filePath);

                        _imageStore.Add(Path.GetFileName(filePath), image);
                        uniqueIdentifiers.Add(Path.GetFileName(filePath));
                    }
                    else
                    {
                        //If image is a duplicate add it to list to tell user later
                        duplicateImages.Add(Path.GetFileName(filePath));
                    }
                }
                if (duplicateImages.Count > 0)
                {
                    string duplicateWarning = "These images are already in the gallery:\n";
                    duplicateWarning += string.Join("\n", duplicateImages);
                    MessageBox.Show(duplicateWarning, "Duplicate images added!");
                }
                return uniqueIdentifiers;
         }
        

        public Image GetImage(string pUid, int pFrameWidth, int pFrameHeight)
        {
            if (_imageStore.ContainsKey(pUid))
            {
                Image originalImage = _imageStore[pUid];
                // Add scaling to image, how is that going to work? --TODO
                Logger.Info($"Image displayed: {pUid}");
                return originalImage;
            }
            else
            {
                // Add exception or add sample image if image was not found in the dictionary --TODO
                Logger.Info("Could not Get Image");
                return null;
            }
        }
    }
}