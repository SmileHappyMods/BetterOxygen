using BepInEx;
using BepInEx.Logging;
using BetterOxygen.Patches;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterOxygen
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class BetterO2 : BaseUnityPlugin
    {
        private const string modGUID = "Symphony.BetterOxygen";
        private const string modName = "Better Oxygen";
        private const string modVersion = "1.3.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static BetterO2 Instance;

        internal ManualLogSource mls;

        public static Config BsConfig { get; internal set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            BsConfig = new Config(base.Config);
            mls.LogInfo("Better breathing starts here");

            harmony.PatchAll();
        }
    }
}
