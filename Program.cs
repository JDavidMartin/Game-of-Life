using System;
using gridSpace;
using System.Threading;
using System.IO;
using System.Text;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;

            grid MyGrid = new grid(100, 100);
            MyGrid.initiateGrid();

            var gif = MyGrid.CreateNewBitmapImage();

            int iteration = 0;
            while (iteration < 1000)
            {
                MyGrid.UpdateGrid();
                iteration++;
                Console.WriteLine(iteration);

                Image newImage = MyGrid.CreateNewBitmapImage();
                gif.Frames.InsertFrame(iteration, newImage.Frames.RootFrame);
            }
            gif.Save("result.gif");
        }
    }
}
