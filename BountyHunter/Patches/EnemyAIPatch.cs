using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace BountyHunter.Patches
{
    [HarmonyPatch(typeof(EnemyAI))]
    internal class EnemyAIPatch
    {
        [HarmonyPatch(nameof(EnemyAI.KillEnemy))]
        [HarmonyPostfix]
        static void rewardCreditsPatch()
        {
            Terminal terminal = UnityEngine.Object.FindObjectOfType<Terminal>();
            terminal.useCreditsCooldown = true;
            terminal.groupCredits += 1000;
            terminal.SyncGroupCreditsServerRpc(terminal.groupCredits, terminal.numberOfItemsInDropship);
            Debug.Log("Adding money");
        }
    }
}
