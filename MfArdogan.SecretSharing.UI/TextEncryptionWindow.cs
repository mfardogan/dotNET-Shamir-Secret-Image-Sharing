using MfArdogan.SecretSharing.Kernel;
using MfArdogan.SecretSharing.Kernel.Factories;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MfArdogan.SecretSharing.UI
{
    public partial class TextEncryptionWindow : Form
    {
        public TextEncryptionWindow()
        {
            InitializeComponent();
            Factory = new FactoryDirector<byte[]>(
                  new BufferSharingAbstractFactory()
             );
        }
        public FactoryDirector<byte[]> Factory { get; set; }

        private Sharing<byte[]> sharingObjects;
        public Sharing<byte[]> SharingObjects
        {
            get => sharingObjects; private set
            {
                sharingObjects = value;

                if (value == default)
                {
                    dataGridView1.DataSource = null;
                    return;
                }

                var source = value.Select(x => new
                {
                    Share = x.number,
                    Value = Encoding.UTF8.GetString(x.value)
                }).ToList();
                dataGridView1.DataSource = source;
                dataGridView1.Refresh();
            }
        }

        private string text;
        public string SecretText
        {
            get => text;
            private set
            {
                text = value;
                richTextBox1.Text = value;
            }
        }

        void btnReadFile_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog() { Filter = "Metin | *.txt;*.rtf" };
            if (open.ShowDialog() != DialogResult.OK)
                return;

            SecretText = File.ReadAllText(open.FileName);
        }

        void btnShare_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SecretText) && string.IsNullOrEmpty(richTextBox1.Text))
            {
                return;
            }

            SecretText = richTextBox1.Text;
            var buffer = Encoding.UTF8.GetBytes(SecretText);
            var decrypter = Factory.GetEncrypter(buffer, (int)numN.Value, (int)numK.Value, null);
            SharingObjects = decrypter.Share();
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

            var files = SharingObjects.Select(x => new
            {
                Share = x.number,
                Value = Encoding.UTF8.GetString(x.value)
            });

            foreach (var item in files)
            {
                var path = Path.Combine(browser.SelectedPath, $"{item.Share}.txt");
                File.WriteAllText(path, item.Value);
            }
        }

        void btnExpose_Click(object sender, EventArgs e)
        {
            new TextDecryptionWindow().Show();
        }
    }
}
