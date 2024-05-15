using System;
using static NumberGuessingGame.Game;
using static NumberGuessingGame.GameSetting;

namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IGameSetting GameSetting = new GameSetting();
            Game NewGame = new Game(GameSetting);
            NewGame.StartGame();
            Console.ReadLine();
        }
    }
}
