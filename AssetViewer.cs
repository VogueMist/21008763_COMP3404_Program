﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21008763_COMP3404_Program
{
    public partial class AssetViewer : Form
    {
        private readonly IServer server;
        public AssetViewer(IServer server)
        {
            InitializeComponent();
            this.server = server;

            selectedImage.SizeMode = PictureBoxSizeMode.Zoom;


           // selectedImage.Visible = false;
            PopulateComboBox();
        }

        /// <summary>
        /// Method handling when the add images button is clicked, will open file explorer to select image(s)
        /// </summary>
        /// <param name="sender">The object which triggered the event</param>
        /// <param name="e">Brings in different event argument types capabale of the object</param>
        private void addImagesBtn_Click(object sender, EventArgs e)
        {
            bool saveImages = saveImageChbx.Checked;

            //Is it better to call FileDialogManager class directly or go through Server?
            FileDialogManager fileDialogManeger = new FileDialogManager();

            server.Load(fileDialogManeger.FileDialog(saveImages));
            PopulateComboBox();
        }

        /// <summary>
        /// Method to handle when an image is selected in the combobox
        /// </summary>
        private void imageDropDown_Select(object sender, EventArgs e)
        {
            string chosenImageName = imageDropDown.SelectedItem?.ToString();

            Image chosenImage = server.GetImage(chosenImageName, 1000, 1000);
            selectedImage.Image = chosenImage;
        }
        /// <summary>
        /// Populates the ComboBox with the list of image file paths
        /// </summary>
        private void PopulateComboBox()
        {
            TomsLogger.Log(LogType.Log, "ComboBox populated!", GetType().Name, MethodBase.GetCurrentMethod());
            //Clear all of the available images before adding the updated list
            imageDropDown.Items.Clear();
            imageDropDown.Items.AddRange(server.ComboBox().ToArray());
        }
    }
}