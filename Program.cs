internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Tic Tac Toe!");

        bool playAgain = true; // start the game at least once

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

            //      Play again?
            //      If yes, reset board
        }


        // Say goodbye
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