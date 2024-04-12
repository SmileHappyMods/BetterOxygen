using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using BetterOxygen;
using System.Collections;

namespace BetterOxygen.Patches
{
    [HarmonyPatch(typeof(Player.PlayerData))]
    internal class PLayerDataPatch
    {

        static public float max02 = Config.maximumOxygen.Value;
        static public float btsMax = max02 * 60;
        static public bool infiniteO2 = Config.infiniteOxygen.Value;
        static public bool diveRefill = Config.refillOxygen.Value;
        static public bool sceneSwitch = false;
        static public int higher = 0;
        static public float preventSpeed = 0;

        [HarmonyPatch("UpdateValues")]
        [HarmonyPrefix]

        static void betterOxygenPatch(ref float ___maxOxygen, ref float ___remainingOxygen, ref bool ___usingOxygen, ref bool ___isInDiveBell)
        {
            if (sceneSwitch = SceneManager.GetActiveScene().name == "SurfaceScene")
            {
                ___maxOxygen = btsMax;
                ___remainingOxygen = btsMax;
                higher = 0;
            }
            if (sceneSwitch = SceneManager.GetActiveScene().name != "SurfaceScene" && ___isInDiveBell && infiniteO2 == false)
            {
                ___maxOxygen = btsMax;
                if (___maxOxygen > 500)
                {
                    while (___remainingOxygen < ___maxOxygen && higher == 0)
                    {
                        ___remainingOxygen += ___maxOxygen - 500;
                        higher = 1;
                    }   
                } 
                else while (___remainingOxygen > ___maxOxygen && higher ==0)
                    {
                        ___remainingOxygen -= 500 - ___maxOxygen;
                        higher = 1;
                    }
                if (diveRefill == true && higher == 1)
                {
                    preventSpeed = 0;
                    while (___remainingOxygen < ___maxOxygen && preventSpeed < 1)
                    {
                        ___remainingOxygen += Time.deltaTime / 10;
                        preventSpeed += Time.deltaTime;
                    }
                }
            }
            else if (infiniteO2 == true)
            {
                ___remainingOxygen = btsMax;
            }
        }
    }
}
