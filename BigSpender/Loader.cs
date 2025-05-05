using System.Linq;
using Winch.Util;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using Winch.Config;
using UnityEngine.Localization.SmartFormat.Utilities;
using Winch.Core;

namespace BigSpender;

public class Loader
{
    public static void Initialize()
    {
        new Harmony("com.iainsaun.BigSpender").PatchAll(Assembly.GetExecutingAssembly());
        ApplicationEvents.Instance.OnGameLoaded += OnGameLoaded;
    }
    // This method enables the shipwright to buy materials and stuff like bait and crates and canisters
    private static void OnGameLoaded()
    {
        var shipwrightDestination = DockUtil.GetAllShipyardDestinations().FirstOrDefault(shipyard => shipyard.Id == "destination.gm-shipwright");
        shipwrightDestination.itemSubtypesBought |= ItemSubtype.MATERIAL;
        shipwrightDestination.itemSubtypesBought |= ItemSubtype.GENERAL;

        //GameManager.Instance.GameConfigData.trophyNotchSpawnChance = 1;
        //GameManager.Instance.GameConfigData.fishToCatchBetweenTrophyNotches = 0;
        GameManager.Instance.GameConfigData.greaterMarrowDebt = 500;
    }

    


}