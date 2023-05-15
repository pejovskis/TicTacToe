using System;
using System.Linq.Expressions;

namespace TicTacToe
{
    class Program
    { 
        static void Main(string[] args)
        {
            //Object generate
            Player playerOne = new Player("playerOne", true, 'X');
            Player playerTwo = new Player("playerTwo", true, 'O');

            Player.WelcomeScreen(playerOne, playerTwo);
            Player.bornPlayers(playerOne, playerTwo);

            gamePlay(playerOne, playerTwo);

            Console.WriteLine("Would you like to play another one? y / n");
            string gameRestarter = Console.ReadLine();
            gameRestart(playerOne, playerTwo, gameRestarter);

        }

        static void gamePlay(Player playerOne, Player playerTwo)
        {
            //Gameplay
            while (playerOne.GetAlive() && playerTwo.GetAlive())
            {
                playerOne.gamePlay();
                //Check if the first player is dead to end the game here if the Second person won, without letting the second person play.
                if (!(playerOne.GetAlive()))
                {
                    break;
                }

                playerTwo.gamePlay();

            }
        }  

        static void gameRestart(Player playerOne, Player playerTwo, string gameRestarter)
        {
            while (!(gameRestarter.Equals("n")))
            {
                Player.bornPlayers(playerOne, playerTwo);
                gamePlay(playerOne, playerTwo);
                gameRestarter= Console.ReadLine();
            }
        }

        

    }
}
