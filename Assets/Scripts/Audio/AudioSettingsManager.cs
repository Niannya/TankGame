using UnityEngine;
using UnityEngine.Audio;

public sealed class AudioSettingsManager : MonoBehaviour
{
    public static AudioSettingsManager Instance { get; private set; }

    [SerializeField] private AudioMixer audioMixer;

    private const string MusicParameter = "MusicVolume";
    private const string SfxParameter = "SfxVolume";

    private const string MusicVolumeKey = "MusicVolume";
    private const string SfxVolumeKey = "SfxVolume";
    private const string MusicEnabledKey = "MusicEnabled";
    private const string SfxEnabledKey = "SfxEnabled";

    public float MusicVolume { get; private set; }
    public float SfxVolume { get; private set; }
    public bool MusicEnabled { get; private set; }
    public bool SfxEnabled { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSettings();
        ApplyAllSettings();
    }

    public void SetMusicVolume(float value)
    {
        MusicVolume = Mathf.Clamp01(value);
        PlayerPrefs.SetFloat(MusicVolumeKey, MusicVolume);
        ApplyMusicVolume();
    }

    public void SetSfxVolume(float value)
    {
        SfxVolume = Mathf.Clamp01(value);
        PlayerPrefs.SetFloat(SfxVolumeKey, SfxVolume);
        ApplySfxVolume();
    }

    public void SetMusicEnabled(bool enabled)
    {
        MusicEnabled = enabled;
        PlayerPrefs.SetInt(MusicEnabledKey, enabled ? 1 : 0);
        ApplyMusicVolume();
    }

    public void SetSfxEnabled(bool enabled)
    {
        SfxEnabled = enabled;
        PlayerPrefs.SetInt(SfxEnabledKey, enabled ? 1 : 0);
        ApplySfxVolume();
    }

    public void Save()
    {
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        MusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 0.8f);
        SfxVolume = PlayerPrefs.GetFloat(SfxVolumeKey, 0.8f);

        MusicEnabled = PlayerPrefs.GetInt(MusicEnabledKey, 1) == 1;
        SfxEnabled = PlayerPrefs.GetInt(SfxEnabledKey, 1) == 1;
    }

    private void ApplyAllSettings()
    {
        ApplyMusicVolume();
        ApplySfxVolume();
    }

    private void ApplyMusicVolume()
    {
        float decibels = MusicEnabled
            ? LinearToDecibels(MusicVolume)
            : -80f;

        audioMixer.SetFloat(MusicParameter, decibels);
    }

    private void ApplySfxVolume()
    {
        float decibels = SfxEnabled
            ? LinearToDecibels(SfxVolume)
            : -80f;

        audioMixer.SetFloat(SfxParameter, decibels);
    }

    private static float LinearToDecibels(float value)
    {
        if (value <= 0.0001f)
            return -80f;

        return Mathf.Log10(value) * 20f;
    }
}