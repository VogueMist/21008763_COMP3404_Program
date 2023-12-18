namespace _21008763_COMP3404_Program
{
    partial class AssetViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectedImage = new System.Windows.Forms.PictureBox();
            this.addImagesBtn = new System.Windows.Forms.Button();
            this.imageDropDown = new System.Windows.Forms.ComboBox();
            this.saveImageChbx = new System.Windows.Forms.CheckBox();
            this.userInfoTxtBx = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.selectedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // selectedImage
            // 
            this.selectedImage.Location = new System.Drawing.Point(251, 12);
            this.selectedImage.Name = "selectedImage";
            this.selectedImage.Size = new System.Drawing.Size(555, 453);
            this.selectedImage.TabIndex = 1;
            this.selectedImage.TabStop = false;
            // 
            // addImagesBtn
            // 
            this.addImagesBtn.Location = new System.Drawing.Point(872, 181);
            this.addImagesBtn.Name = "addImagesBtn";
            this.addImagesBtn.Size = new System.Drawing.Size(95, 64);
            this.addImagesBtn.TabIndex = 2;
            this.addImagesBtn.Text = "Add Image(s)";
            this.addImagesBtn.UseVisualStyleBackColor = true;
            this.addImagesBtn.Click += new System.EventHandler(this.addImagesBtn_Click);
            // 
            // imageDropDown
            // 
            this.imageDropDown.FormattingEnabled = true;
            this.imageDropDown.Location = new System.Drawing.Point(12, 12);
            this.imageDropDown.Name = "imageDropDown";
            this.imageDropDown.Size = new System.Drawing.Size(208, 21);
            this.imageDropDown.TabIndex = 3;
            this.imageDropDown.DropDownClosed += new System.EventHandler(this.imageDropDown_Select);
            // 
            // saveImageChbx
            // 
            this.saveImageChbx.AutoSize = true;
            this.saveImageChbx.Location = new System.Drawing.Point(875, 158);
            this.saveImageChbx.Name = "saveImageChbx";
            this.saveImageChbx.Size = new System.Drawing.Size(89, 17);
            this.saveImageChbx.TabIndex = 4;
            this.saveImageChbx.Text = "Save Image?";
            this.saveImageChbx.UseVisualStyleBackColor = true;
            // 
            // userInfoTxtBx
            // 
            this.userInfoTxtBx.Location = new System.Drawing.Point(12, 158);
            this.userInfoTxtBx.Name = "userInfoTxtBx";
            this.userInfoTxtBx.Size = new System.Drawing.Size(223, 307);
            this.userInfoTxtBx.TabIndex = 5;
            this.userInfoTxtBx.Text = "";
            // 
            // AssetViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 482);
            this.Controls.Add(this.userInfoTxtBx);
            this.Controls.Add(this.saveImageChbx);
            this.Controls.Add(this.imageDropDown);
            this.Controls.Add(this.addImagesBtn);
            this.Controls.Add(this.selectedImage);
            this.Name = "AssetViewer";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.selectedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox selectedImage;
        private System.Windows.Forms.Button addImagesBtn;
        private System.Windows.Forms.ComboBox imageDropDown;
        private System.Windows.Forms.CheckBox saveImageChbx;
        private System.Windows.Forms.RichTextBox userInfoTxtBx;
    }
}

