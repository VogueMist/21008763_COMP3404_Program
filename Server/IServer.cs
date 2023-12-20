//Author - Brad
//Edited by - Tom 21008763
using System;
using System.Collections.Generic;
using System.Drawing;

namespace _21008763_COMP3404_Program
{
    public interface IServer
    {
        /// <summary>
        /// Load the media items pointed to by 'pathfilenames' into the Server's data store.
		/// The strings in the collection act as unique identifiers for images in the Server's data store.
        /// </summary>
        /// <param name="pPathfilenames">a collection of one or more strings; each string containing path/filename for an image file to be loaded</param>
        /// <returns>the unique identifiers of the images that have been loaded</returns>
        IList<String> Load(IList<String> pPathfilenames);

        /// <summary>
        /// METHOD to load the default images found in the Assets folder of the project - This just adds them to the dictionary ready for when the PopulateComboBox method is called in AssetViwer.cs
        /// </summary>
        void LoadDefaultImages();

        /// <summary>
        /// METHOD that returns the values in the _imageStore dictionary for the ComboBox to populate
        /// </summary>
        /// <returns>The Dictionary keys (Filename of image)</returns>
        IList<string> ComboBox();

        /// <summary>
        /// Request a copy of the image specified by 'pUid', scaled according to the dimensions given by pFrameWidth and pFrameHeight.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image requested</param>
        /// <param name="pFrameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pFrameHeight">the height (in pixles) of the 'frame' it is to occupy</param>
        /// <returns>the Image identified by pUid</returns>
        Image GetImage(String pUid, int pFrameWidth, int pFrameHeight);
    }
}