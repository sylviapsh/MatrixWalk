namespace WalkInMatrix
{
    using System;
    using System.Text;

    public class Matrix
    {
        public const int MaxMatrixSize = 100;

        public static int[,] FillMatrix(int matrixSize)
        {
            IsMatrixSizeValid(matrixSize);
            int[,] matrix = new int[matrixSize, matrixSize];

            int currentFillNumber = 0;
            int currentDirectionIndex = 0;
            Position currentPosition = new Position(0, 0);           
            Position newPosition = new Position(0, 0);
            
            while (currentFillNumber != ((matrixSize * matrixSize) - 1))
            {
                int directionsChangeCounter = 0;
                currentFillNumber++;
                matrix[currentPosition.Row, currentPosition.Column] = currentFillNumber;

                while (!IsPositionGoodToFill(matrix, currentPosition, currentDirectionIndex, out newPosition))
                {
                    currentDirectionIndex = Direction.GetNextDirection(currentDirectionIndex);
                    directionsChangeCounter++;

                    // If all directions are checked, we need to go to the next fill cell available
                    if (directionsChangeCounter == Direction.Directions.GetLength(0) + 1)
                    {
                        GetNextFillCell(matrix, out newPosition);
                        break;
                    }
                }

                currentPosition = newPosition;
            }

            currentFillNumber++;
            matrix[currentPosition.Row, currentPosition.Column] = currentFillNumber;

            return matrix;
        }

        public static bool IsMatrixSizeValid(int matrixSize)
        {
            if (matrixSize <= 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("The matrix size cannot be a negative number or zero. It should be in the range [1, {0}]!", MaxMatrixSize));
            }
            else if (matrixSize > MaxMatrixSize)
            {
                throw new ArgumentOutOfRangeException(string.Format("The matrix size cannot be greater than 100. It should be in the range [1, {0}]!", MaxMatrixSize));
            }
            else
            {
                return true;
            }
        }

        public static string PrintMatrix(int[,] matrix)
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    result.AppendFormat("{0,5}", matrix[row, column]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        private static bool IsPositionGoodToFill(int[,] matrix, Position currentPosition, int currentDirectionIndex, out Position newPosition)
        {
            newPosition = new Position(0, 0);
            newPosition.Row = Direction.Directions[currentDirectionIndex].Row + currentPosition.Row;
            newPosition.Column = Direction.Directions[currentDirectionIndex].Column + currentPosition.Column;

            if (newPosition.Row < matrix.GetLength(0) && newPosition.Row >= 0)
            {
                if (newPosition.Column < matrix.GetLength(0) && newPosition.Column >= 0)
                {
                    if (matrix[newPosition.Row, newPosition.Column] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void GetNextFillCell(int[,] matrix, out Position position)
        {
            position = new Position(0, 0);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        position.Row = i;
                        position.Column = j;
                        return;
                    }
                }
            }
        }
    }
}