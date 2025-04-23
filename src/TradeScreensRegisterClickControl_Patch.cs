using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MouseMoveTransfer
{
    /// <summary>
    /// Handles the FastTradeScreen and the TradeShuttleScreen not having the ctrl+click callback
    /// registered.  Looks like bug in the game's code.
    /// </summary>
    [HarmonyPatch()]
    public static class TradeScreensRegisterClickControl_Patch
    {
        public static IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.Method(typeof(FastTradeScreen), nameof(FastTradeScreen.OnEnable));
            yield return AccessTools.Method(typeof(TradeShuttleScreen), nameof(TradeShuttleScreen.OnEnable));
        }

        public static void Postfix(ScreenWithShipCargo __instance)
        {
            //Workaround - The trade and shuttle screens seem to have a bug where the ctrl + click callback
            //  is not registered.  
            UI.Drag.SetControlClickCallback(__instance.DragControllerControlClickCallback);
        }
    }
}
