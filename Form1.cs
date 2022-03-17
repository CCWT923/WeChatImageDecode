using System.IO;

namespace WeChatImageDecode
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                ImageInformation imgInfo = new ImageInformation();
                imgInfo.GetImageFormat(ofd.FileName, out int decode, out ImageInformation.ImageFormat format);
                FileStream fs = new FileStream(Path.GetDirectoryName(ofd.FileName) + "\\"+ Path.GetFileNameWithoutExtension(ofd.FileName) + "." + Enum.GetName(typeof(ImageInformation.ImageFormat), format), FileMode.Create, FileAccess.Write);
                var bytes = imgInfo.DecodeImage(ofd.FileName, decode);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }
        }

        
    }
}