namespace GameSOLID.Messages
{
    public interface IHintMessage
    {
        public string Get(string userAnswer, string hint, int attemptsLeft);
    }
}
