namespace GameSOLID.Validators
{
    public class IntegerValidations: IValidations
    {
        public bool IsPositiveNumber(string? value)
        {
            return value != null && int.TryParse(value, out _) && Convert.ToInt32(value) >= 0;
        }

        public bool IsValidRange(string startRange, string endRange)
        {
            return Convert.ToInt32(startRange) < Convert.ToInt32(endRange);
        }

        public bool IsNumberInRange(string startRange, string endRange, string number)
        {
            return (Convert.ToInt32(number) >= Convert.ToInt32(startRange)) && (Convert.ToInt32(number) <= Convert.ToInt32(endRange));
        }
    }
}