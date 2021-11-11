using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text eggs;

    void Start()
    {
        eggs.text = "Eggs collected: " + PlayerPrefs.GetInt("Collected").ToString();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
}
