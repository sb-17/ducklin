using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Toggle music;
    public AudioSource bgmusic;
    public GameObject settings;

    int musicVolume;

    void Start()
    {
        musicVolume = PlayerPrefs.GetInt("MusicVolume");

        if(musicVolume == 1)
        {
            music.isOn = true;
        }
        else if(musicVolume == 0)
        {
            music.isOn = false;
        }
    }

    public void MusicToggle()
    {
        bgmusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();

        if(music.isOn)
        {
            PlayerPrefs.SetInt("MusicVolume", 1);
            musicVolume = 1;
            bgmusic.mute = false;
        }
        else
        {
            PlayerPrefs.SetInt("MusicVolume", 0);
            musicVolume = 0;
            bgmusic.mute = true;
        }
    }

    public void Exit()
    {
        settings.SetActive(false);
    }
}
