//Author - Tom 21008763
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
    /// <summary>
    /// CLASS to handle all data that is needed in the AssetViewer class like images. Handles functions for image management also
    /// </summary>
    public class Server : IServer
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        //DECLARE dictionary for the image storage, will store the file name of image and the image file itself
        private Dictionary<string, Image> _imageStore;
        public Server()
        {
            _imageStore = new Dictionary<string, Image>();
            //Runs the inital collection of images to add to dictionary
            LoadDefaultImages();
        }

        /// <summary>
        /// METHOD to load the default images found in the Assets folder of the project - This just adds them to the dictionary ready for when the PopulateComboBox method is called in AssetViwer.cs
        /// </summary>
        public void LoadDefaultImages()
        {
            string[] defaultFilePaths = Directory.GetFiles("Assets", "*.png");
            foreach (string filePath in defaultFilePaths)
            {
                //Adds image to the dictionary, using the fileName as the pUid and actual image from the filepath
                _imageStore.Add(Path.GetFileName(filePath), Image.FromFile(filePath));
            }
        }

        /// <summary>
        /// METHOD that returns the values in the _imageStore dictionary for the ComboBox to populate
        /// </summary>
        /// <returns>The Dictionary called _imageStore</returns>
        public IList<string> ComboBox()
        {
            return new List<string>(_imageStore.Keys); 
        }

        /// <summary>
        /// METHOD to load a new image or multiple images into the dictionary. This includes a feature to save the image added to the Assets folder
        /// </summary>
        /// <param name="pPathfilenames">The file paths for each image selected in the fileDialog</param>
        /// <returns>Returns the uniqueIdentifiers to alert the users what images were added</returns>
        public IList<string> Load(IList<string> pPathfilenames)
        {
            List<string> uniqueIdentifiers = new List<string>();
            List<string> duplicateImages = new List<string>();
                foreach (string filePath in pPathfilenames) 
                {
                    //Check if each image has already been added to the Dictionary imageStore
                    if (!_imageStore.ContainsKey(Path.GetFileName(filePath)))
                    {
                    //Grabs a copy of the actual image from the file path
                        Image image = Image.FromFile(filePath);
                    //Adds the image to the dictionary using its file name and image data
                        _imageStore.Add(Path.GetFileName(filePath), image);
                    //Adds the file name to uniqueIdentifiers list to return to user later
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
                //STRING which holds the duplicate warning message for the user
                    string duplicateWarning = "These images are already in the gallery:\n";
                //Using string.Join goes through each element in the duplicateImages list and adds it to the original string message
                    duplicateWarning += string.Join("\n", duplicateImages);
                //Display the duplicate images added in a message box informing the user
                    MessageBox.Show(duplicateWarning, "Duplicate images added!");
                }
                return uniqueIdentifiers;
         }

        /// <summary>
        /// METHOD to request a copy of the image specified by 'pUid', scaled according to the dimensions given by pFrameWidth and pFrameHeight.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image requested</param>
        /// <param name="pFrameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pFrameHeight">the height (in pixles) of the 'frame' it is to occupy</param>
        /// <returns>the Image identified by pUid</returns>
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