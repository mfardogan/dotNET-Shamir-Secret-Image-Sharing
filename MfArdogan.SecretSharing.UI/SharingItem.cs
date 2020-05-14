using System.Drawing;
using System.Windows.Forms;

namespace MfArdogan.SecretSharing.UI
{
    public partial class SharingItem : UserControl
    {
        public SharingItem()
        {
            InitializeComponent();
        }

        public void Prepare((int number, Bitmap value) values)
        {
            lblNumber.Text = $"Pay: {values.number}";
            pbImage.Image = values.value;
        }
    }
}
