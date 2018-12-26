﻿using System;
using Harmony;

namespace ResourceMonitor.Patchers
{
    /**
     * Patches into the Builder's Awake() method to alert our Resource monitor about the newly placed storage container - if it was a newly placed storage container.
     */
    [HarmonyPatch(typeof(StorageContainer))]
    [HarmonyPatch("Awake")]
    public class BuilderPatcher
    {
        public static Action<StorageContainer> OnStorageContainedAdded;

        [HarmonyPostfix]
        public static void Postfix(StorageContainer __instance)
        {
            OnStorageContainedAdded.Invoke(__instance);
        }
    }
}