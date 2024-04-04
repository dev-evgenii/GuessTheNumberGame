namespace GameSOLID.Setup
{
    public interface IGameSettings
    {
        public Settings Get();
        public void Update(Settings newSettings);
    }
}