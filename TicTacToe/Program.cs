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
            gameOn(playerOne, playerTwo);

        }

        //Game on: born players, restart table, start the game.
        static void gameOn(Player playerOne, Player playerTwo)
        {
            // Players born
            Player.bornPlayers(playerOne, playerTwo);

            // Gameplay
            while (playerOne.GetAlive() && playerTwo.GetAlive() && !Player.boardFilled)
            {
                playerOne.gamePlay();
                // Check if the first player is dead to end the game here if the Second person won, without letting the second person play.
                if (!playerOne.GetAlive())
                {
                    break;
                }
                playerTwo.gamePlay();
            }

            playerOne.gameLayout();

            // Restart or quit Game on prompt
            gameRestart(playerOne, playerTwo);
        }

        //Game restarter
        static void gameRestart(Player playerOne, Player playerTwo)
        {

            Console.WriteLine("Would you like to play another one? - y / n");
            string restartInput = Console.ReadLine();

            if(restartInput.Equals("y")) 
            {
                Player.bornPlayers(playerOne, playerTwo);
                gameOn(playerOne, playerTwo);

            } else if (!(restartInput.Equals("n")))
            {
                Console.WriteLine("Please press either 'y' or 'n'");
                gameRestart(playerOne, playerTwo);
            }
        }

    }
}
