using GameSOLID.Main;
using GameSOLID.Validators;

namespace GameSOLID.GameBuilder
{
    public class GameDirector(IGameBuilder gameBuilder)
    {
        private readonly IGameBuilder _gameBuilder = gameBuilder;

        public void Construct(Mode gameMode)
        {
            _gameBuilder.BuildDescriptionPart();
            _gameBuilder.BuildSetupPart(gameMode);
            _gameBuilder.BuildGamePart(gameMode);
        }
    }
}
