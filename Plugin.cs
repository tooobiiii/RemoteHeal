using System;
using Exiled.API.Features;

namespace RemoteHeal
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "RemoteHeal";
        public override string Author { get; } = "TobisuchtetXD";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(8, 8, 0);

        public static Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            base.OnDisabled();
        }
    }
}