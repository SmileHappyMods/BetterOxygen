using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Configuration;

public class Config
{
    public static ConfigEntry<float> maximumOxygen;
    public static ConfigEntry<bool> infiniteOxygen;
    public static ConfigEntry<bool> refillOxygen;
    public static ConfigEntry<float> oxygenRefillRate;

    public Config(ConfigFile cfg)
    {
        maximumOxygen = cfg.Bind<float>("Oxygen Levels", "Maximum Oxygen (Minutes):", 12f, "Sets the amount of oxygen you have in minutes, restart required to take effect. Unmodded game is 8 minutes and 20 seconds or 8.33");
        infiniteOxygen = cfg.Bind("Extra Options", "Do you want infinite oxygen?", defaultValue: false, "Enabling this makes your oxygen last forever");
        refillOxygen = cfg.Bind("Extra Options", "Refill oxygen inside the diving bell?", defaultValue: false, "Enabling this makes your oxygen refill over time when standing in the diving bell. (A bit more fair than infinite O2)");
        oxygenRefillRate = cfg.Bind("Extra Options", "Oxygen Refill Rate (seconds/second):", defaultValue: 0f, "Controls the rate at which oxygen refills while standing inside the diving bell, in seconds of O2 gained per second inside the bell");
    }
}
