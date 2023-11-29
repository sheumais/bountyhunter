using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using BountyHunter.Patches;
using HarmonyLib;

namespace BountyHunter
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class BountyHounterBase : BaseUnityPlugin
    {
        private const string modGUID = "Sheumais.BountyHunter";
        private const string modName = "Bounty Hunter";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static BountyHounterBase Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null) {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("Bounty Hunter has awoken.");

            harmony.PatchAll(typeof(BountyHounterBase));
            harmony.PatchAll(typeof(EnemyAIPatch));
        }
    }
}
