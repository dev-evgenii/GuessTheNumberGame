using System.Text;

namespace GameSOLID.Main
{
    public static class GameDescription
    {
        public static string Get()
        {            
            var gameDescription = new StringBuilder("------------------------>  Otus, домашняя работа по SOLID принципам  <------------------------\n");
            gameDescription.AppendLine("Игра 'Угадай число'.");
            gameDescription.AppendLine("Описание: программа рандомно генерирует число, пользователь должен угадать это число.");
            gameDescription.AppendLine("При каждом вводе числа программа пишет больше или меньше отгадываемого.");
            gameDescription.AppendLine("Кол-во попыток отгадывания и диапазон чисел задаются из настроек.");

            return gameDescription.ToString();
        }
    }
}
