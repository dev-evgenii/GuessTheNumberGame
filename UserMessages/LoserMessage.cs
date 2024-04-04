namespace GameSOLID.Messages
{
    public class LoserMessage : IMessage
    {
        public string Get(string numberForGuess)
        {
            return $"К сожалению Вы не смогли угадать число {numberForGuess} за отведённое количество попыток. Это провал!\n\n\n";
        }
    }
}
