using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using HarmonyLib;

namespace BonkQoL;

[HarmonyPatch(typeof(PickupManager), nameof(PickupManager.SpawnPickup))]
internal class PickupPatch {
    [HarmonyPostfix]
    private static void InstantPickup(EPickup ePickup, PickupManager __instance, ref Pickup __result) {
        if (__result != null && ePickup is EPickup.Xp or EPickup.Gold) __result.ApplyPickup();
    }
}