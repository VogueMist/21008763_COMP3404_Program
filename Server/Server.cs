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
        public void LoadDefaultImages()
        {
            string[] defaultFilePaths = Directory.GetFiles("Assets");
            //What if folder is missing? - NEEDS ADDING -
            foreach (string filePath in defaultFilePaths)
            {
                try
                {
                    // Adds image to the dictionary, using the fileName as the pUid and actual image from the filepath
                    _imageStore.Add(Path.GetFileName(filePath), Image.FromFile(filePath));
                }
                catch
                {
                    MessageBox.Show($"{Path.GetFileName(filePath)} - Invalid file type in the asset folder - This has been skipped", "Skipping wrong file type");
                }
            }
        }
        public IList<string> ComboBox()
        {
            return new List<string>(_imageStore.Keys);
        }
        public IList<string> Load(IList<string> pPathfilenames)
        {
            //Holds uniqueIdentifies to be returned to the main form to show the user which images were added to the dictionary
            List<string> uniqueIdentifiers = new List<string>();
            //Holds images which were not added to the dictionary so the user can be alerted
            List<string> imagesNotAdded = new List<string>();
            if (pPathfilenames != null)
            {
                foreach (string filePath in pPathfilenames)
                {
                    try
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
                            imagesNotAdded.Add($"Duplicate - {Path.GetFileName(filePath)}");
                        }
                    }//Catch the error when files that are not images are added
                    catch (OutOfMemoryException)
                    {
                        //Add the file which is not an image to the imagesNotAdded list
                        imagesNotAdded.Add($"Not an image file - {Path.GetFileName(filePath)}");
                        //Continue past this file and skip it to miss the error
                        continue;
                        //Catch the error if the file can not be found
                    }catch (FileNotFoundException)
                    {
                        imagesNotAdded.Add($"File was not found! - {Path.GetFileName(filePath)}");
                    }
                }
            }

            else
            {
                MessageBox.Show("You did not select any images to add!");
            }
            if (imagesNotAdded.Count > 0)
            {
                //STRING which holds the duplicate warning message for the user
                string missingImagesWarning = "The images could not be added:\n";
                //Using string.Join goes through each element in the duplicateImages list and adds it to the original string message
                missingImagesWarning += string.Join("\n", imagesNotAdded);
                //Display the duplicate images added in a message box informing the user
                MessageBox.Show(missingImagesWarning, "Some images weren't added");
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