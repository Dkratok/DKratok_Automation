using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            int Matrix1Legnth = rnd.Next(3, 7);
            int Matrix2Height = rnd.Next(3, 7);
            int CommonMatrixDimension = rnd.Next(3, 7);
            int[,] Matrix1 = new int[Matrix1Legnth, CommonMatrixDimension];
            int[,] Matrix2 = new int[CommonMatrixDimension, Matrix2Height];
            int[,] MatrixRes = new int[Matrix1Legnth, Matrix2Height];
            //int i, j;
            for (int i = 0; i <= (Matrix1Legnth - 1); i++)
            {
                for (int j = 0; j <= (CommonMatrixDimension - 1); j++)
                {
                    Matrix1[i, j] = rnd.Next(0, 100);

                }
            }
            for (int i = 0; i <= (CommonMatrixDimension - 1); i++)
            {
                for (int j = 0; j <= (Matrix2Height - 1); j++)
                {
                    Matrix2[i, j] = rnd.Next(0, 100);
                }
            }

            Console.WriteLine("Matrix1Legnth=" + Matrix1Legnth + ", " + "Matrix2Height=" + Matrix2Height + ", " + "CommonMatrixDimension=" + CommonMatrixDimension);
            Console.WriteLine();
            Console.WriteLine("Matrix1:");
            for (int i = 0; i <= (Matrix1Legnth - 1); i++)
            {
                for (int j = 0; j <= (CommonMatrixDimension - 1); j++)
                {
                    Console.Write(Matrix1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Matrix2:");
            for (int i = 0; i <= (CommonMatrixDimension - 1); i++)
            {
                for (int j = 0; j <= (Matrix2Height - 1); j++)
                {
                    Console.Write(Matrix2[i, j] + " ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < Matrix1Legnth; i++)
            {
                for (int j = 0; j < Matrix2Height; j++)
                {
                    for (int k = 0; k < CommonMatrixDimension; k++)
                    {
                        MatrixRes[i, j] += Matrix1[i, k] * Matrix2[k, j];
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("MatrixRes:");

            for (int i = 0; i <= (Matrix1Legnth - 1); i++)
            {
                for (int j = 0; j <= (Matrix2Height - 1); j++)
                {
                    Console.Write(MatrixRes[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }


    }
}
