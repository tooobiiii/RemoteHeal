using System.ComponentModel;
using Exiled.API.Interfaces;

namespace RemoteHeal
{
    public class Config :IConfig
    {
        [Description("Enable plugin?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Enable debug?")]
        public bool Debug { get; set; } = false;
        [Description("Max distance a player can heal from")]
        public float Distance { get; set; } = 7;
    }
}