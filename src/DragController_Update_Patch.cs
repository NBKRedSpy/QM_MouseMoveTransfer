using HarmonyLib;
using MGSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MouseMoveTransfer
{

    /// <summary>
    /// Changes the Drag and Drop functionality to act like the ctrl + click move functionality, but
    /// just do it all the time while ctrl + mouse button is clicked.
    /// The DragAndDrop controller is a universal component that runs all the time.
    /// </summary>
    [HarmonyPatch(typeof(DragController), nameof(DragController.Update))]
    public static class DragController_Update_Patch
    {

        public static void Postfix(DragController __instance)
        {
            //WARNING COPY:  This is a copy of the same code that the GetMouseButtonUp() code executes.
            //  It removes the delays and changes it to a Mouse button hold check.  Otherwise identical.

            //I preferred this over a transpile.
            //The base game ignores the click + left control.  It looks for mouse up.
            //  The item will be gone by then, so there should be no conflict.
            if (Plugin.Config.Keys.IsPressed())
            {
                
                if (__instance.IsDragging)
                {
                    __instance.EndDrag();
                }
                else
                {
                    ItemSlot itemSlot = __instance.RaycastSlotUnderCursor();
                    if (itemSlot != null)
                    {
                        SoundController_PlayUiSound__Patch.DisableSound = true;

                        __instance._controlClickCallback?.Invoke(itemSlot);

                        SoundController_PlayUiSound__Patch.DisableSound = false;
                    }
                    __instance._clickTimer.Pause();
                }
            }
        }
    }
}
