using System.Text.Json;

namespace WebApp_Automation.Common
{
    public static class Config
    {
        public static string AppUrl { get; private set; }
        public static string Browser { get; private set; }
        public static int ImplicitWait { get; private set; }
        public static string ScreenshotPath { get; private set; }
        public static bool Headless { get; private set; }

        static Config()
        {
            var json = File.ReadAllText("config.json");
            var configData = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

            AppUrl = configData["AppUrl"].ToString();
            Browser = configData["Browser"].ToString().ToLower();
            ImplicitWait = int.Parse(configData["ImplicitWait"].ToString());
            ScreenshotPath = configData["ScreenshotPath"].ToString();
            Headless = bool.Parse(configData["Headless"].ToString());
        }
    }
}
