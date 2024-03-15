using System;
using Exiled.API.Features;

namespace RemoteHeal
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "RemoteHeal";
        public override string Author => "TobisuchtetXD";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 8, 0);

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