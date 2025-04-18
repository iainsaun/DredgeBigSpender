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
        }
    }
}