using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    [SerializeField] private Slider sensitivitySlider;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Dropdown aimTimeDropdown;

    private void OnEnable()
    {
        if (SettingsManager.Instance == null)
            return;

        sensitivitySlider.SetValueWithoutNotify(
            SettingsManager.Instance.Sensitivity
        );

        volumeSlider.SetValueWithoutNotify(
            SettingsManager.Instance.Volume
        );

        float time = SettingsManager.Instance.AimTrainerTime;

        if (time == 30f)
            aimTimeDropdown.SetValueWithoutNotify(0);
        else if (time == 60f)
            aimTimeDropdown.SetValueWithoutNotify(1);
        else
            aimTimeDropdown.SetValueWithoutNotify(2);

        aimTimeDropdown.RefreshShownValue();
    }

    public void ChangeSensitivity(float value)
    {
        SettingsManager.Instance.SetSensitivity(value);
    }

    public void ChangeVolume(float value)
    {
        SettingsManager.Instance.SetVolume(value);
    }

    public void ChangeAimTime(int option)
    {
        SettingsManager.Instance.SetAimTrainerTimeFromDropdown(option);
    }
}