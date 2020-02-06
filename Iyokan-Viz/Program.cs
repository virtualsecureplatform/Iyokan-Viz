using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Iyokan_Viz
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            for (int cycle = 0; cycle < 130; cycle++)
            {
                Bitmap img = new Bitmap(160, 130);
                StreamReader sr = new StreamReader($"/tmp/ram_dump/{cycle}.dump", Encoding.GetEncoding("UTF-8"));
                var data = new byte[26];
                for (int i = 0; i < 13; i++)
                {
                    string[] str = sr.ReadLine().Split(' ');
                    data[i * 2 + 1] = Convert.ToByte(str[1], 16);
                    str = sr.ReadLine().Split(' ');
                    data[i * 2] = Convert.ToByte(str[1], 16);
                }
                sr.Close();
                Graphics g = Graphics.FromImage(img);
                g.FillRectangle(Brushes.Black, g.VisibleClipBounds);
                for (int i = 0; i < 13; i++)
                {
                    for (int j = 0;j < 8; j++)
                    {
                        if (((data[i * 2] >> (7-j)) & 0x1) == 0x0)
                        {
                            g.FillRectangle(Brushes.White, j*10, i*10, 10, 10);
                        }
                        if (((data[i * 2+1] >> (7-j)) & 0x1) == 0x0)
                        {
                            g.FillRectangle(Brushes.White, j*10+80, i*10, 10, 10);
                        }
                    }
                }
                g.Dispose();
                
                img.Save($"enc/{cycle}.gif", ImageFormat.Gif);
            }
            */
            for (int i = 0; i < 120; i++)
            {
                var img_plain = Image.FromFile($"plain/{i}.gif");
                var img_enc = Image.FromFile($"enc/{i}.gif");
                var img_integrate = new Bitmap(340, 130);
                var g = Graphics.FromImage(img_integrate);
                g.DrawImage(img_plain, 0, 0, img_plain.Width, img_plain.Height);
                g.DrawImage(img_enc, 180, 0, img_enc.Width, img_enc.Height);
                g.Dispose();
                img_integrate.Save($"integrate/{i}.gif", ImageFormat.Gif);
            }
        }
    }
}