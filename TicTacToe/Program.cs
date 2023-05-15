using System;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            //Object generate
            Player playerOne = new Player("playerOne", 'X');
            Player playerTwo = new Player("playerTwo", 'O');

            //Welcome screen to meet the new players and enter their names
            Player.WelcomeScreen(playerOne, playerTwo);

            //Game player function
            GameOn(playerOne, playerTwo);

        }

        //Game on: born players, restart table, start the game.
        static void GameOn(Player playerOne, Player playerTwo)
        {
            // Born players, initialize boards, initialize turns.
            Player.BornGame(playerOne, playerTwo);

            // Gameplay
            while (playerOne.GetAlive() && playerTwo.GetAlive() && !Player.boardFilled)
            {
                playerOne.GamePlay();

                // Check if the first player is dead to end the game here if the Second person won, without letting the second person play.
                if (!playerOne.GetAlive())
                {
                    break;
                }
                playerTwo.GamePlay();
            }

            playerOne.GameLayout();

            // Restart or quit Game on prompt
            GameRestart(playerOne, playerTwo);
        }

        //Game restarter
        static void GameRestart(Player playerOne, Player playerTwo)
        {

            Console.WriteLine("Would you like to play another one? - y / n");
            string restartInput = Console.ReadLine();

            if (restartInput.Equals("y"))
            {
                Player.BornGame(playerOne, playerTwo);
                GameOn(playerOne, playerTwo);

            }
            else if (!(restartInput.Equals("n")))
            {
                Console.WriteLine("Please press either 'y' or 'n'");
                GameRestart(playerOne, playerTwo);
            }
        }

    }
}
