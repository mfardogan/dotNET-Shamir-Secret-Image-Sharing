using MfArdogan.SecretSharing.Kernel;
using MfArdogan.SecretSharing.Kernel.Encrypters;
using MfArdogan.SecretSharing.Kernel.Factories;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MfArdogan.SecretSharing.UI
{
    public partial class TextDecryptionWindow : Form
    {
        public TextDecryptionWindow()
        {
            InitializeComponent();
            FactoryObject = new FactoryDirector<byte[]>(
                    new BufferSharingAbstractFactory()
               );
        }

        public FactoryDirector<byte[]> FactoryObject { get; set; }

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


        void btnReadFile_Click(object sender, System.EventArgs e)
        {
            var open = new OpenFileDialog() { Filter = "Tect | *.txt", Multiselect = true };
            if (open.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var vs = new List<byte[]>();
            foreach (var item in open.FileNames.OrderBy(x => int.Parse(Path.GetFileNameWithoutExtension(x))))
            {
                var bytes = Encoding.UTF8.GetBytes(File.ReadAllText(item));
                vs.Add(bytes);
            }

            Sharing<byte[]> ps = Sharing<byte[]>.CreateSharingDictionary(vs);
            SharingObjects = ps;

        }

        void btnDecrypt_Click(object sender, System.EventArgs e)
        {
            if (SharingObjects == default || SharingObjects.IsEmpty)
            {
                return;
            }

            DecrypterKernel<byte[]> decrypter = FactoryObject.GetDecrypter(
                      sharingObjects,
                            new XorKeyEncrypter()
                );
            var buffer = decrypter.Decrypt();
            richTextBox1.Text = Encoding.UTF8.GetString(buffer);
        }
    }
}
