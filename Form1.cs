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
            ImageTypeCounter counter;
            if(FilesDropIn.Count > 0)
            {
                counter = DecodeFiles(FilesDropIn.ToArray<string>());
            }
            else
            {
                if (TextBox_SourceFolder.Text.Trim() == "" || !Directory.Exists(TextBox_SourceFolder.Text.Trim()))
                {
                    return;
                }
                if (string.IsNullOrEmpty(TextBox_TargetFolder.Text.Trim()))
                {
                    return;
                }

                if (!Directory.Exists(TextBox_TargetFolder.Text))
                {
                    Directory.CreateDirectory(TextBox_TargetFolder.Text);
                }
                counter = DecodeFiles(Directory.GetFiles(TextBox_SourceFolder.Text),TextBox_TargetFolder.Text);
            }
            

            MessageBox.Show($"{(counter.JPG > 0 ? $"处理 JPG 格式 {counter.JPG} 个，" : "")}{(counter.PNG > 0 ? $"PNG 格式 {counter.PNG} 个，" : "" )}{(counter.GIF > 0 ? $"GIF 格式 {counter.GIF} 个，" : "")}{(counter.BMP > 0 ? $"BMP 格式 {counter.BMP} 个，" : "")}{(counter.UNKNOW > 0 ? $"未知格式 {counter.UNKNOW} 个" : "")}");
            FilesDropIn.Clear();
            
        }


        private ImageTypeCounter DecodeFiles(string[] files, string targetFolder = "")
        {
            ImageTypeCounter counter = new ImageTypeCounter();
            WeChatImageDecoder imgInfo = new WeChatImageDecoder();

            foreach (var file in files)
            {
                if (Path.GetExtension(file).ToLower() != ".dat")
                    continue;

                imgInfo.GetImageFormat(file, out int decodeValue, out WeChatImageDecoder.ImageFormat imgFormat);

                if (imgFormat == WeChatImageDecoder.ImageFormat.PNG)
                {
                    counter.PNG++;
                }
                else if (imgFormat == WeChatImageDecoder.ImageFormat.BMP)
                {
                    counter.BMP++;
                }
                else if (imgFormat == WeChatImageDecoder.ImageFormat.GIF)
                {
                    counter.GIF++;
                }
                else if (imgFormat == WeChatImageDecoder.ImageFormat.JPG)
                {
                    counter.JPG++;
                }
                else
                {
                    counter.UNKNOW++;
                    continue;
                }

                if(string.IsNullOrEmpty(targetFolder))
                {
                    targetFolder = Path.GetDirectoryName(file);
                }
                var fileName = Path.Combine(targetFolder, Path.GetFileNameWithoutExtension(file) + "." + Enum.GetName(typeof(WeChatImageDecoder.ImageFormat), imgFormat).ToLower());

                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(imgInfo.DecodeImage(file, decodeValue));
                }
            }
            return counter;
        }

        struct ImageTypeCounter
        {
            public int JPG { get; set; }
            public int PNG { get; set; }
            public int BMP { get; set; }
            public int GIF { get; set; }
            public int UNKNOW { get; set; }
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

        private void TextBox_SourceFolder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data == null) return;
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        static List<string> FilesDropIn = new List<string>();

        private void TextBox_SourceFolder_DragDrop(object sender, DragEventArgs e)
        {
            if(e.Data == null) return;
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                foreach (var file in files)
                {
                    if(file.EndsWith(".dat"))
                    {
                        FilesDropIn.Add(file);
                    }
                }
                TextBox_SourceFolder.Text = $"共 {FilesDropIn.Count} 个文件";
            }
        }
    }
}