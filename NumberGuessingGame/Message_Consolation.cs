using System;

namespace NumberGuessingGame
{
    internal class Message_Consolation : IMessage
    {
        public void SendMessage()
        {
            Console.WriteLine($"Вы проиграли. Не отчаивайтесь: в следующий раз все получится.");
        }
    }
}
