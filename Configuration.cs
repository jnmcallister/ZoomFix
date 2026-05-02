using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

/// Class used for keybinds 
internal static class Configuration
{
    static ConfigEntry<KeyCode>? _zoomOut;
    public static KeyCode ZoomOut => _zoomOut?.Value ?? KeyCode.None;

	static ConfigEntry<KeyCode>? _zoomIn;
	public static KeyCode ZoomIn => _zoomIn?.Value ?? KeyCode.None;

	static ConfigEntry<KeyCode>? _resetZoom;
	public static KeyCode ResetZoom => _resetZoom?.Value ?? KeyCode.None;

	public static void Init(ConfigFile config)
    {
		_zoomOut = config.Bind("Keybinds", "Zoom Out", KeyCode.O);
		_zoomIn = config.Bind("Keybinds", "Zoom In", KeyCode.P);
		_resetZoom = config.Bind("Keybinds", "Reset Zoom", KeyCode.LeftBracket);
	}
}
