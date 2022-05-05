using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] m1 = new int[10, 3];
            int[,] m2 = new int[3, 2];

            if (m1.GetLength(1) != m2.GetLength(0))
            {
                Console.WriteLine("Matrizes não multiplicáveis");
            }
            else 
            {
                preencher(m1, 1);
                preencher(m2, 2);
                multiplicar(m1, m2);
            }

            Console.ReadKey();
        }

        public static void preencher(int[,] matrix, int number)
        {
            Random random = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(101);
                }
            }

            //Printing filled matrix
            Console.WriteLine("Matriz " + number.ToString() + ": ");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = new int[matrix.GetLength(1)];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }
                foreach (int j in row)
                {
                    Console.Write(j.ToString() + " ");
                }
                Console.WriteLine();
            }
        }

        public static void multiplicar(int[,] m1, int[,] m2)
        {
            Console.WriteLine("\nMultiplicação entre as matrizes: ");
            int[,] result = new int[m1.GetLength(0), m2.GetLength(1)];

            for (int i = 0; i < m1.GetLength(0); i++)
            {
                int[] row = getRow(i, m1);
                for (int j = 0; j < m2.GetLength(1); j++)
                {
                    int[] col = getCol(j, m2);
                    result[i, j] = calcCell(row, col);
                }
            }

            //Printing result matrix
            for (int i = 0; i < result.GetLength(0); i++)
            {
                int[] resRow = new int[result.GetLength(1)];
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    resRow[j] = result[i, j];
                }
                foreach (int j in resRow)
                {
                    Console.Write(j.ToString() + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[] getRow(int numRow, int[,] matrix)
        {
            int[] row = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                row[j] = matrix[numRow, j];
            }
            return row;
        }

        public static int[] getCol(int numCol, int[,] matrix)
        {
            int[] col = new int[matrix.GetLength(0)];
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                col[j] = matrix[j, numCol];
            }
            return col;
        }

        public static int calcCell(int[] row, int[] col)
        {
            int result = 0;
            for (int i = 0; i < row.Length; i++)
            {
                result += row[i] * col[i];
            }
            return result;
        }
    }
}
