internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Tic Tac Toe!");

        char[] board = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];

        bool gameOver = false;
        bool playAgain = false;

        while (playAgain)
        {
            // Ask for player names (store them in variables)
            while (!gameOver)
            {
                // Make sure the x and o is upper-case
                // Make sure you track current player somehow
                char currentPlayer = 'X';
                
                //Main loop
                //      Print board
                //      Ask player for choice of where to play
                //      Validate choice
                //      Update board
                //      Check for winner
                //      Notify who won
                //      Update currentPlayer to the next player (the other one being 'O')
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