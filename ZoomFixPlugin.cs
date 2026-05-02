using BepInEx;
using InControl;
using System;
using UnityEngine;

namespace ZoomFix;

// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "io.github.foxyrobo.zoomfix")]
public partial class ZoomFixPlugin : BaseUnityPlugin
{
    private void Awake()
    {
        // Put your initialization logic here
        Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");

        Configuration.Init(Config);
    }

    private void Update()
    {
        // TEST
        if (Input.GetKeyDown(Configuration.ZoomOut))
        {
            Logger.LogInfo("Zoom out!");
        }
    }
}
