using Exiled.API.Interfaces;

namespace RemoteHeal
{
    public class Config :IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public float Distance { get; set; } = 7;
    }
}