using HarmonyLib;
// Copied from -> github.com/MegaPiggy/DredgeFastDock
// 2x speed is enough for me!
namespace BigSpender.QOL.Patches
{
    [HarmonyPatch(typeof(DockPOIHandler), nameof(DockPOIHandler.OnPressBegin))]
    internal static class DockSpeed_Patch
    {
        public static void Postfix()
        {
            GameManager.Instance.Player.Controller._autoMoveSpeed = 2f;
            GameManager.Instance.Player.Controller._lookSpeed = 2f;
        }
    }
}
