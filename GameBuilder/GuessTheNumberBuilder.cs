using GameSOLID.Main;
using GameSOLID.Setup;

namespace GameSOLID.GameBuilder
{
    public class GuessTheNumberBuilder: IGameBuilder
    {
        public void BuildDescriptionPart()
        {
            Console.Write(GameDescription.Get());            
        }

        public void BuildSetupPart(Mode gameMode) 
        {
            var settings = new GameSettings();
            var gameSetup = new GameSetup(settings, GameValidations.Get(gameMode));

            gameSetup.ShowDefaultSetting();
            if (gameSetup.IsUserWantUpdateSettings())
            {
                gameSetup.UpdateSettings();
            }
        }

        public void BuildGamePart(Mode gameMode)
        {   
            var settings = new GameSettings();            
            var game = new Game(settings, GameValidations.Get(gameMode), gameMode);
            game.Start();
        }        
    }
}
