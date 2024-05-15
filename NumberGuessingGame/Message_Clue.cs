using System;

namespace NumberGuessingGame
{
    internal class Message_Clue : IMessage
    {
        /// <summary>
        /// Загаданное значение больше введенного
        /// </summary>
        public bool _CorrectValueIsMore {  get; set; }

        public Message_Clue(bool correctValIsMore)
        {
            _CorrectValueIsMore = correctValIsMore;
        }

        public void SendMessage()
        {
            Console.WriteLine($"Загаданное число {(_CorrectValueIsMore ? "больше" : "меньше")}.");
        }
    }
}
