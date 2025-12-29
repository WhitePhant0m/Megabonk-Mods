using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace BonkQoL;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    internal new static ManualLogSource Log;
    private static readonly Harmony Harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);

    public override void Load()
    {
        // Plugin startup logic
        Log = base.Log;
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        Harmony.PatchAll();
    }

    [HarmonyPatch(typeof(PickupManager), nameof(PickupManager.SpawnPickup))]
    internal class PickupPatch
    {
        [HarmonyPostfix]
        public static void InstantPickup(EPickup ePickup, PickupManager __instance, ref Pickup __result)
        {
            if (__result != null && ePickup == EPickup.Xp) __result.ApplyPickup();
        }
    }
}