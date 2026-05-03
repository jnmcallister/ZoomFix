using BepInEx;
using InControl;
using System;
using UnityEngine;

namespace ZoomFix;

// TODO - adjust the plugin guid as needed
[BepInAutoPlugin(id: "io.github.foxyrobo.zoomfix")]
public partial class ZoomFixPlugin : BaseUnityPlugin
{
    float defaultFOV = -1f;
    float currentFOV = -1f;

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

    void CheckIfDefaultsAreSet()
    {
        // Sets current and default FOV
        if (currentFOV == -1 || defaultFOV == -1)
        {
            currentFOV = GameCameras.instance.mainCamera.fieldOfView;
            defaultFOV = currentFOV;
            Logger.LogInfo($"Set fov to {currentFOV}");
        }
    }

    void ZoomOut()
    {
        CheckIfDefaultsAreSet();

        // Increase zoom factor (borrows some code from debug mod)
        float currentZoomFactor = GameCameras.instance.tk2dCam.zoomFactor;
        GameCameras.instance.tk2dCam.zoomFactor =
            currentZoomFactor - currentZoomFactor * Configuration.ZoomMultiplier;

        // Calculate new FOV
        currentFOV = CalculateNewFOV(defaultFOV, GameCameras.instance.tk2dCam.ZoomFactor);
        
        // Update FOV
        LightBlurredBackground lbb = GameObject.FindFirstObjectByType<LightBlurredBackground>();
        lbb.OnCameraFovChanged(currentFOV);

        // Log statements
        Logger.LogInfo($"Zoom out to {GameCameras.instance.tk2dCam.ZoomFactor}");
        Logger.LogInfo($"Set fov to {currentFOV}");
    }

    void ZoomIn()
    {
        CheckIfDefaultsAreSet();

        // Increase zoom factor (borrows some code from debug mod)
        float currentZoomFactor = GameCameras.instance.tk2dCam.zoomFactor;
        GameCameras.instance.tk2dCam.zoomFactor =
            currentZoomFactor + currentZoomFactor * Configuration.ZoomMultiplier;

        // Calculate new FOV
        currentFOV = CalculateNewFOV(defaultFOV, GameCameras.instance.tk2dCam.ZoomFactor);

        // Update FOV
        LightBlurredBackground lbb = GameObject.FindFirstObjectByType<LightBlurredBackground>();
        lbb.OnCameraFovChanged(currentFOV);

        // Log statements
        Logger.LogInfo($"Zoom in to {GameCameras.instance.tk2dCam.ZoomFactor}");
        Logger.LogInfo($"Set fov to {currentFOV}");
    }

    void ResetZoom()
    {
        CheckIfDefaultsAreSet();

        // Set zoom to default (borrows some code from debug mod)
        GameCameras.instance.tk2dCam.zoomFactor = Configuration.DefaultZoom;

        // Set FOV to default
        currentFOV = defaultFOV;

        // Update FOV
        LightBlurredBackground lbb = GameObject.FindFirstObjectByType<LightBlurredBackground>();
        lbb.OnCameraFovChanged(currentFOV);

        // Log statements
        Logger.LogInfo($"Reset zoom to {Configuration.DefaultZoom}");
        Logger.LogInfo($"Set fov to {currentFOV}");
    }

    float CalculateNewFOV(float baseFOV, float zoomFactor)
    {
        return 2 * Mathf.Atan(Mathf.Tan(baseFOV / 2 * Mathf.Deg2Rad) / zoomFactor) * Mathf.Rad2Deg;
    }
}
