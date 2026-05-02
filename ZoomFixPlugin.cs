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
        // Increase zoom factor (borrows some code from debug mod)
        float currentZoomFactor = GameCameras.instance.tk2dCam.zoomFactor;
        GameCameras.instance.tk2dCam.zoomFactor =
            currentZoomFactor - currentZoomFactor * Configuration.ZoomMultiplier;

        // Log statement
        Logger.LogInfo($"Zoom in to {GameCameras.instance.tk2dCam.zoomFactor}");
    }

    void ZoomIn()
    {
        // Increase zoom factor (borrows some code from debug mod)
        float currentZoomFactor = GameCameras.instance.tk2dCam.zoomFactor;
        GameCameras.instance.tk2dCam.zoomFactor = 
            currentZoomFactor + currentZoomFactor * Configuration.ZoomMultiplier;

        // Log statement
        Logger.LogInfo($"Zoom out to {GameCameras.instance.tk2dCam.zoomFactor}");
    }

    void ResetZoom()
    {
        // Set zoom to default (borrows some code from debug mod)
        GameCameras.instance.tk2dCam.zoomFactor = Configuration.DefaultZoom;

        // Log statement
        Logger.LogInfo($"Reset zoom to {Configuration.DefaultZoom}");
    }
}
