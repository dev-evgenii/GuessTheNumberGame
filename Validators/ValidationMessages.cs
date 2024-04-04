namespace GameSOLID.Validators
{
    public enum GeneralErrors
    {
        AllowAnswearAttempts = 001,
        RangeStart = 002,
        RangeEnd = 003,
        AnswerAttempt = 004
    }

    public static class Errors
    {
        public static string GetSettingsErrorText(GeneralErrors errorCode)
        {
            return errorCode switch
            {
                GeneralErrors.AllowAnswearAttempts => "Количество попыток отгадывания должно быть целым числом и больше или равно нулю: ",
                GeneralErrors.RangeStart => "Начало диапазона чисел для отгадывания должно быть целым числом и больше или равно нулю: ",
                GeneralErrors.RangeEnd => "Конец диапазона чисел для отгадывания должен быть целым числом и больше начала диапазона: ",
                _ => string.Empty,
            };
        }

        public static string GetGameErrorText(GeneralErrors errorCode, string rangeStart, string rangeEnd)
        {
            return errorCode switch
            {
                GeneralErrors.AnswerAttempt => $"Введённое число должно быть целым, положительным числом и быть в диапазоне от {rangeStart} до {rangeEnd}: ",                
                _ => string.Empty,
            };
        }
    }
}
