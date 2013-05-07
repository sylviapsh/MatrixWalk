namespace WalkInMatrix
{
    public class Direction
    {
        private static readonly Position[] directions =
        {
            new Position(1, 1),
            new Position(1, 0),
            new Position(1, -1),
            new Position(0, -1),
            new Position(-1, -1),
            new Position(-1, 0),
            new Position(-1, 1),
            new Position(0, 1)
        };

        public static Position[] Directions
        {
            get
            {
                return directions;
            }
        }

        public static int GetNextDirection(int currentDirectionIndex)
        {
            int newDirectionIndex;
            if (currentDirectionIndex == (directions.GetLength(0) - 1))
            {
                newDirectionIndex = 0;
            }
            else
            {
                newDirectionIndex = currentDirectionIndex + 1;
            }

            return newDirectionIndex;
        }
    }
}