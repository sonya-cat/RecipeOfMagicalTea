using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace MapFromBmp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int k = 0; k < 6; k++)
            {
                var bitmap = new Bitmap("LocationMap" + k + ".bmp");
                var brightnessArray = GetBrightnessArray(bitmap);

                using (StreamWriter stream = new StreamWriter("LocationMap" + k + ".txt"))
                {
                    for (int i = 0; i < brightnessArray.Length; i++)
                    {
                        for (int j = 0; j < brightnessArray[0].Length; j++)
                            stream.Write("{0} ", brightnessArray[i][j] / 40);
                        stream.WriteLine();
                    }
                }
            }

        }

        public static int[][] GetBrightnessArray(Bitmap srcImage)
        {
            if (srcImage == null)
                throw new ArgumentNullException("srcImage");

            int[][] result = new int[srcImage.Height][];
            for (var y = 0; y < srcImage.Height; y++)
            {
                result[y] = new int[srcImage.Width];
                for (var x = 0; x < srcImage.Width; x++)
                {
                    Color srcPixel = srcImage. GetPixel(x, y);
                    result[y][x] = (srcPixel.B + srcPixel.G + srcPixel.R)/3;
                }
            }

            return result;
        }
    }
}
