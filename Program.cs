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
                //Main loop
                //      Print board
                //      Ask player for choice of where to play
                //      Validate choice
                //      Update board
                board = UpdateBoard(board);
                //      Check for winner
                //      Notify who won
            }

            //      Play again?
        }


        // Say goodbye
    }

    private static bool IsValidChoice(int choice)
    {
        // Determines if they entered an unchosen int
        return true;
    }

    private static char[] UpdateBoard(char[] board)
    {
        return board;
    }
}