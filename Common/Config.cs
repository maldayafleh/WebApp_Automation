using System;
using System.IO;
using System.Text.Json;

namespace WebApp_Automation.Common
{
    public class ConfigData
    {
        public string AppUrl { get; set; }
        public string Browser { get; set; }
        public int ImplicitWait { get; set; }
        public string ScreenshotPath { get; set; }
        public bool Headless { get; set; }
    }

    public static class Config
    {
        public static ConfigData Settings { get; private set; }

        static Config()
        {
            // Get the path to the config.json file, based on the application's base directory
            string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Properties", "config.json");

            // Check if the file exists
            if (!File.Exists(configFilePath))
                throw new FileNotFoundException("The config.json file was not found.", configFilePath);

            try
            {
                // Read and deserialize the JSON file
                var json = File.ReadAllText(configFilePath);
                Settings = JsonSerializer.Deserialize<ConfigData>(json);

                // Check for deserialization issues
                if (Settings == null)
                    throw new Exception("Failed to deserialize config.json.");

                // Ensure that all required values are set
                if (string.IsNullOrEmpty(Settings.AppUrl))
                    throw new Exception("AppUrl is missing in config.json.");
                if (string.IsNullOrEmpty(Settings.Browser))
                    throw new Exception("Browser is missing in config.json.");
                if (string.IsNullOrEmpty(Settings.ScreenshotPath))
                    throw new Exception("ScreenshotPath is missing in config.json.");

                // Optional: You can provide default values for missing configurations if needed
                if (Settings.ImplicitWait == 0) Settings.ImplicitWait = 10; // Default to 10 seconds
                if (string.IsNullOrEmpty(Settings.Browser)) Settings.Browser = "chrome"; // Default to Chrome

            }
            catch (JsonException ex)
            {
                throw new Exception("Error parsing config.json. Please ensure it's a valid JSON file.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading configuration.", ex);
            }
        }
    }
}
