namespace AptechSchool
{
    partial class DisplayUsers
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainGallery = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            ((System.ComponentModel.ISupportInitialize)(this.mainGallery)).BeginInit();
            this.mainGallery.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainGallery
            // 
            this.mainGallery.Controls.Add(this.galleryControlClient1);
            this.mainGallery.DesignGalleryGroupIndex = 0;
            this.mainGallery.DesignGalleryItemIndex = 0;
            this.mainGallery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGallery.Location = new System.Drawing.Point(0, 0);
            this.mainGallery.Name = "mainGallery";
            this.mainGallery.Size = new System.Drawing.Size(702, 502);
            this.mainGallery.TabIndex = 1;
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.mainGallery;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(681, 498);
            // 
            // DisplayUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainGallery);
            this.Name = "DisplayUsers";
            this.Size = new System.Drawing.Size(702, 502);
            this.Load += new System.EventHandler(this.DisplayUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainGallery)).EndInit();
            this.mainGallery.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.GalleryControl mainGallery;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
    }
}
