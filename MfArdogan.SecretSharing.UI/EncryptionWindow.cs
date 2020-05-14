using MfArdogan.SecretSharing.Kernel;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace MfArdogan.SecretSharing.UI
{
    public partial class EncryptionWindow : Form
    {
        public EncryptionWindow()
        {
            InitializeComponent();
            Image = (Bitmap)System.Drawing.Image.FromFile("lena.bmp");
        }

        private Sharing<Bitmap> sharingObjects;
        public Sharing<Bitmap> SharingObjects
        {
            get => sharingObjects; private set
            {
                sharingObjects = value;

                if (value == default)
                {
                    flowSharingObjects.Controls.Clear();
                    return;
                }

                foreach (var item in value)
                {
                    var sharingItems = new SharingItem();
                    sharingItems.Prepare(item);
                    flowSharingObjects.Controls.Add(sharingItems);
                }
            }
        }

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

        void btnSelectImage_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog() { Filter = "Resim | *.png;*.jpg;*.png;*.bmp" };
            if (open.ShowDialog() != DialogResult.OK)
                return;
            Image = (Bitmap)System.Drawing.Image.FromFile(open.FileName);
        }

        void btnShare_Click(object sender, EventArgs e)
        {
            if (Image == default)
            {
                return;
            }

            int n = (int)numN.Value, k = (int)numK.Value;
            var secret = new SecretImageSharing(Image, n, k);
            SharingObjects = secret.Share();
        }

        void btnExport_Click(object sender, EventArgs e)
        {
            if (SharingObjects == default || SharingObjects.IsEmpty)
            {
                return;
            }

            var browser = new FolderBrowserDialog() { ShowNewFolderButton = true };
            if (browser.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            foreach (var (number, img) in SharingObjects)
            {
                var path = Path.Combine(browser.SelectedPath, $"{number}.png");
                img.Save(path, ImageFormat.Png);
            }
        }

        void btnExpose_Click(object sender, EventArgs e)
        {
            new DecryptionWindow().Show();
        }
    }
}
