namespace pixelSpace
{
    public class pixel
    {
        private int xPos;
        private int yPos;
        private bool alive;
        private int numNeighbours;

        public pixel(int x, int y, bool living)
        {
            xPos = x;
            yPos = y;
            alive = living;
            numNeighbours = 0;
        }

        public int getX()
        {
            return xPos;
        }
        public int getY()
        {
            return yPos;
        }
        public bool isAlive()
        {
            return alive;
        }
        public int isAliveInt()
        {
            return (alive ? 1 : 0);
        }
        public void SetStatus(bool newStatus)
        {
            alive = newStatus;
        }
        public void SetNumNeighbours(int numberNeighbours)
        {
            numNeighbours = numberNeighbours;
        }
        public int getNumberNeighbours(){
            return numNeighbours;
        }


    }
}