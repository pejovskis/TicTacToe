using System;

namespace TicTacToe
{
    class Program
    { 
        static void Main(string[] args)
        {
            //Object generateasdddas
            Player playerOne = new Player("playerOne", true, 'X');
            Player playerTwo = new Player("playerTwo", true, 'O');

            WelcomeScreen(playerOne, playerTwo);

            //Gameplay
            while (playerOne.GetAlive() && playerTwo.GetAlive())
            {
                playerOne.gamePlay();
                //Check if the first player is dead to end the game here if the Second person won, without letting the second person play.
                if(!(playerOne.GetAlive()))
                {
                    break;
                }

                playerTwo.gamePlay();

            }
        }

        /*Welcome Screen and name enter*/
        static void WelcomeScreen(Player player1, Player player2)
        {
            Console.WriteLine("Welcome. Enter first player name: ");
            player1.SetName(Console.ReadLine()); 
            Console.WriteLine("Welcome. Enter second player name: ");
            player2.SetName(Console.ReadLine());

            player1.SetAlive(true);
            player2.SetAlive(true);

            Console.WriteLine("Welcome to TicTacToe " + player1.GetName() + " and " + player2.GetName());

            player1.Tabelle();

        }

        

        

        

    }
}
