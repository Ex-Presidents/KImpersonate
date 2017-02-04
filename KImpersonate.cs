using Rocket.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;

namespace KImpersonate
{
    public class KImpersonate : RocketPlugin
    {
        protected override void Load()
        {
            Rocket.Core.Logging.Logger.Log("Kr4ken Impersonate loaded!");
        }
        protected override void Unload()
        {
            Rocket.Core.Logging.Logger.Log("Kr4ken Impersonate unloaded!");
        }
    }
}
