using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField]
    AudioMixer Volume;
    [SerializeField] GameObject OnOff;
    [SerializeField] GameObject menu;
    [SerializeField] Slider SensSlider;
    [SerializeField] Slider VolumeSlider;
    AudioSource As;
    [SerializeField] Image Image;
    [SerializeField] Sprite Mute, Unmute;
    [SerializeField] TMP_Dropdown Quality;
    private void Start()
    {
        As = GetComponent<AudioSource>();
        SetSens(PlayerPrefs.GetFloat("Sens", 300));
        SetVol(PlayerPrefs.GetFloat("Volume", 0));
    }
    public void playbutton()
    {
        As.Play();
        SceneManager.LoadScene(1);
        
    }
    public void ExitButton()
    {
        As.Play();
        Application.Quit();
    }
    public void mainmenu()
    {
        As.Play();
        menu.SetActive(true);
        float sens=PlayerPrefs.GetFloat("Sens");
        SensSlider.value = sens;        
        float vol = PlayerPrefs.GetFloat("Volume");
        VolumeSlider.value = vol;
        if (PlayerPrefs.GetInt("IsMute", 0) == 0)
        {
            Image.sprite = Unmute;
        }
        else
        {
            Image.sprite = Mute;
        }
        Quality.value = QualitySettings.GetQualityLevel();
        OnOff.SetActive(false);

    }
    public void back()
    {
        As.Play();
        menu.SetActive(false);
        OnOff.SetActive(true);

    }

    public void SetSens(float s)
    {
        PlayerPrefs.SetFloat("Sens",s);
    }
    public void SetVol(float v)
    {
        Volume.SetFloat("Volume",v);
        PlayerPrefs.SetFloat("Volume", v);
        Volume.GetFloat("Volume", out float value);
        if (value >= -78)
        {
            PlayerPrefs.SetInt("IsMute", 0);
            Image.sprite = Unmute;
        }
        else
        {
            PlayerPrefs.SetInt("IsMute", 1);
            Image.sprite = Mute;
        }

        
    }
    public void SetMute()
    {
        As.Play();
        if (PlayerPrefs.GetInt("IsMute", 0) == 0)
        {
            Image.sprite = Mute;
            Volume.SetFloat("Volume", -80);
            PlayerPrefs.SetFloat("Volume", -80);
            VolumeSlider.value = -80;
            PlayerPrefs.SetInt("IsMute", 1);
        }
        else
        {
            Image.sprite = Unmute;
            Volume.SetFloat("Volume", 0);
            PlayerPrefs.SetFloat("Volume", 0);
            PlayerPrefs.SetInt("IsMute", 0);
            VolumeSlider.value = 0;
        }
    }
    public void SetQuality(int Q)
    {
        As.Play();
        QualitySettings.SetQualityLevel(Q);
    }
}
