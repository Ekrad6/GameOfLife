using Newtonsoft.Json;

namespace GameOfLife.Configuration;

public class Settings
{
    public int WorldWidth { get; set; }
    public int WorldHeigth { get; set; }
    public int WorldViewWidth { get; set; }
    public int WorldViewHeigth { get; set; }

    internal void Load()
    {
        try
        {
            using (StreamReader reader = new("settings.json"))
            {
                string json = reader.ReadToEnd();
                Settings settings = JsonConvert.DeserializeObject<Settings>(json);

                WorldWidth = settings.WorldWidth;
                WorldHeigth = settings.WorldHeigth;
                WorldViewWidth = settings.WorldViewWidth;
                WorldViewHeigth = settings.WorldViewHeigth;

            }
        }
        catch
        {
            throw;
        }
    }
}
