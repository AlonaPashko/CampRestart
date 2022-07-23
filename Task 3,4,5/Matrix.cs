using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3And4And5
{
    internal class Matrix : IEnumerable
    {
        private int rowCount;
        private int colCount;
        
        private int[,] matrSquare;

        public Matrix() : this(5, 6) {}
        
        public Matrix(int rowCount, int colCount)
        {
            matrSquare = new int[rowCount, colCount];
        }
        public Matrix(int[,] matrix)
        {
            rowCount = matrix.GetLength(0);
            colCount = matrix.GetLength(1);
            this.matrSquare = new int[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    matrSquare[i, j] = matrix[i, j];
                }
            }
        }

        public override string ToString()
        {
            string line = "";
            for (int i = 0; i < matrSquare.GetLength(0); i++)
            {
                for (int j = 0; j < matrSquare.GetLength(1); j++)
                {
                    line += matrSquare[i, j] + " ";
                }
                line += '\n';
            }
            return line;
        }
        public void VerticalSnake()
        {
            rowCount = 3;
            colCount = 4;
            matrSquare = new int[rowCount, colCount];
            int temp = 1;

            for (int i = 0; i < colCount; i++)
            {
                if(i % 2 == 0)
                {
                    for (int j = 0; j < rowCount; j++)
                    {
                        matrSquare[j, i] = temp;
                        temp++;
                    }
                }
                else
                {
                    for (int j = rowCount - 1; j >= 0; --j)
                    {
                        matrSquare[j, i] = temp;
                        temp++;
                    }
                }
            }
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    Console.Write(matrSquare[i, j] + " ");
                    Console.WriteLine();
                }
            }
        }

        public void SpiralFulling()
        {
            int number = 0;
            for (int j = 0; j < (matrSquare.GetLength(0) + matrSquare.GetLength(1)) / 2 - 2; j++)
            {
                for (int i = j; i < matrSquare.GetLength(0) - j; i++)
                {
                    matrSquare[i, j] = ++number;
                }
                for (int i = j + 1; i < matrSquare.GetLength(1) - j - 1; i++)
                {
                    matrSquare[i, matrSquare.GetLength(0) - 1 - j] = ++number;
                }
                for (int i = matrSquare.GetLength(1) - 1 - j; i > j; i--)
                {
                    matrSquare[j, i] = ++number;
                }
            }
        }
        
        public void Print()
        {
            for (int i = 0; i < matrSquare.GetLength(0); i++)
            {
                for (int j = 0; j < matrSquare.GetLength(1); j++)
                {
                    Console.Write(matrSquare[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        
        public void ReadMatrixFromFile(StreamReader reader)
        {
            string line = reader.ReadLine();
            string[] sizes = line.Split(' ');
            
            this.rowCount = int.Parse(sizes[0]);
            this.colCount = int.Parse(sizes[1]);

            matrSquare = new int[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                string[] items = reader.ReadLine().Split(' ');
                for (int j = 0; j < colCount; j++)
                {
                    matrSquare[i, j] = int.Parse(items[j]);
                }
            }

        }
        public IEnumerator GetEnumerator()
        {
            for (int column = 0; column < colCount; column++)
            {
                for (int row = 0; row < rowCount; row++)
                {
                    yield return matrSquare[row, column];
                }
            }
        }
    }
}
