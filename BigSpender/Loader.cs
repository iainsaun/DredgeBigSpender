using System.Linq;
using Winch.Util;
using HarmonyLib;
using System.Reflection;

namespace BigSpender
{
    public class Loader
    {
        /// <summary>
        /// This method is run by Winch to initialize your mod
        /// </summary>
        public static void Initialize()
        {
            new Harmony("com.iainsaun.BigSpender").PatchAll(Assembly.GetExecutingAssembly());
            ApplicationEvents.Instance.OnGameLoaded += OnGameLoaded;
        }

        private static void OnGameLoaded()
        {
            var shipwrightDestination = DockUtil.GetAllShipyardDestinations().FirstOrDefault(shipyard => shipyard.Id == "destination.gm-shipwright");
            shipwrightDestination.itemSubtypesBought |= ItemSubtype.MATERIAL;
            shipwrightDestination.itemSubtypesBought |= ItemSubtype.GENERAL;
        }


    }
}