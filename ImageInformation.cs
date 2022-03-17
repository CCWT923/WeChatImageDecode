using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatImageDecode
{
    internal class ImageInformation
    {
        /*
         * 文件头：
         *  jpg 文件：0xFFD8FF
         *  png 文件：0x89504E47
         *  gif 文件：0x47494638
         *  bmp 文件：0x424D
         */

        /// <summary>
        /// 图片文件头前两个字节的值
        /// </summary>
        public enum ImageHeaderValue : byte
        {
            JpegHeaderValue1 = 0xFF,
            JpegHeaderValue2 = 0xD8,
            PngHeaderValue1 = 0x89,
            PngHeaderValue2 = 0x50,
            GifHeaderValue1 = 0x47,
            GifHeaderValue2 = 0x49,
            BmpHeaderValue1 = 0x42,
            BmpHeaderValue2 = 0x4D
        }

        /// <summary>
        /// 图片格式
        /// </summary>
        public enum ImageFormat
        {
            GIF,
            BMP,
            PNG,
            JPG,
            UNKNOW
        }

        public void GetImageFormat(string fileName, out int decodeValue, out ImageFormat imageFormat)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                //获取文件的前两位
                byte[] data = new byte[2];
                fs.Read(data, 0, 2);
                //判断图片格式，将图片的前两个字节和对应的文件头进行异或操作
                if ((data[0] ^ (byte)ImageHeaderValue.JpegHeaderValue1) == (data[1] ^ (byte)ImageHeaderValue.JpegHeaderValue2))
                {
                    imageFormat = ImageFormat.JPG;
                    decodeValue = data[0] ^ (byte)ImageHeaderValue.JpegHeaderValue1;
                }
                else if ((data[0] ^ (byte)ImageHeaderValue.PngHeaderValue1) == (data[1] ^ (byte)ImageHeaderValue.PngHeaderValue2))
                {
                    imageFormat = ImageFormat.PNG;
                    decodeValue = data[0] ^ (byte)ImageHeaderValue.PngHeaderValue1;
                }
                else if ((data[0] ^ (byte)ImageHeaderValue.GifHeaderValue1) == (data[1] ^ (byte)ImageHeaderValue.GifHeaderValue2))
                {
                    imageFormat = ImageFormat.GIF;
                    decodeValue = data[0] ^ (byte)ImageHeaderValue.GifHeaderValue1;
                }
                else if ((data[0] ^ (byte)ImageHeaderValue.BmpHeaderValue1) == (data[1] ^ (byte)ImageHeaderValue.BmpHeaderValue2))
                {
                    imageFormat = ImageFormat.BMP;
                    decodeValue = data[0] ^ (byte)ImageHeaderValue.BmpHeaderValue1;
                }
                else
                {
                    imageFormat = ImageFormat.UNKNOW;
                    decodeValue = 0;
                }

            }
        }

        public byte[] DecodeImage(string fileName, int encodeValue)
        {
            byte[] imgData ;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                imgData = new byte[fs.Length];
                var readLength = 0;
                var totalLen = imgData.Length;
                while(totalLen > 0)
                {
                    int n = fs.Read(imgData, readLength, totalLen);
                    if (n == 0)
                    {
                        break;
                    }
                    readLength += n;
                    totalLen -= n;
                }
                //对每个字节进行异或操作
                for(int i = 0; i < imgData.Length; i++)
                {
                    imgData[i] = (byte)(imgData[i] ^ encodeValue);
                }
            }
            return imgData;
        }
    }

}
