using GameSOLID.GameBuilder;
using GameSOLID.Main;

namespace GameSOLID
{
    public static class GuessTheNumber
    {
        public static void ActivateGame(Mode gameMode)
        {
            var guessTheNumberBuilder = new GuessTheNumberBuilder();
            var gameDirector = new GameDirector(guessTheNumberBuilder);
            gameDirector.Construct(gameMode);
        }
    }
}