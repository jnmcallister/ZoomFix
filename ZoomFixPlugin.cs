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
        HandleInput();
    }

    void HandleInput()
    {
        // Check for each input
        if (Input.GetKeyDown(Configuration.ZoomOut))
            ZoomOut();
        if (Input.GetKeyDown(Configuration.ZoomIn))
            ZoomIn();
        if (Input.GetKeyDown(Configuration.ResetZoom))
            ResetZoom();
    }

    void ZoomOut()
    {
        Logger.LogInfo("Zoom out!");
    }

    void ZoomIn()
    {
        Logger.LogInfo("Zoom in!");
    }

    void ResetZoom()
    {
        Logger.LogInfo("Reset Zoom!");
    }
}
