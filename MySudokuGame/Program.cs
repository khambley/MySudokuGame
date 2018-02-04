using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySudokuGame
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //This is to test the github commit process.
            int[,] grid;
            grid = new int[9, 9];

            int rowLength = grid.GetLength(0);
            int colLength = grid.GetLength(1);

            bool IsPossibleNumber = false;
            int value = 4;
            for (int row = 0; row < 1; row++)                //fill row 1
            {
                for (int col = 0; col < 9; col++)
                {
                    grid[row, col] = col + 1;
                }
                
            }
            for (int row = 1; row < 2; row++)                //fill row 2
            {
                for (int col = 0; col < 9; col++)
                {
                    value++;
                    grid[row, col] = value;
                    if (value > 8)
                    {
                        value = 0;
                    }
                    
                }
            }

            bool ColCheck(int CellValue, int StartCol, int[,] array)
            {
                IsPossibleNumber = false;
                for (int row = 0; row < 9; row++)
                {
                    if (array[row, StartCol] == CellValue)
                    {
                        IsPossibleNumber = true;
                    }
                }
                return IsPossibleNumber;
            }

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0}  ", grid[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            value = 1;
            bool RowCheck(int CellValue, int StartRow, int[,] array)
            {
                IsPossibleNumber = false;
                for (int col = 0; col < 9; col++)
                {
                    if (array[StartRow, col] == CellValue)
                    {
                        IsPossibleNumber = true;
                    }
                }
                return IsPossibleNumber;
            }
            for (int row1 = 0; row1 < 9; row1++) //starting at position row 2, col 0
            {
                //Console.WriteLine(string.Format("{0}", row1));
                for (int col1 = 0; col1 < 9; col1++)
                {
                    Console.WriteLine("Row Number: " + row1 + " Col number: " + col1);
                    if (RowCheck(value, row1, grid) == false)
                    {
                        
                        if(ColCheck(value, col1, grid)== false)
                        {
                            Console.WriteLine(value + " is not in the row and column.");
                        }
                        else
                        {
                            Console.WriteLine(value + " is in the row or column.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(value + " is in the row.");
                    }

                }
            }

            
        }
    }
}
