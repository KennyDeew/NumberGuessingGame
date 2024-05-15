using System;
using static NumberGuessingGame.GameSetting;

namespace NumberGuessingGame
{
    public class GameSetting : IGameSetting
    {
        /// <summary>
        /// Загаданное число
        /// </summary>
        public int _MinValue { get ; set ; }
        public int _MaxValue { get ; set ; }
        public int _NumberOfTrying { get ; set ; }
        public int _WinValue { get; set; }

        public GameSetting()
        {
            Console.WriteLine("Перед началом игры необходимо задать настройки:");
            GetMinValue();
            GetMaxValue();
            GetWinValue();
            GetNumberOfTrying();
        }

        /// <summary>
        /// Запрашиваем минимальное возможное загадываемое число
        /// </summary>
        public void GetMinValue()
        {
            Console.WriteLine("Введите минимальное возможное загадываемое число");
            _MinValue = GetIntValue();
        }
        /// <summary>
        /// Запрашиваем максимальное возможное загадываемое число
        /// </summary>
        public void GetMaxValue()
        {
            Console.WriteLine("Введите максимальное возможное загадываемое число");
            _MaxValue = GetIntValue();
        }
        /// <summary>
        /// Определяем случайное число по заданным параметрам
        /// </summary>
        public void GetWinValue()
        {
            var rand = new Random();
            _WinValue = rand.Next(_MinValue, _MaxValue);
        }
        /// <summary>
        /// Запрашиваем количество попыток
        /// </summary>
        public void GetNumberOfTrying()
        {
            Console.WriteLine("Введите количество попыток отгадывания");
            _NumberOfTrying = GetIntValue();
        }

        public int GetIntValue()
        {
            
            if (int.TryParse(Console.ReadLine(), out int IntEnterValue))
            {
                return IntEnterValue;
            }
            else
            {
                //Если игрок вводит не число, просим повторно ввести значение, пока не будет число
                bool CheckValue = true;
                int Result = 0;
                while (CheckValue)
                {
                    Console.WriteLine("Вы ввели не число. Введите, пожалуйста, число");
                    if (int.TryParse(Console.ReadLine(), out int IntEnterValue1))
                    {
                        CheckValue = false;
                        Result = IntEnterValue1;
                    }
                }
                return Result;
            }
        }

        public interface IGameSetting
        {
            int _MinValue { get; set; }

            int _MaxValue { get; set; }

            int _NumberOfTrying { get; set; }

            int _WinValue { get; set; }
        }
    }
}
