using System;

namespace NumberGuessingGame
{
    internal class Message_NumberOfTrying : IMessage
    {

        /// <summary>
        /// Количество оставшихся попыток
        /// </summary>
        public int _NumberOfHavingTrying { get; set; }

        public Message_NumberOfTrying(int numberOfHavingTrying)
        {
            _NumberOfHavingTrying = numberOfHavingTrying;
        }

        public void SendMessage()
        {
            Console.WriteLine($"Осталось попыток: {_NumberOfHavingTrying}.");
        }
    }
}
