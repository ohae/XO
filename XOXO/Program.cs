using System;
using System.Collections.Generic;
using System.Text;

namespace XOXO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello my tic tac toe! \n");

            int round = 1;
            foreach (var input in mockInput())
            {
                Console.WriteLine($"Round {round}");
                try
                {
                    var engine = new GameEngine(input);
                    var errMsg = new StringBuilder();

                    if (!engine.VerifyTheGameState()) errMsg.Append("The game input state is invalid").AppendLine();
                    if (!engine.VerifyTheGameHasEnded()) errMsg.Append("The game is not over yet").AppendLine();
                    if (errMsg.Length > 0)
                    {
                        throw new Exception(errMsg.ToString());
                    }

                    var winner = engine.WhosWin();

                    if (winner != 0)
                    {
                        Console.WriteLine($"The game is over and {winner} is a winner.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The game is over and they both draw.");
                        break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //Ensure input print
                for (int horizon = 0; horizon < input.GetLength(0); horizon++)
                {
                    for (int vertical = 0; vertical < input.GetLength(1); vertical++)
                    {
                        Console.Write(input[horizon, vertical] + "\t");
                    }
                    Console.WriteLine();
                } 

                Console.WriteLine();
                Console.WriteLine("press any key to Next Round...");
                Console.ReadLine();
                Console.Clear();
                round++;
            }
        }

        static List<char[,]> mockInput()
        {
            return new List<char[,]> 
            {
                new char[,]
                {
                    { 'o', ' ', ' ' },
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' ' },
                },new char[,]
                {
                    { 'o', 'x', ' ' },
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' ' },
                },new char[,]
                {
                    { 'o', 'x', ' ' },
                    { 'o', ' ', ' ' },
                    { ' ', ' ', ' ' },
                },new char[,]
                {
                    { 'o', 'x', ' ' },
                    { 'o', ' ', ' ' },
                    { 'x', ' ', ' ' },
                },new char[,]
                {
                    { 'o', 'x', ' ' },
                    { 'o', 'o', ' ' },
                    { 'x', ' ', ' ' },
                },new char[,]
                {
                    { 'o', 'x', ' ' },
                    { 'o', 'o', 'x' },
                    { 'x', ' ', ' ' },
                },new char[,]
                {
                    { 'o', 'x', ' ' },
                    { 'o', 'o', 'x' },
                    { 'x', ' ', 'o' },
                },
            };
        }
        static List<char[,]> mockDraw()
        {
            return new List<char[,]>
            {
                new char[,]
                {
                    { 'o', ' ', ' ' },
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' ' },
                },new char[,]
                {
                    { 'o', 'x', ' ' },
                    { ' ', ' ', ' ' },
                    { ' ', ' ', ' ' },
                },new char[,]
                {
                    { 'o', 'x', ' ' },
                    { 'o', ' ', ' ' },
                    { ' ', ' ', ' ' },
                },new char[,]
                {
                    { 'o', 'x', ' ' },
                    { 'o', ' ', ' ' },
                    { 'x', ' ', ' ' },
                },new char[,]
                {
                    { 'o', 'x', ' ' },
                    { 'o', ' ', ' ' },
                    { 'x', 'o', ' ' },
                },new char[,]
                {
                    { 'o', 'x', ' ' },
                    { 'o', 'x', ' ' },
                    { 'x', 'o', ' ' },
                },new char[,]
                {
                    { 'o', 'x', 'o' },
                    { 'o', 'x', ' ' },
                    { 'x', 'o', ' ' },
                },new char[,]
                {
                    { 'o', 'x', 'o' },
                    { 'o', 'x', 'x' },
                    { 'x', 'o', ' ' },
                },new char[,]
                {
                    { 'o', 'x', 'o' },
                    { 'o', 'x', 'x' },
                    { 'x', 'o', 'x' },
                },
            };
        }
    }
}
