using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

/// Class used for keybinds 
internal static class Configuration
{
    static ConfigEntry<KeyCode>? _zoomOut;
    public static KeyCode ZoomOut => _zoomOut?.Value ?? KeyCode.None;

    public static void Init(ConfigFile config)
    {
		_zoomOut = config.Bind("Keybinds", "Zoom Out", KeyCode.O);
    }
}
