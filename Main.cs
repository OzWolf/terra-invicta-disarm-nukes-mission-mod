using HarmonyLib;
using UnityModManagerNet;

namespace DisarmNukesMission
{
    [EnableReloading]
    public class Main
    {
        public static Settings ModSettings = new Settings();

        public static bool Load(UnityModManager.ModEntry entry)
        {
            var harmony = new Harmony(entry.Info.Id);
            harmony.PatchAll();

            ModSettings = UnityModManager.ModSettings.Load<Settings>(entry);

            entry.OnSaveGUI = OnSaveGUI;
            entry.OnToggle = OnToggle;
            return true;
        }

        public static bool OnToggle(UnityModManager.ModEntry entry, bool value)
        {
            ModSettings.Enabled= value;
            return true;
        }

        public static void OnSaveGUI(UnityModManager.ModEntry entry)
        {
            ModSettings.Save(entry);
        }
    }
}
