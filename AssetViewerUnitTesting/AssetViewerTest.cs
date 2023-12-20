using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _21008763_COMP3404_Program;
using System.Collections.Generic;
using System.Linq;

namespace AssetViewerUnitTesting
{
    [TestClass]
    public class Program_Launch_Populates_Combobox
    {
        int x;
        bool count = true;
        IServer server = new Server();
        //Used to hold the uniqueID array of images temporarily
        IList<string> tempUidStore = new List<string>();
        //Used to hold paths for adding duplicate images to the dictionary
        List<string> duplicateImagePaths = new List<string>();
        //Used to hold the non image filepath
        List<string> notImage = new List<string>();
        //Hold the return value if any from the Load function in server
        IList<string> returnLoad = new List<string>();
        //Hold path for a file which does not exist
        List<string> notAFile = new List<string>();

        /// <summary>
        /// Check that the whole Asset folder is loaded into the program when it runs
        /// </summary>
        [TestMethod]
        public void TestLoadUp()
        {
            //Load the uniqueIDs into a List
            tempUidStore = server.ComboBox().ToArray();
            //Check that there are 9 images at loadup only(in Asset folder)
            Assert.IsTrue(tempUidStore.Count > 0);
        }

        /// <summary>
        /// Check if the program adds duplicate images if they are already in the dictionary
        /// </summary>
        [TestMethod]
        public void Load_Does_Not_Add_Duplicates()
        {
            //Add duplicate image paths to the temporary list
            duplicateImagePaths.Add("C:\\Users\\Tom\\source\\repos\\AssetViewerUnitTesting\\bin\\Debug\\Assets\\AnglerFish_Lit.png");
            duplicateImagePaths.Add("C:\\Users\\Tom\\source\\repos\\AssetViewerUnitTesting\\bin\\Debug\\Assets\\AquariumBackground.png");
            //Use Load method in server to try to load the duplicate images
            server.Load(duplicateImagePaths);
            //Call List containing uniqueIds for images to see what is inside
            tempUidStore = server.ComboBox().ToArray();
            //Check if duplicate images were added or not - default asset folder contains 9 items
            Assert.AreEqual(9, tempUidStore.Count());
        }

        /// <summary>
        /// Check if the Load function in server loads non image files
        /// </summary>
        [TestMethod]
        public void Load_Does_Not_Accept_Non_Images()
        {
            notImage.Add("C:\\Users\\Tom\\source\\repos\\AssetViewerUnitTesting\\bin\\Debug\\Assets\\notanimage.txt");
            notImage.Add("C:\\Users\\Tom\\Desktop\\image-not-found.png");
            returnLoad = server.Load(notImage);
            //Should equal 1 because only 1 image file should have been added as one is not an image
            Assert.AreEqual(1, returnLoad.Count());
        }

        /// <summary>
        /// Test if the load function accepts non existent files
        /// </summary>
        [TestMethod]
        public void Load_Ignores_Non_Files()
        {
            //Add the non existent file
            notAFile.Add("C:\\Users\\Tom\\source\\repos\\AssetViewerUnitTesting\\bin\\Debug\\Assets\\jasbdfkasjbd.png");
            //Add the actual image
            notAFile.Add("C:\\Users\\Tom\\Desktop\\image-not-found.png");
            returnLoad = server.Load(notAFile);
            //Check if the actual image is still added and it skips the non file
            Assert.AreEqual(1, returnLoad.Count());
        }
    }
}
