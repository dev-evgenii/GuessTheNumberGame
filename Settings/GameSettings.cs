using System.Configuration;

namespace GameSOLID.Setup
{
    public class GameSettings: IGameSettings
    {
        private const string AllowedNumberOfAttempts_Key = "AllowedNumberOfAttempts";
        private const string RangeStart_Key = "RangeStart";
        private const string RangeEnd_Key = "RangeEnd";

        public Settings Get() 
        {
            var allowedNumberOfAttempts = ConfigurationManager.AppSettings[AllowedNumberOfAttempts_Key] ?? "3";
            var rangeStart = ConfigurationManager.AppSettings[RangeStart_Key] ?? "1";
            var rangeEnd = ConfigurationManager.AppSettings[RangeEnd_Key] ?? "15";

            return new Settings()
            {
                AllowedNumberOfAttempts = Convert.ToInt32(allowedNumberOfAttempts),
                RangeStart = rangeStart,
                RangeEnd = rangeEnd
            };
        }

        public void Update(Settings newSettings) 
        {            
            try
            {               
                var configurationManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (configurationManager.AppSettings.Settings[AllowedNumberOfAttempts_Key] == null)
                {   
                    configurationManager.AppSettings.Settings.Add(AllowedNumberOfAttempts_Key, newSettings?.AllowedNumberOfAttempts.ToString());
                }
                else
                {
                    configurationManager.AppSettings.Settings[AllowedNumberOfAttempts_Key].Value = newSettings?.AllowedNumberOfAttempts.ToString();
                }

                if (configurationManager.AppSettings.Settings[RangeStart_Key] == null)
                {
                    configurationManager.AppSettings.Settings.Add(RangeStart_Key, newSettings?.RangeStart.ToString());
                }
                else
                {
                    configurationManager.AppSettings.Settings[RangeStart_Key].Value = newSettings?.RangeStart.ToString();
                }

                if (configurationManager.AppSettings.Settings[RangeEnd_Key] == null)
                {
                    configurationManager.AppSettings.Settings.Add(RangeEnd_Key, newSettings?.RangeEnd.ToString());
                }
                else
                {
                    configurationManager.AppSettings.Settings[RangeEnd_Key].Value = newSettings?.RangeEnd.ToString();
                }

                configurationManager.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err);
            }
        }
    }
}
