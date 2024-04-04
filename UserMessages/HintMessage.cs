namespace GameSOLID.Messages
{
    public class HintMessage : IHintMessage
    {
        public string Get(string userAnswer, string hint, int attemptsLeft)
        {
            return $"Это не {userAnswer}, введённое число {hint} загаданного. Осталось попыток: {attemptsLeft}";
        }
    }
}
