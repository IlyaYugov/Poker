using System;
using System.Drawing;
using System.IO;
using System.Linq;
using IronOcr;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"C:\Projects\Poker\qwe\step4");

            foreach (var file in files)
            {
                var image = (Bitmap)Image.FromFile(file);

                var middleHight = image.Height / 2;

                var middlePixels = new int[image.Width];

                for (int i = 0; i < image.Width; i++)
                {
                    middlePixels[i] = image.GetPixel(i, middleHight).ToArgb();
                }

                var middleColor = middlePixels.Sum() / middlePixels.Length;

                var maxColor = middlePixels.Max();

                var minColor = middlePixels.Min();

                var ert = (double)maxColor / minColor;

                var diff = (maxColor - minColor) / ert;

                for (int i = 0; i < image.Height; i++)
                {
                    for (int j = 0; j < image.Width; j++)
                    {
                        var currentColor = image.GetPixel(j, i).ToArgb();

                        if (Math.Abs(currentColor) <= Math.Abs(middleColor) - 2000000)
                        {
                            currentColor = 0;

                        }
                        else ///if(Math.Abs(currentColor) < Math.Abs(maxColor))
                        {
                            currentColor = int.MaxValue;
                        }

                        image.SetPixel(j, i, Color.FromArgb(currentColor));
                    }
                }

                var newImage = (Image)image;

                var index = file.LastIndexOf('\\') + 1;
                var count = file.Length - index;

                var fileName = file.Substring(index, count);

                newImage.Save($@"C:\Projects\Poker\qwe\step4\myInverted\{fileName}.png");
            }



            files = Directory.GetFiles(@"C:\Projects\Poker\qwe\step4\MyInverted");
            AutoOcr OCR = new AutoOcr() { ReadBarCodes = false };
            var Results = OCR.Read(files);
            Console.WriteLine(Results.Text);
        }
    }
}
