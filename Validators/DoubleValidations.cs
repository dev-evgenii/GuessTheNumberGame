namespace GameSOLID.Validators
{
    public class DoubleValidations: IValidations
    {
        public bool IsPositiveNumber(string? value)
        {
            return value != null && double.TryParse(value, out _) && Convert.ToDouble(value) >= 0;
        }

        public bool IsValidRange(string startRange, string endRange)
        {
            return Convert.ToDouble(startRange) < Convert.ToDouble(endRange);
        }

        public bool IsNumberInRange(string startRange, string endRange, string number)
        {
            return (Convert.ToDouble(number) >= Convert.ToDouble(startRange)) && (Convert.ToDouble(number) <= Convert.ToDouble(endRange));
        }
    }
}