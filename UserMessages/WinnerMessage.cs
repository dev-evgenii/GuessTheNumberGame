namespace GameSOLID.Messages
{
    public class WinnerMessage : IMessage
    {
        public string Get(string numberForGuess)
        {
            return $"ПОБЕДА !!! Вы угадали число. Было загаданно: {numberForGuess} \n\n\n";
        }
    }
}
