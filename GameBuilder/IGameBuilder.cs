using GameSOLID.Main;
using GameSOLID.Validators;

namespace GameSOLID.GameBuilder
{
    public interface IGameBuilder
    {
        void BuildDescriptionPart();
        void BuildSetupPart(Mode gameMode);
        void BuildGamePart(Mode gameMode);
    }
}
