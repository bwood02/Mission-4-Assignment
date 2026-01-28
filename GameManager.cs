using System;
using System.Collections.Generic;
using System.Text;

namespace Mission_4_Assignment
{
    internal class GameManager
    {
        public void PrintBoard(char[] gameBoard)
        {
            Console.WriteLine("Current Board:");
            for (int i = 0; i < gameBoard.Length; i++)
            {
                // Print value with spaces
                Console.Write(" " + gameBoard[i] + " ");

                // Print vertical bars (not at end of row)
                if ((i + 1) % 3 != 0)
                {
                    Console.Write("|");
                }

                // New line after every 3 values
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine();

                    // Print divider after first two rows
                    if (i < 6)
                    {
                        Console.WriteLine("-----------");
                    }
                }
            }
        }

        // PrintBoard(char[] gameBoard);

        //public char GameResults(char[] gameBoard)
        //{

        //}
    }
}
