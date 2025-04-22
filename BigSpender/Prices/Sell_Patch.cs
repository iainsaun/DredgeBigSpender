using UnityEngine;
using Winch.Core;
using HarmonyLib;

namespace BigSpender.Prices.Patches
{
    [HarmonyPatch(typeof(ItemManager), "GetItemValue")]
    public static class ItemManager_Patch
    {
        
        [HarmonyPostfix]
        public static void GetItemValue(ref decimal __result, SpatialItemInstance itemInstance, ItemManager.BuySellMode mode, float sellValueModifier = 0.5f)
        {
            SpatialItemData itemData = itemInstance.GetItemData<SpatialItemData>();
            bool flag = mode != ItemManager.BuySellMode.SELL;
            //marketDestination.itemSubtypesBought;
            if (itemData.id == "research-item") { itemData.value = 600; }
            if (itemData.id == "metal") { itemData.value = 1000; }
            if (!flag)
            {
                __result *= (decimal)1.0;
                if (itemData.itemSubtype == ItemSubtype.FISH)
                {
                    __result *= (decimal)0.2;
                    FishItemData FishItemData = itemData as FishItemData;
                    FishItemInstance FishItemInstance = itemInstance as FishItemInstance;
                    
                    // night-exclusive fish value bump
                    if (!FishItemData.day || FishItemData.isAberration)
                    {
                        __result *= (decimal)1.5;
                    }

                    // trophy size value bump
                    if (FishItemInstance.size >= 0.85)
                    {
                        __result *= 2;
                    }
                }

                if (itemData.itemSubtype == ItemSubtype.GENERAL)
                {
                    // make earning or dredging up research items more rewarding
                    if (itemData.id == "research-item")
                    {
                        __result *= (decimal)0.2;
                    }
                    // make canisters worth selling
                    else if (itemData.id == "canister")
                    {
                        __result *= 10;
                    }
                    else
                    {
                        __result *= 6;
                    }
                }

                // treasure is always worthwhile to collect, but multiplier reduces as base value increases so we don't get silly prices
                if (itemData.itemSubtype == ItemSubtype.TRINKET)
                {
                    __result *= ((decimal)3.0 - itemData.value / (decimal)100.0);
                }

                // making dredged materials worth more, except refined metal
                if (itemData.itemSubtype == ItemSubtype.MATERIAL && itemData.id != "metal")
                {
                    itemData.canBeSoldByPlayer = true;
                    __result *= 6;
                }
            }
            if (flag)
            {
                __result *= 1;
            }
        }
    }
}
