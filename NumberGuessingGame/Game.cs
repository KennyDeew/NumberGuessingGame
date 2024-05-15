using System;
using static NumberGuessingGame.Game;
using static NumberGuessingGame.GameSetting;

namespace NumberGuessingGame
{
    public class Game : IGame
    {
        /// <summary>
        /// Настройки игры
        /// </summary>
        private readonly IGameSetting _GameSetting;
        /// <summary>
        /// Статус победы
        /// </summary>
        public bool _Win {  get; set; }

        /// <summary>
        /// Игра
        /// </summary>
        /// <param name="WinValue">Загаданное число</param>
        /// <param name="NumberOfTrying">Количество попыток</param>
        public Game(IGameSetting GameSettings)
        {
            _GameSetting = GameSettings;
            _Win = false;
        }

        /// <summary>
        /// Начинаем игру
        /// </summary>
        public void StartGame()
        {
            for (int i = 0; i < _GameSetting._NumberOfTrying; i++)
            {
                if (_Win)
                {
                    break;
                }
                else
                {
                    //Каждый ход уведомляем о количестве оставшихся попыток
                    IMessage NumberOfTrying = new Message_NumberOfTrying(_GameSetting._NumberOfTrying - i);
                    NumberOfTrying.SendMessage();

                    MakeTrying();
                }
                
            }
            //Результат игры
            if (_Win)
            {
                //Поздравление игрока
                IMessage Congratulations = new Message_Congratulation();
                Congratulations.SendMessage();
                if (Congratulations is IMultiMediaMessage MMS)
                {
                    MMS.SendMMS();
                }
            }
            else
            {
                //Утешение игрока
                IMessage Consolation = new Message_Consolation();
                Consolation.SendMessage();
            }
        }

        /// <summary>
        /// Делаем попытку отгадать загаданное значение
        /// </summary>
        public void MakeTrying()
        {
            Console.WriteLine("Введите предполагаемое число");
            if (int.TryParse(Console.ReadLine(), out int IntEnterValue))
            {
                CompareTrying(IntEnterValue);
            }
            else
            {
                //Если игрок вводит не число, просим повторно ввести значение, пока не будет число
                bool CheckValue = true;
                while (CheckValue)
                {
                    Console.WriteLine("Вы ввели не число. Введите предполагаемое число");
                    if (int.TryParse(Console.ReadLine(), out int IntEnterValue1))
                    {
                        CheckValue = false;
                        CompareTrying(IntEnterValue1);
                    }
                }
            }
        }

        /// <summary>
        /// Сравниваем введенное значение с загаданным
        /// </summary>
        /// <param name="EnterValue">Значение, которое ввел пользователь</param>
        public void CompareTrying(int EnterValue)
        {
            if (EnterValue == _GameSetting._WinValue)
            {
                _Win = true;
            }
            else
            {
                //Если игрок не отгадал - отправляем ему подсказку
                IMessage Clue = new Message_Clue(_GameSetting._WinValue > EnterValue);
                Clue.SendMessage();
            }
        }

        public interface IGame
        {
            bool _Win { get; set; }

            void StartGame();
        }
    }
}
