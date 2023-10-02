using Backend_Final.Models;

namespace Backend_Final.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Slider { get; set; }
        public Dictionary<string,string> SettingsKeyValue { get; set; }
    }
}
