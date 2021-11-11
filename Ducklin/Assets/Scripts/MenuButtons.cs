using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public GameObject settings;
    public Animator settingsAnimator;

    void Start()
    {
        settingsAnimator.Play("SettingsButton");
    }

    public void Help()
    {
        SceneManager.LoadScene("Help");
    }

    public void Upgrades()
    {
        SceneManager.LoadScene("Upgrades");
    }

    // remove from uploaded version
    void Update()
    {
        if(Input.GetKeyDown("r"))
        {
            PlayerPrefs.SetInt("Played", 0);
        }
    }

    public void Play()
    {
        if(PlayerPrefs.GetInt("Played") == 0)
        {
            SceneManager.LoadScene("Intro");
            SceneManager.LoadScene("Game");
            PlayerPrefs.SetInt("Player", 1);
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void Settings()
    {
        settings.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
