using NLog;
using System;
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
{/// <summary>
/// CLASS for the main AssetViewer form handles the form functions only - Data is taken through the Server Class
/// </summary>
    public partial class AssetViewer : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IServer _server;
        public AssetViewer(IServer server)
        {
            InitializeComponent();
            this._server = server;

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
            var saveImages = saveImageChbx.Checked;

            //Is it better to call FileDialogManager class directly or go through Server?
            FileDialogManager fileDialogManeger = new FileDialogManager();
            try
            {
                string imagesAdded = "Recently added:\n";
                IList<string> imageUids = new List<string>();
                imageUids = _server.Load(fileDialogManeger.FileDialog(saveImages));
                imagesAdded += string.Join("\n", imageUids);
                richTextBox1.Text = imagesAdded;
            }
            catch (System.Exception exc)
            {
                Logger.Fatal("Image(s) could not be loaded!");
                MessageBox.Show($"There wan an error: {exc}", "Error loading images!");
            }
            PopulateComboBox();
        }

        /// <summary>
        /// METHOD to handle when an image is selected in the combobox
        /// </summary>
        private void imageDropDown_Select(object sender, EventArgs e)
        {
            string chosenImageName = imageDropDown.SelectedItem?.ToString();

            Image chosenImage = _server.GetImage(chosenImageName, selectedImage.Width, selectedImage.Height);
            selectedImage.Image = chosenImage;
        }
        /// <summary>
        /// METHOD which populates the ComboBox with the list of image file paths
        /// </summary>
        private void PopulateComboBox()
        {
            Logger.Info("ComboBox populated!");
            //Clear all of the available images before adding the updated list
            imageDropDown.Items.Clear();
            imageDropDown.Items.AddRange(_server.ComboBox().ToArray());
        }
    }
}