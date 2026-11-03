using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class SettingsPanelController : UIPanel
{
    [Header("Buttons")]
    [SerializeField] private Button closeButton;

    [Header("Music")]
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private TMP_Text musicValueText;

    [Header("Sound Effects")]
    [SerializeField] private Toggle sfxToggle;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private TMP_Text sfxValueText;

    private void OnEnable()
    {
        AudioSettingsManager audioSettings =
            AudioSettingsManager.Instance;

        // 读取管理器中已经保存的设置，初始化界面。
        musicToggle.SetIsOnWithoutNotify(
            audioSettings.MusicEnabled);

        musicSlider.SetValueWithoutNotify(
            audioSettings.MusicVolume);

        sfxToggle.SetIsOnWithoutNotify(
            audioSettings.SfxEnabled);

        sfxSlider.SetValueWithoutNotify(
            audioSettings.SfxVolume);

        // 初始化百分比文字。
        UpdateMusicValueText(musicSlider.value);
        UpdateSfxValueText(sfxSlider.value);

        // 关闭时禁止操作对应的 Slider。
        musicSlider.interactable = musicToggle.isOn;
        sfxSlider.interactable = sfxToggle.isOn;

        // 监听按钮、开关和滑块。
        closeButton.onClick.AddListener(Hide);

        musicToggle.onValueChanged.AddListener(
            OnMusicEnabledChanged);

        musicSlider.onValueChanged.AddListener(
            OnMusicVolumeChanged);

        sfxToggle.onValueChanged.AddListener(
            OnSfxEnabledChanged);

        sfxSlider.onValueChanged.AddListener(
            OnSfxVolumeChanged);
    }

    private void OnDisable()
    {
        closeButton.onClick.RemoveListener(Hide);

        musicToggle.onValueChanged.RemoveListener(
            OnMusicEnabledChanged);

        musicSlider.onValueChanged.RemoveListener(
            OnMusicVolumeChanged);

        sfxToggle.onValueChanged.RemoveListener(
            OnSfxEnabledChanged);

        sfxSlider.onValueChanged.RemoveListener(
            OnSfxVolumeChanged);
    }

    public override void Hide()
    {
        AudioSettingsManager.Instance.Save();
        base.Hide();
    }

    private void OnMusicEnabledChanged(bool enabled)
    {
        AudioSettingsManager.Instance.SetMusicEnabled(enabled);
        musicSlider.interactable = enabled;
    }

    private void OnMusicVolumeChanged(float value)
    {
        AudioSettingsManager.Instance.SetMusicVolume(value);
        UpdateMusicValueText(value);
    }

    private void OnSfxEnabledChanged(bool enabled)
    {
        AudioSettingsManager.Instance.SetSfxEnabled(enabled);
        sfxSlider.interactable = enabled;
    }

    private void OnSfxVolumeChanged(float value)
    {
        AudioSettingsManager.Instance.SetSfxVolume(value);
        UpdateSfxValueText(value);
    }

    private void UpdateMusicValueText(float value)
    {
        int percentage = Mathf.RoundToInt(value * 100f);
        musicValueText.text = $"{percentage}%";
    }

    private void UpdateSfxValueText(float value)
    {
        int percentage = Mathf.RoundToInt(value * 100f);
        sfxValueText.text = $"{percentage}%";
    }
}