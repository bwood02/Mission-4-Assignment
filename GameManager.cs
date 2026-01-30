using System;
using System.Collections.Generic;
using System.Text;

namespace Mission_4_Assignment
{
    internal class GameManager
    {
        public void PrintGameBoard(char[] gamegameBoard)
        {
            Console.WriteLine("Current gameBoard:");
            for (int i = 0; i < gamegameBoard.Length; i++)
            {
                // Print value with spaces
                Console.Write(" " + gamegameBoard[i] + " ");

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
        public char GameResults(char[] gameBoard)
        {
            char winner = ' '; // No winner yet

            // Array of arrays: each inner array is a winning combination
            int[][] winPatterns = new int[][] // "new" creates the array object in memory
                {
                    new int[] {0,1,2}, // top
                    new int[] {3,4,5}, // middle
                    new int[] {6,7,8}, // bottom 
                    new int[] {0,3,6}, // left
                    new int[] {1,4,7}, // middle
                    new int[] {2,5,8}, // right
                    new int[] {0,4,8}, // top-left → bottom-right
                    new int[] {2,4,6}  // top-right → bottom-left
                };

            // Loop through each winning pattern
            foreach (int[] pattern in winPatterns)
            {
                // Create a, b, c variables for each position in the winning pattern
                int a = pattern[0]; // first index in int[ ] pattern above
                int b = pattern[1]; // second index
                int c = pattern[2]; // third index

                // Check if all 3 positions have the same non-empty value (from the gameBoard array)
                if (gameBoard[a] == gameBoard[b] &&
                    gameBoard[b] == gameBoard[c] &&
                    gameBoard[a] != ' ')
                {
                    winner = gameBoard[a]; // If they are all the same, return that value ('X' or 'O')
                }
            }

            // Now that we've checked for a winner, check to see if the board is full without a winner
            bool boardFull = true;
            foreach (char space in gameBoard)
            {
                if (int.TryParse(space.ToString(), out int _))
                {
                    boardFull = false;
                    break;
                }
            }

            if (boardFull && winner == ' ')
            {
                winner = '-';
            }

            return winner; // No winner yet
        }
    }
}
