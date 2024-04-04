using GameSOLID.Setup;
using GameSOLID.Messages;
using GameSOLID.Validators;

namespace GameSOLID.Main
{
    public enum Answer { Correct, Incorrect, Hint }
    
    public class Game(IGameSettings settings, IValidations validations, Mode gameMode)
    {
        private readonly IGameSettings _settings = settings;
        private readonly string _numberForGuess = new NumberForGuess(settings).Generate(gameMode);        

        public void Start()
        {
            var gameSettings = _settings.Get();            

            for (int numberOfAttempt = 1; numberOfAttempt <= gameSettings.AllowedNumberOfAttempts; numberOfAttempt++)
            {
                Console.Write("Введите предполагаемое число: ");
                var userAnswerAttemptEntered = Console.ReadLine();

                while (!validations.IsPositiveNumber(userAnswerAttemptEntered) ||
                       !validations.IsNumberInRange(gameSettings.RangeStart, gameSettings.RangeEnd, userAnswerAttemptEntered ?? "0"))                   
                {
                    Console.Write(Errors.GetGameErrorText(GeneralErrors.AnswerAttempt, gameSettings.RangeStart, gameSettings.RangeEnd));                    
                    userAnswerAttemptEntered = Console.ReadLine();
                }                                
                
                var result = VerificationUserAnswer.Check(userAnswerAttemptEntered ?? "0", 
                    _numberForGuess, numberOfAttempt, gameSettings.AllowedNumberOfAttempts);

                switch (result)
                {
                    case Answer.Correct:
                        Console.WriteLine(new WinnerMessage().Get(_numberForGuess));
                        StopTheGame(ref numberOfAttempt, gameSettings.AllowedNumberOfAttempts);                        
                        break;                        
                    case Answer.Incorrect:
                        Console.WriteLine(new LoserMessage().Get(_numberForGuess));
                        break;
                    case Answer.Hint:
                        string message = Hint.Generate(userAnswerAttemptEntered ?? "0",
                                                       _numberForGuess,
                                                       numberOfAttempt,
                                                       gameSettings.AllowedNumberOfAttempts,
                                                       gameMode);
                        Console.WriteLine(message);
                        break;
                }                
            }
        }   
        
        private static void StopTheGame(ref int numberOfAttempt, int allowedNumberOfAttempts)
        {
            numberOfAttempt = allowedNumberOfAttempts;
        }
    }
}
