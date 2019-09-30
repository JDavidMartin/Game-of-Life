using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using pixelSpace;
using gridSpace;

namespace DrawingSpace
{
    class DrawingClass
    {

        public DrawingClass()
        {
            
        }
        public Image DrawGrid(grid grid)
        {
            int maxRows = grid.maxRows;
            int maxCols = grid.maxColumns;

            var image = new Image<Rgba32>(maxRows, maxCols);


            for (int row = 0; row < maxRows; row++)
            {
                for (int column = 0; column < maxCols; column++)
                {
                    pixel pixelToDraw = grid.getPixel(row, column);
                    if (pixelToDraw.isAlive())
                    {
                        image[row, column] = Rgba32.White;
                    }
                    else
                    {
                        image[row, column] = Rgba32.Black;
                    }
                }
            }

            return image;

        }

    }

}