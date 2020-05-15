using MfArdogan.SecretSharing.Kernel;
using MfArdogan.SecretSharing.Kernel.Factories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MfArdogan.SecretSharing.UI
{
    public partial class DecryptionWindow : Form
    {
        public DecryptionWindow()
        {
            InitializeComponent();

            Factory = new FactoryDirector<Bitmap>(
                new ImageSharingAbstractFactory()
                );
        }

        public FactoryDirector<Bitmap> Factory { get; set; }

        #region Properties
        private Bitmap image;
        public Bitmap Image
        {
            get => image;
            private set
            {
                image = value;
                pbSecretImage.Image = value;
            }
        }

        private Sharing<Bitmap> myVar;
        public Sharing<Bitmap> SharingObjects
        {
            get { return myVar; }
            private set
            {
                myVar = value;
                if (value == default)
                {
                    return;
                }

                foreach (var item in value)
                {
                    var shareitem = new SharingItem();
                    shareitem.Prepare(item);
                    flowSharingObjects.Controls.Add(shareitem);
                }
            }
        } 
        #endregion

        void btnShare_Click(object sender, EventArgs e)
        {
            if (SharingObjects == default || SharingObjects.IsEmpty)
            {
                return;
            }

            DecrypterKernel<Bitmap> decrypter = Factory.GetDecrypter(
                   SharingObjects, null
                );

            Image = decrypter.Decrypt();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog()
            {
                Multiselect = true,
                Filter = "Resim | *.png;*.jpg;*.png;*.bmp"
            };

            if (open.ShowDialog() != DialogResult.OK)
                return;

            var keyValuePairs = new Dictionary<int, Bitmap>();
            foreach (var item in open.FileNames)
            {
                var image = (Bitmap)System.Drawing.Image.FromFile(item);
                var number = int.Parse(Path.GetFileNameWithoutExtension(item));
                keyValuePairs.Add(number, image);
            }

            SharingObjects = new Sharing<Bitmap>(keyValuePairs);
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            if (Image == default)
            {
                return;
            }

            var dialog = new SaveFileDialog() { Filter = "Resim | *.png;*.jpg;*.png;*.bmp", FileName = "resim.png" };
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Image.Save(dialog.FileName);
        }
    }
}
