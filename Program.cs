using System;
using gridSpace;
using DrawingSpace;

using SixLabors.ImageSharp;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            grid MyGrid = new grid(100, 100);
            MyGrid.initiateGrid();

            DrawingClass drawing= new DrawingClass();
            Image gif = drawing.DrawGrid(MyGrid);

            int iteration = 0;
            while (iteration < 1000)
            {
                MyGrid.UpdateGrid();
                iteration++;
                Console.WriteLine(iteration);

                Image newImage = drawing.DrawGrid(MyGrid);
                gif.Frames.InsertFrame(iteration, newImage.Frames.RootFrame);
            }
            gif.Save("result.gif");
        }
    }
}
