namespace GameSOLID.Validators
{
    public interface IValidations
    {
        public bool IsPositiveNumber(string? value);        
        public bool IsValidRange(string startRange, string endRange);
        public bool IsNumberInRange(string startRange, string endRange, string number);       
    }
}
