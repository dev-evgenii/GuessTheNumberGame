using GameSOLID.Validators;

namespace GameSOLID.Main
{
    public enum Mode { GuessInteger, GuessDouble }

    public static class GameValidations
    {
        public static IValidations Get(Mode selectedMode)
        {
            return selectedMode switch
            {
                Mode.GuessInteger => new IntegerValidations(),
                Mode.GuessDouble => new DoubleValidations(),
                _ => new IntegerValidations(),
            };
        }
    }
}
