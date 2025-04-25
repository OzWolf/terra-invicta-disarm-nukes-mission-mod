using System;
using System.Collections.Generic;
using System.Text;
using UnityModManagerNet;

namespace DisarmNukesMission
{
    public class Settings : UnityModManager.ModSettings
    {
        public bool Enabled = true;

        public override void Save(UnityModManager.ModEntry entry)
        {
            Save(this, entry);
        }
    }
}