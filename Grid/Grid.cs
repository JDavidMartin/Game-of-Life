using System;
using pixelSpace;

namespace gridSpace
{
    class grid
    {
        public int maxRows { get; set; }
        public int maxColumns { get; set; }
        public pixel[,] Pixels { get; set; }


        public grid(int x, int y)
        {
            maxRows = x;
            maxColumns = y;
            Pixels = new pixel[x + 1, y + 1];

        }

        public void initiateGrid(int percentageLiving)
        {
            Random livingRNG = new Random();
            for (int i = 0; i <= maxRows; i++)
            {
                for (int j = 0; j <= maxColumns; j++)
                {
                    bool livingbool = (livingRNG.Next(0, 101) > percentageLiving);
                    Pixels[i, j] = new pixel(i, j, livingbool);
                }
            }
        }

        public pixel getPixel(int x, int y)
        {
            int xPos = Math.Abs((x + maxRows) % maxRows); // e.g. (-1+200) % 200 = 199  (20+200)%200 = 20
            int yPos = Math.Abs((y + maxColumns) % maxColumns);
            return Pixels[xPos, yPos];
        }

        public void UpdateGrid()
        {
            CalculateAndUpdateNumberNeighbours();

            for (int row = 0; row < maxRows; row++)
            {
                for (int column = 0; column < maxColumns; column++)
                {
                    pixel currentPixel = getPixel(row, column);
                    handleNeighbours(currentPixel);
                }
            }
        }

        private void CalculateAndUpdateNumberNeighbours()
        {
            for (int row = 0; row < maxRows; row++)
            {
                for (int column = 0; column < maxColumns; column++)
                {
                    pixel currentPixel = getPixel(row, column);
                    int numNeighbours = getNumNeighbours(row, column);
                    currentPixel.SetNumNeighbours(numNeighbours);
                }
            }

        }

        private int getNumNeighbours(int row, int column)
        {
            int numNeighbours = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if ((i == 0) && (j == 0))
                    {
                        continue;
                    };

                    int x = row + i;
                    int y = column + j;


                    if (getPixel(x, y) != null)
                    {
                        numNeighbours += getPixel(x, y).isAliveInt();
                    }
                }
            }
            return numNeighbours;
        }

        private void handleNeighbours(pixel IndividualPixel)
        {
            int numNeighbours = IndividualPixel.getNumberNeighbours();
            if (IndividualPixel.isAlive())
            {
                switch (numNeighbours)
                {
                    case (2): //2 or 3 just right
                        break;
                    case (3):
                        break;
                    default:
                        IndividualPixel.SetStatus(false); // 0,1 underpopulation - 4,5,6,7 overpopulation
                        break;
                }
            }
            else
            {
                switch (numNeighbours)
                {
                    case (3):
                        IndividualPixel.SetStatus(true);
                        break;
                    default:
                        break;
                }
            }
        }


    }

}