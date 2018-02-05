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
            //print out grid
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0}  ", grid[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            
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
            
            bool RegionCheck(int cellValue, int row, int col, int[,] array)
            {
                IsPossibleNumber = false;
                int StartRow = 0;
                int StartCol = 0;
                if (row <= 2 && col <= 2) //Region 1, top left
                {
                    StartRow = 0;
                    StartCol = 0;
                    Console.WriteLine("This is region 1");
                }
                if (row >= 3 && row <= 5 && col <= 2) // Region 2, middle left
                {
                    StartRow = 3;
                    StartCol = 0;
                    Console.WriteLine("This is region 2");
                }
                if (row >= 6 && col <= 2) //Region 3, bottom left
                {
                    StartRow = 6;
                    StartCol = 0;
                    Console.WriteLine("This is region 3");
                }
                if(row <= 2 && col >= 3 && col <= 5) // Region 4, top center
                {
                    StartRow = 0;
                    StartCol = 3;
                    Console.WriteLine("This is region 4");
                }
                if(row >= 3 && row <= 5 && col >= 3 && col <= 5) //Region 5, middle center
                {
                    StartRow = 3;
                    StartCol = 3;
                    Console.WriteLine("This is region 5");
                }
                if(row >= 6 && col >= 3 && col <= 5) //Region 6, bottom center
                {
                    StartRow = 6;
                    StartCol = 3;
                    Console.WriteLine("This is region 6");
                }
                if(row <= 2 && col >= 6) //Region 7, top right
                {
                    StartRow = 0;
                    StartCol = 6;
                    Console.WriteLine("This is region 7");
                }
                if(row >= 3 && row <= 5 && col >= 6) //Region 8, middle right
                {
                    StartRow = 3;
                    StartCol = 6;
                    Console.WriteLine("This is region 8");
                }
                if(row >= 6 && col >= 6) //Region 9, bottom right
                {
                    StartRow = 6;
                    StartCol = 6;
                    Console.WriteLine("This is region 9");
                }
                
                for (int i = StartRow; i < StartRow + 2; i++)
                {
                    for (int j = StartCol; j < StartCol + 2; j++)
                    {
                        if (grid[i, j] == cellValue)
                        {
                            IsPossibleNumber = true;
                        }
                    }
                }
                return IsPossibleNumber;  
            }
            value = 1;
            for (int row1 = 0; row1 < 9; row1++) //rows
            {
                for (int col1 = 0; col1 < 9; col1++) //columns
                {
                    Console.WriteLine("Row Number: " + row1 + " Col number: " + col1);
                    if (!RowCheck(value, row1, grid))
                    {
                        Console.WriteLine(value + " is not in row " + row1);
                        if (!ColCheck(value, col1, grid))
                        {
                            Console.WriteLine(value + " is not in the column " + col1);
                            if(!RegionCheck(value, row1, col1, grid))
                            {
                                Console.WriteLine(value + " is not in region.");
                                grid[row1, col1] = value;
                                value++;
                                if (value > 9)
                                {
                                    value = 1;
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine(value + " IS in region.");
                                value++;
                                if (value > 9)
                                {
                                    value = 1;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(value + " IS in column " + col1);
                            value++;
                            if (value > 9)
                            {
                                value = 1;
                            }
                            break;


                        }
                    }
                    else
                    {
                        Console.WriteLine(value + " IS in row " + row1);
                        value++;
                        if (value > 9)
                        {
                            value = 1;
                        }
                        break;
                    }
                } //end cols loop
            } // end rows loop

            //print out grid
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0}  ", grid[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }


        }
    }
}
