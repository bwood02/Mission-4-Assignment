using Mission_4_Assignment;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Tic Tac Toe!");

        bool playAgain = true; // start the game at least once

        // Do-while loop is to play the game at least once and then check if they'd like to play again
        do
        {
            // Init game variables
            bool gameOver = false;
            char[] board = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];
            char currentPlayer = 'X';

            // Get player names
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

            // Set the starting player's name to an actual entered name
            string currentPlayerName = playerXName;

            while (!gameOver)
            {
                // ========== Show what the board currently looks like ==============================
                GameManager currentGame = new GameManager();
                currentGame.PrintGameBoard(board); // 

                // ========== Ask the player which spot they want to select =========================
                Console.Write($"{currentPlayerName}, where do you want to place your '{currentPlayer}'? ");
                string choice = Console.ReadLine() ?? "";

                // Continue to prompt the user to choose a spot until they give a valid spot
                // Use the IsValidChoice function to check if the choice is valid
                while (!IsValidChoice(choice, board))
                {
                    Console.Write($"{currentPlayerName}, Please enter a single-digit number matching an available spot on the board: ");
                    choice = Console.ReadLine() ?? "";
                }

                // ========== Put mark on board using UpdateBoard function ==========================
                board = UpdateBoard(choice, board, currentPlayer);

                // ========== Check to see if the game is over ======================================
                char result = currentGame.GameResults(board);
                // It's only possible for the current player to place the winning piece
                if (result == currentPlayer)
                {
                    Console.WriteLine($"Player {currentPlayer}, {currentPlayerName}, wins!");
                    gameOver = true;
                } else if (result == '-')
                {
                    Console.WriteLine($"The game ends in a tie :(");
                    gameOver = true;
                }

                // ========== Change Player =========================================================
                // If currentPlayer is 'X', change it to 'O'
                if (currentPlayer == 'X')
                {
                    currentPlayer = 'O';
                    currentPlayerName = playerOName;
                }
                // If currentPlayer is 'O', change it to 'X'
                else
                {
                    currentPlayer = 'X';
                    currentPlayerName = playerXName;
                }
            }

            // =============== The game is over now, ask if they want to play again =================
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainChoice = Console.ReadLine() ?? "";

            // Make sure they entered a valid response
            while (playAgainChoice.ToLower() != "yes" && playAgainChoice.ToLower() != "y"
                && playAgainChoice.ToLower() != "no" && playAgainChoice.ToLower() != "n")
            {
                Console.Write("Please enter 'yes' or 'no': ");
                playAgainChoice = Console.ReadLine() ?? "";
            }

            // If they answered yes, set playAgain to true
            if (playAgainChoice.ToLower() == "yes" || playAgainChoice.ToLower() == "y")
            {
                playAgain = true;
            }

            // If they said no or n, set playAgain to false (loop will end)
            else if (playAgainChoice.ToLower() == "no" || playAgainChoice.ToLower() == "n")
            {
                playAgain = false;
            }

        } while (playAgain);

        Console.WriteLine("Thanks for playing! Have a great day!\n");
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
        board[boardSpace - 1] = currentPlayer;
        return board;
    }
}