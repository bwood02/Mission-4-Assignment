using Mission_4_Assignment;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Tic Tac Toe!");

        bool playAgain = true; // start the game at least once

        // Ask for player names - store in variables
        Console.Write("Player X, what is your name? ");
        string playerXName = Console.ReadLine() ?? "";
        // if they don't enter a name, default to "Player X"
        if (string.IsNullOrWhiteSpace(playerXName))
        {
            playerXName = "Player X";
        }

        Console.Write("Player O, what is your name? ");
        string playerOName = Console.ReadLine() ?? "";
        // if they don't enter a name, default to "Player O"
        if (string.IsNullOrWhiteSpace(playerOName))
        {
            playerOName = "Player O";
        }

        while (playAgain)
        {
            // Set gameOver back to false so the game can start
            bool gameOver = false;
            // Put all the numbers back on the board reset board array to ['1', '2', '3', '4', '5', '6', '7', '8', '9']
            char[] board = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];
            // Set current player to 'X'
            char currentPlayer = 'X';

            while (!gameOver)
            {
                // show what the board currently looks like
                // call the PrintBoard method from the supporting class
                // give it the board array so it knows what to print"
                GameManager.PrintgameBoard(board); // 
                
                // ask the player which spot they want to select "Where do you want to
                // place your [X] or [O]?" - pull the X or O from the currentPlayer variable
                // save the choice in a variable
                Console.Write($"Where do you want to place your '{currentPlayer}'? ");
                string choice = Console.ReadLine() ?? "";
                
                // use the IsValidChoice function to check if the choice is valid
                // Continue to prompt the user to choose a spot until they give a valid spot
                while (!IsValidChoice(choice, board))
                {
                    Console.WriteLine("Please enter a single-digit number matching an available spot on the board.");
                    choice = Console.ReadLine() ?? "";
                }
                
                // put mark on board using UpdateBoard function
                // give it: their choice, the board, and which player they are (currentPlayer)
                board = UpdateBoard(choice, board, currentPlayer);

                // check if someone won the game
                // call the CheckForWinner method from the supporting class
                // give it the board array
                // save what it returns - tells us if there's a winner and who won
                string winner = GameManager.CheckForWinner(board);
                if (winner != "")
                {
                    Console.WriteLine($"Player {winner} wins!");
                    gameOver = true;
                }
            
                
                // if nobody won yet, switch to the other player
                //      if currentPlayer is 'x', change it to 'o' - this way the next time through the loop, it's the other player's turn
                if (currentPlayer == 'X')
                {
                    currentPlayer = 'O';
                }
                //      if currentPlayer is 'o', change it to 'x' - this way the next time through the loop, it's the other player's turn
                
                else
                {
                    currentPlayer = 'X';
                }
            }

            // The game is over now, ask if they want to play again
            //      Print "Do you want to play again? (yes/no):"
            Console.Write("Do you want to play again? (yes/no): ");
            //      Read what they type
            string playAgainChoice = Console.ReadLine() ?? "";
            //      If they said yes or y, set playAgain to true (loop will start over)
            if (playAgainChoice.ToLower() == "yes" || playAgainChoice.ToLower() == "y")
            {
                playAgain = true;
            }
            //      If they said no or n, set playAgain to false (loop will end)
            else if (playAgainChoice.ToLower() == "no" || playAgainChoice.ToLower() == "n")
            {
                playAgain = false;
            }
        }


        // Say goodbye
        Console.WriteLine("Thanks for playing!");
    }

    // Determines if user entered an unchosen int
    private static bool IsValidChoice(string choice, char[] board)
    {
        bool valid = true;

        // Make sure it's a single character
        if (choice.Length != 1)
        {
            valid = false;
        }
        // Make sure it's a number
        else if (!int.TryParse(choice, out int _))
        {
            valid = false;
        }
        // Make sure it's a number in the board array
        // (if it passed the previous if statement it's a number)
        else if (!board.Contains(choice[0]))
        {
            valid = false;
        }

        return valid;
    }

    private static char[] UpdateBoard(string choice, char[] board, char currentPlayer)
    {
        int.TryParse(choice, out int boardSpace);
        board[boardSpace] = currentPlayer;
        return board;
    }
}