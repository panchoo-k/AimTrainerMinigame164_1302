using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public float Sensitivity { get; private set; } = 1f;
    public float AimTrainerTime { get; private set; } = 60f;
    public float Volume { get; private set; } = 1f;

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
    }

    public void SetSensitivity(float value)
    {
        Sensitivity = value;
        PlayerPrefs.SetFloat("Sensitivity", value);
        PlayerPrefs.Save();
    }

    public void SetAimTrainerTime(float value)
    {
        AimTrainerTime = value;
        PlayerPrefs.SetFloat("AimTrainerTime", value);
        PlayerPrefs.Save();
    }

    public void SetVolume(float value)
    {
        Volume = value;

        AudioListener.volume = value;

        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        Sensitivity =
            PlayerPrefs.GetFloat("Sensitivity", 1f);

        AimTrainerTime =
            PlayerPrefs.GetFloat("AimTrainerTime", 60f);

        Volume =
            PlayerPrefs.GetFloat("Volume", 1f);

        AudioListener.volume = Volume;
    }
}