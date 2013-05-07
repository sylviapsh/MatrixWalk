namespace WalkInMatrix
{
    using System;

    public class MatrixConsoleTest
    {
        public static void Main()
        {
            Console.Write("Enter a positive number: ");
            string input = Console.ReadLine();
            int matrixSize = 0;
            while (!int.TryParse(input, out matrixSize) || matrixSize <= 0 || matrixSize > 100)
            {
                Console.WriteLine("Please enter a positive number in the range [1, 100]!");
                input = Console.ReadLine();
            }
            
            int[,] matrix = new int[matrixSize, matrixSize];
            matrix = Matrix.FillMatrix(matrixSize);

            Console.WriteLine(Matrix.PrintMatrix(matrix));            
        }
    }
}
