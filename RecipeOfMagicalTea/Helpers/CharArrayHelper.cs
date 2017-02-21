using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeOfMagicalTea
{
    public class CharArrayHelper
    {
        public static void CopyCharArray(char[,] source, char[,] target, int sourceStartX = 0, int sourceStartY = 0, int targetStartX = 0, int targetStartY = 0)
        {
            var height = Math.Min(source.GetLength(0),target.GetLength(0));
            var width = Math.Min(source.GetLength(1), target.GetLength(1));

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    target[targetStartY + i, targetStartX + j] = source[i + sourceStartY, j + sourceStartX];
        }

        public static char[,] StringListToCharArray(List<string> stringList)
        {
            var height = stringList.Count;
            var width = stringList[0].Length;
            var charArray = SpaceArray(width, height);
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                    charArray[i, j] = stringList[i][j];
            }
            return charArray;
        }

        public static char[,] GetCharArrayFromFile(string fileName, int width, int height)
        {
            string[] stringLines = System.IO.File.ReadAllLines(fileName, Encoding.Default);

            var charArray = SpaceArray(width, height);

            int h = (stringLines.Length <= height) ? stringLines.Length : height;
            for (int i = 0; i < h; i++)
            {
                int w = (stringLines[i].Length <= width) ? stringLines[i].Length : width;
                for (int j = 0; j < w; j++)
                    charArray[i, j] = stringLines[i][j];
            }
            return charArray;
        }

        public static char[,] SpaceArray(int width, int height)
        {
            var charArray = new char[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    charArray[i, j] = ' ';
            return charArray;
        }
    }
}
