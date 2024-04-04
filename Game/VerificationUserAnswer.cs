using GameSOLID.Validators;
using System.Net.Sockets;

namespace GameSOLID.Main
{
    public static class VerificationUserAnswer
    {
        public static Answer Check(string userAnswer, string numberForGuess, int numberOfAttempts, int AllowedNumberOfAttempts)
        {
            if (userAnswer == numberForGuess)
            {
                return Answer.Correct;
            }
            else
            {
                if (IsUserHasAttempts(numberOfAttempts, AllowedNumberOfAttempts))
                {
                    return Answer.Hint;
                }
                else
                {
                    return Answer.Incorrect;
                }
            }
        }

        public static bool IsNumberGreaterThanGenerated(string userAnswer, string numberForGuess, Mode gameMode)
        {
            return gameMode switch
            {
                Mode.GuessInteger => Convert.ToInt32(userAnswer) > Convert.ToInt32(numberForGuess),
                Mode.GuessDouble => Convert.ToDouble(userAnswer) > Convert.ToDouble(numberForGuess),
                _ => Convert.ToInt32(userAnswer) > Convert.ToInt32(numberForGuess),
            };           
        }

        public static int GetAttemptsLeft(int numberOfAttempt, int AllowedNumberOfAttempts)
        {
            return AllowedNumberOfAttempts - numberOfAttempt;
        }

        private static bool IsUserHasAttempts(int numberOfAttempts, int AllowedNumberOfAttempts)
        {
            return (AllowedNumberOfAttempts - numberOfAttempts) > 0;
        }
    }
}