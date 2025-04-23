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
    /// Silences the UI Sounds
    /// </summary>
    [HarmonyPatch(typeof(SoundController), nameof(SoundController.PlayUiSound),
        new Type[] { typeof(AudioClip), typeof(bool), typeof(float) })]

    public static class SoundController_PlayUiSound__Patch
    {
        public static bool DisableSound = false;

        public static bool Prefix(MainMenuScreen __instance)
        {
            return !DisableSound;
        }
    }
}
