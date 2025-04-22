using UnityEngine;
using Winch.Core;
using HarmonyLib;

namespace BigSpender.Prices.Patches
{
    // Making Ironhaven crates sellable
    [HarmonyPatch(typeof(GridUI))]
    public static class GridUI_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("CreateObject")]
        public static void CreateObjectPrefix(GridUI __instance, SpatialItemInstance entry)
        {
            if (entry.id == "crate")
            {
                SpatialItemData crate = entry.GetItemData<SpatialItemData>();
                if (crate != null)
                {
                    crate.canBeSoldByPlayer = true;
                    crate.value = 30;
                }
            }
        }
    }
}
