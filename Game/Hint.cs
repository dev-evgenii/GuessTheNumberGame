using GameSOLID.Messages;

namespace GameSOLID.Main
{
    public static class Hint
    {
        public static string Generate(string userAnswer, string numberForGuess, int numberOfAttempt, int AllowedNumberOfAttempts, Mode gameMode)
        {
            string hint = VerificationUserAnswer.IsNumberGreaterThanGenerated(userAnswer, numberForGuess, gameMode) ? "больше" : "меньше";
            return new HintMessage().Get(userAnswer, hint, VerificationUserAnswer.GetAttemptsLeft(numberOfAttempt, AllowedNumberOfAttempts));
        }
    }
}