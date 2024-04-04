using GameSOLID.Setup;

namespace GameSOLID.Main
{
    public class NumberForGuess(IGameSettings settings) : INumberForGuess
    {
        private readonly IGameSettings _settings = settings;

        public string Generate(Mode gameMode)
        {
            var gameSettings = _settings.Get();
            return gameMode switch
            {
                Mode.GuessInteger => new Random().Next(Convert.ToInt32(gameSettings.RangeStart), Convert.ToInt32(gameSettings.RangeEnd)).ToString(),
                Mode.GuessDouble => new Random().NextDouble(Convert.ToDouble(gameSettings.RangeStart), Convert.ToDouble(gameSettings.RangeEnd)).ToString("n2"),
                _ => new Random().Next(Convert.ToInt32(gameSettings.RangeStart), Convert.ToInt32(gameSettings.RangeEnd)).ToString(),
            };
        }
    }

    public static class RandomExtensions
    {
        public static double NextDouble(
            this Random random,
            double minValue,
            double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}
