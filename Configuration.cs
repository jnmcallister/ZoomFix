using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

/// Class used for keybinds and other configurable settings 
internal static class Configuration
{
	// Keybinds
    static ConfigEntry<KeyCode>? _zoomOut;
    public static KeyCode ZoomOut => _zoomOut?.Value ?? KeyCode.None;
	static ConfigEntry<KeyCode>? _zoomIn;
	public static KeyCode ZoomIn => _zoomIn?.Value ?? KeyCode.None;
	static ConfigEntry<KeyCode>? _resetZoom;
	public static KeyCode ResetZoom => _resetZoom?.Value ?? KeyCode.None;

	// Constants
	static ConfigEntry<float>? _zoomMultiplier;
	public static float ZoomMultiplier = _zoomMultiplier?.Value ?? 0.05f;
	static ConfigEntry<float>? _defaultZoom;
	public static float DefaultZoom = _defaultZoom?.Value ?? 1.0f;

	public static void Init(ConfigFile config)
    {
		// Keybinds
		_zoomOut = config.Bind("Keybinds", "Zoom Out", KeyCode.O);
		_zoomIn = config.Bind("Keybinds", "Zoom In", KeyCode.P);
		_resetZoom = config.Bind("Keybinds", "Reset Zoom", KeyCode.LeftBracket);

		// Constants
		_zoomMultiplier = config.Bind("Constants", "Zoom Multiplier", 0.05f);
		_defaultZoom = config.Bind("Constants", "Default Zoom", 1f);
	}
}
