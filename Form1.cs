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
            if(TextBox_SourceFolder.Text.Trim() == "" || !Directory.Exists(TextBox_SourceFolder.Text.Trim()))
            {
                return;
            }
            if(string.IsNullOrEmpty(TextBox_TargetFolder.Text.Trim()))
            {
                return;
            }

            if(!Directory.Exists(TextBox_TargetFolder.Text))
            {
                Directory.CreateDirectory(TextBox_TargetFolder.Text);
            }

            ImageInformation imgInfo = new ImageInformation();
            int unknow = 0;
            int gif = 0;
            int jpg = 0;
            int png = 0;
            int bmp = 0;
            foreach (var file in Directory.GetFiles(TextBox_SourceFolder.Text))
            {
                if (Path.GetExtension(file).ToLower() != ".dat")
                    continue;

                imgInfo.GetImageFormat(file, out int decodeValue, out ImageInformation.ImageFormat imgFormat);

                if(imgFormat == ImageInformation.ImageFormat.PNG)
                {
                    png++;
                }
                else if(imgFormat == ImageInformation.ImageFormat.BMP)
                {
                    bmp++;
                }
                else if(imgFormat == ImageInformation.ImageFormat.GIF)
                {
                    gif++;
                }
                else if(imgFormat == ImageInformation.ImageFormat.JPG)
                {
                    jpg++;
                }
                else
                {
                    unknow++;
                    continue;
                }

                var fileName = TextBox_TargetFolder.Text + "\\" + Path.GetFileNameWithoutExtension(file) + "." + Enum.GetName(typeof(ImageInformation.ImageFormat), imgFormat).ToLower();

                using(FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(imgInfo.DecodeImage(file, decodeValue));
                }

            }

            MessageBox.Show($"{(jpg > 0 ? $"���� JPG ��ʽ {jpg} ����" : "")}{(png > 0 ? $"PNG ��ʽ {png} ����" : "" )}{(gif > 0 ? $"GIF ��ʽ {gif} ����" : "")}{(bmp > 0 ? $"BMP ��ʽ {bmp} ����" : "")}{(unknow > 0 ? $"δ֪��ʽ {unknow} ��" : "")}");
        }


        private void FolderBrowser(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if(((Button)sender).Tag.ToString() == "source")
                {
                    TextBox_SourceFolder.Text = dialog.SelectedPath;
                }
                else
                {
                    TextBox_TargetFolder.Text = dialog.SelectedPath;
                }
            }
        }
    }
}