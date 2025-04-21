using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using JetBrains.Annotations;
// Copied from github.com/Johncook2/Stress-and-Taxes
// Only fish values reduced, all other item values the same or better, making dredging more lucrative
namespace BigSpender.Prices.Patches
{
    [HarmonyPatch(typeof(ItemManager), "GetItemValue")]
    public static class ItemManager_Patch
    {
        [HarmonyPostfix]
        public static void GetItemValue(ref decimal __result, SpatialItemInstance itemInstance, ItemManager.BuySellMode mode, float sellValueModifier = 0.5f)
        {
            SpatialItemData itemData = itemInstance.GetItemData<SpatialItemData>();
            //bool isTrophy = fishItemInstance.IsTrophySize();

            bool flag = mode != ItemManager.BuySellMode.SELL;
            if (!flag)
            {
                __result *= (decimal)1.2;
                if (itemData.itemSubtype == ItemSubtype.FISH)
                {
                    __result *= (decimal)0.2;
                    FishItemData FishItemData = itemData as FishItemData;
                    FishItemInstance FishItemInstance = itemInstance as FishItemInstance;
                    if (!FishItemData.day)
                    {
                        __result *= (decimal)2.0;
                    }
                    if (FishItemData.isAberration)
                    {
                        __result *= (decimal)2.0;
                    }
                    if (FishItemInstance.size >= 0.85)
                    {
                        __result += FishItemData.value * (decimal)0.4;
                    }
                }

                if (itemData.itemSubtype == ItemSubtype.MATERIAL)
                {
                    __result *= (decimal)5.0;
                }

            }
            if (flag)
            {
                __result *= (decimal)1.0;
            }
        }
    }
}
