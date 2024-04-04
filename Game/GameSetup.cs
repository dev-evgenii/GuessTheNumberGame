using GameSOLID.Setup;
using GameSOLID.Validators;
using System.Text;

namespace GameSOLID.Main
{    
    public class GameSetup(IGameSettings settings, IValidations validations)
    {
        private readonly IGameSettings _settings = settings;
        private readonly IValidations _validations = validations;

        public void ShowDefaultSetting()
        {
            var defaultSettings = _settings.Get();

            var defaultSettingsMessage = new StringBuilder("\nНастройка игры по умолчанию.\n");
            defaultSettingsMessage.Append($"Количиство попыток отгадывания: {defaultSettings.AllowedNumberOfAttempts}. ");
            defaultSettingsMessage.Append($"Диапазон чисел для отгадывания от {defaultSettings.RangeStart} до {defaultSettings.RangeEnd}.\n");            
            
            Console.WriteLine(defaultSettingsMessage.ToString());
        }

        public void UpdateSettings()
        {
            int allowedNumberOfAttempts = SetAllowedNumberOfAttempts();
            var numberRange = SetNumberRange();

            var newSettings = new Settings()
            {
                AllowedNumberOfAttempts = allowedNumberOfAttempts,
                RangeStart = numberRange.Item1,
                RangeEnd = numberRange.Item2
            };

            _settings.Update(newSettings);
        }

        public bool IsUserWantUpdateSettings()
        {
            Console.WriteLine("Хотите обновить настройки? (Да - обновит настройки / любое другое нажатие запустит игру) ");
            var userAnswer = Console.ReadLine();

            if (userAnswer != null && userAnswer.Equals("да", StringComparison.CurrentCultureIgnoreCase))            
                return true;            
            else            
                return false;            
        }        

        private int SetAllowedNumberOfAttempts()
        {
            Console.Write("Задайте количество попыток отгадывания: ");
            var allowedNumberOfAttemptsEntered = Console.ReadLine();

            while (!_validations.IsPositiveNumber(allowedNumberOfAttemptsEntered))                  
            {
                Console.Write(Errors.GetSettingsErrorText(GeneralErrors.AllowAnswearAttempts));                
                allowedNumberOfAttemptsEntered = Console.ReadLine();
            }

            return Convert.ToInt32(allowedNumberOfAttemptsEntered);
        }

        private Tuple<string, string> SetNumberRange()
        {
            Console.Write("Задайте начало диапазона чисел для отгадывания: ");
            var rangeStartEntered = Console.ReadLine();

            while (!_validations.IsPositiveNumber(rangeStartEntered))
            {
                Console.Write(Errors.GetSettingsErrorText(GeneralErrors.RangeStart));                
                rangeStartEntered = Console.ReadLine();
            }

            Console.Write("Задайте конец диапазона чисел для отгадывания: ");
            var rangeEndEntered = Console.ReadLine();
            while (!_validations.IsPositiveNumber(rangeEndEntered) ||
                   !_validations.IsValidRange(rangeStartEntered ?? "0", rangeEndEntered ?? "0"))
            {                
                Console.Write(Errors.GetSettingsErrorText(GeneralErrors.RangeEnd));
                rangeEndEntered = Console.ReadLine();
            }

            return new Tuple<string, string>(rangeStartEntered ?? "0", rangeEndEntered ?? "0");
        }
    }
}
