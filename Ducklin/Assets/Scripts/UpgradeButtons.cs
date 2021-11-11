using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeButtons : MonoBehaviour
{
    public Text LevelQ;
    public Text LevelE;
    public Text LevelR;

    public Text Eggs;

    public Text upgradeButtonTextQ;
    public Text upgradeButtonTextE;
    public Text upgradeButtonTextR;

    void Start()
    {
        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();

        LevelQ.text = "Level: " + PlayerPrefs.GetInt("qLevel").ToString();
        LevelE.text = "Level: " + PlayerPrefs.GetInt("eLevel").ToString();
        LevelR.text = "Level: " + PlayerPrefs.GetInt("rLevel").ToString();

        if(PlayerPrefs.GetInt("qNeed") == 0)
        {
            PlayerPrefs.SetInt("qNeed", 10);
        }

        if (PlayerPrefs.GetInt("eNeed") == 0)
        {
            PlayerPrefs.SetInt("eNeed", 15);
        }

        if (PlayerPrefs.GetInt("rNeed") == 0)
        {
            PlayerPrefs.SetInt("rNeed", 20);
        }

        upgradeButtonTextQ.text = "Upgrade (" + PlayerPrefs.GetInt("qNeed").ToString() + " eggs)";
        upgradeButtonTextE.text = "Upgrade (" + PlayerPrefs.GetInt("eNeed").ToString() + " eggs)";
        upgradeButtonTextR.text = "Upgrade (" + PlayerPrefs.GetInt("rNeed").ToString() + " eggs)";
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void UpgradeQ()
    {
        if(PlayerPrefs.GetInt("qLevel") < 10)
        {
            switch(PlayerPrefs.GetInt("qLevel"))
            {
                case 1:
                    if(PlayerPrefs.GetInt("Eggs") >= 10)
                    {
                        PlayerPrefs.SetInt("qLevel", 2);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 10);
                        LevelQ.text = "Level: " + PlayerPrefs.GetInt("qLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("qNeed", 25);
                        upgradeButtonTextQ.text = "Upgrade (" + PlayerPrefs.GetInt("qNeed").ToString() + " eggs)";
                    }
                    break;
                case 2:
                    if (PlayerPrefs.GetInt("Eggs") >= 25)
                    {
                        PlayerPrefs.SetInt("qLevel", 3);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 25);
                        LevelQ.text = "Level: " + PlayerPrefs.GetInt("qLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("qNeed", 50);
                        upgradeButtonTextQ.text = "Upgrade (" + PlayerPrefs.GetInt("qNeed").ToString() + " eggs)";
                    }
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("Eggs") >= 50)
                    {
                        PlayerPrefs.SetInt("qLevel", 4);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 50);
                        LevelQ.text = "Level: " + PlayerPrefs.GetInt("qLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("qNeed", 75);
                        upgradeButtonTextQ.text = "Upgrade (" + PlayerPrefs.GetInt("qNeed").ToString() + " eggs)";
                    }
                    break;
                case 4:
                    if (PlayerPrefs.GetInt("Eggs") >= 75)
                    {
                        PlayerPrefs.SetInt("qLevel", 5);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 75);
                        LevelQ.text = "Level: " + PlayerPrefs.GetInt("qLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("qNeed", 100);
                        upgradeButtonTextQ.text = "Upgrade (" + PlayerPrefs.GetInt("qNeed").ToString() + " eggs)";
                    }
                    break;
                case 5:
                    if (PlayerPrefs.GetInt("Eggs") >= 100)
                    {
                        PlayerPrefs.SetInt("qLevel", 6);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 100);
                        LevelQ.text = "Level: " + PlayerPrefs.GetInt("qLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("qNeed", 150);
                        upgradeButtonTextQ.text = "Upgrade (" + PlayerPrefs.GetInt("qNeed").ToString() + " eggs)";
                    }
                    break;
                case 6:
                    if (PlayerPrefs.GetInt("Eggs") >= 150)
                    {
                        PlayerPrefs.SetInt("qLevel", 7);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 150);
                        LevelQ.text = "Level: " + PlayerPrefs.GetInt("qLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("qNeed", 175);
                        upgradeButtonTextQ.text = "Upgrade (" + PlayerPrefs.GetInt("qNeed").ToString() + " eggs)";
                    }
                    break;
                case 7:
                    if (PlayerPrefs.GetInt("Eggs") >= 175)
                    {
                        PlayerPrefs.SetInt("qLevel", 8);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 175);
                        LevelQ.text = "Level: " + PlayerPrefs.GetInt("qLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("qNeed", 200);
                        upgradeButtonTextQ.text = "Upgrade (" + PlayerPrefs.GetInt("qNeed").ToString() + " eggs)";
                    }
                    break;
                case 8:
                    if (PlayerPrefs.GetInt("Eggs") >= 200)
                    {
                        PlayerPrefs.SetInt("qLevel", 9);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 200);
                        LevelQ.text = "Level: " + PlayerPrefs.GetInt("qLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("qNeed", 300);
                        upgradeButtonTextQ.text = "Upgrade (" + PlayerPrefs.GetInt("qNeed").ToString() + " eggs)";
                    }
                    break;
                case 9:
                    if (PlayerPrefs.GetInt("Eggs") >= 300)
                    {
                        PlayerPrefs.SetInt("qLevel", 10);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 300);
                        LevelQ.text = "Level: " + PlayerPrefs.GetInt("qLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        upgradeButtonTextQ.text = "Max level (10)";
                    }
                    break;
            }
        }
    }

    public void UpgradeE()
    {
        if (PlayerPrefs.GetInt("eLevel") < 10)
        {
            switch (PlayerPrefs.GetInt("eLevel"))
            {
                case 1:
                    if (PlayerPrefs.GetInt("Eggs") >= 30)
                    {
                        PlayerPrefs.SetInt("eLevel", 2);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 30);
                        LevelE.text = "Level: " + PlayerPrefs.GetInt("eLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("eNeed", 60);
                        upgradeButtonTextE.text = "Upgrade (" + PlayerPrefs.GetInt("eNeed").ToString() + " eggs)";
                    }
                    break;
                case 2:
                    if (PlayerPrefs.GetInt("Eggs") >= 60)
                    {
                        PlayerPrefs.SetInt("eLevel", 3);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 60);
                        LevelE.text = "Level: " + PlayerPrefs.GetInt("eLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("eNeed", 120);
                        upgradeButtonTextE.text = "Upgrade (" + PlayerPrefs.GetInt("eNeed").ToString() + " eggs)";
                    }
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("Eggs") >= 120)
                    {
                        PlayerPrefs.SetInt("eLevel", 4);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 120);
                        LevelE.text = "Level: " + PlayerPrefs.GetInt("eLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("eNeed", 150);
                        upgradeButtonTextE.text = "Upgrade (" + PlayerPrefs.GetInt("eNeed").ToString() + " eggs)";
                    }
                    break;
                case 4:
                    if (PlayerPrefs.GetInt("Eggs") >= 150)
                    {
                        PlayerPrefs.SetInt("eLevel", 5);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 150);
                        LevelE.text = "Level: " + PlayerPrefs.GetInt("eLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("eNeed", 200);
                        upgradeButtonTextE.text = "Upgrade (" + PlayerPrefs.GetInt("eNeed").ToString() + " eggs)";
                    }
                    break;
                case 5:
                    if (PlayerPrefs.GetInt("Eggs") >= 200)
                    {
                        PlayerPrefs.SetInt("eLevel", 6);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 200);
                        LevelE.text = "Level: " + PlayerPrefs.GetInt("eLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("eNeed", 300);
                        upgradeButtonTextE.text = "Upgrade (" + PlayerPrefs.GetInt("eNeed").ToString() + " eggs)";
                    }
                    break;
                case 6:
                    if (PlayerPrefs.GetInt("Eggs") >= 300)
                    {
                        PlayerPrefs.SetInt("eLevel", 7);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 300);
                        LevelE.text = "Level: " + PlayerPrefs.GetInt("eLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("eNeed", 400);
                        upgradeButtonTextE.text = "Upgrade (" + PlayerPrefs.GetInt("eNeed").ToString() + " eggs)";
                    }
                    break;
                case 7:
                    if (PlayerPrefs.GetInt("Eggs") >= 400)
                    {
                        PlayerPrefs.SetInt("eLevel", 8);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 400);
                        LevelE.text = "Level: " + PlayerPrefs.GetInt("eLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("eNeed", 500);
                        upgradeButtonTextE.text = "Upgrade (" + PlayerPrefs.GetInt("eNeed").ToString() + " eggs)";
                    }
                    break;
                case 8:
                    if (PlayerPrefs.GetInt("Eggs") >= 500)
                    {
                        PlayerPrefs.SetInt("eLevel", 9);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 500);
                        LevelE.text = "Level: " + PlayerPrefs.GetInt("eLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("eNeed", 600);
                        upgradeButtonTextE.text = "Upgrade (" + PlayerPrefs.GetInt("eNeed").ToString() + " eggs)";
                    }
                    break;
                case 9:
                    if (PlayerPrefs.GetInt("Eggs") >= 600)
                    {
                        PlayerPrefs.SetInt("eLevel", 10);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 600);
                        LevelE.text = "Level: " + PlayerPrefs.GetInt("eLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        upgradeButtonTextE.text = "Max level (10)";
                    }
                    break;
            }
        }
    }

    public void UpgradeR()
    {
        if (PlayerPrefs.GetInt("rLevel") < 10)
        {
            switch (PlayerPrefs.GetInt("rLevel"))
            {
                case 1:
                    if (PlayerPrefs.GetInt("Eggs") >= 40)
                    {
                        PlayerPrefs.SetInt("rLevel", 2);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 40);
                        LevelR.text = "Level: " + PlayerPrefs.GetInt("rLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("rNeed", 80);
                        upgradeButtonTextR.text = "Upgrade (" + PlayerPrefs.GetInt("rNeed").ToString() + " eggs)";
                    }
                    break;
                case 2:
                    if (PlayerPrefs.GetInt("Eggs") >= 80)
                    {
                        PlayerPrefs.SetInt("rLevel", 3);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 80);
                        LevelR.text = "Level: " + PlayerPrefs.GetInt("rLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("rNeed", 120);
                        upgradeButtonTextR.text = "Upgrade (" + PlayerPrefs.GetInt("rNeed").ToString() + " eggs)";
                    }
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("Eggs") >= 120)
                    {
                        PlayerPrefs.SetInt("rLevel", 4);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 120);
                        LevelR.text = "Level: " + PlayerPrefs.GetInt("rLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("rNeed", 180);
                        upgradeButtonTextR.text = "Upgrade (" + PlayerPrefs.GetInt("rNeed").ToString() + " eggs)";
                    }
                    break;
                case 4:
                    if (PlayerPrefs.GetInt("Eggs") >= 180)
                    {
                        PlayerPrefs.SetInt("rLevel", 5);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 180);
                        LevelR.text = "Level: " + PlayerPrefs.GetInt("rLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("rNeed", 250);
                        upgradeButtonTextR.text = "Upgrade (" + PlayerPrefs.GetInt("rNeed").ToString() + " eggs)";
                    }
                    break;
                case 5:
                    if (PlayerPrefs.GetInt("Eggs") >= 250)
                    {
                        PlayerPrefs.SetInt("rLevel", 6);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 250);
                        LevelR.text = "Level: " + PlayerPrefs.GetInt("rLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("rNeed", 300);
                        upgradeButtonTextR.text = "Upgrade (" + PlayerPrefs.GetInt("rNeed").ToString() + " eggs)";
                    }
                    break;
                case 6:
                    if (PlayerPrefs.GetInt("Eggs") >= 300)
                    {
                        PlayerPrefs.SetInt("rLevel", 7);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 300);
                        LevelR.text = "Level: " + PlayerPrefs.GetInt("rLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("rNeed", 400);
                        upgradeButtonTextR.text = "Upgrade (" + PlayerPrefs.GetInt("rNeed").ToString() + " eggs)";
                    }
                    break;
                case 7:
                    if (PlayerPrefs.GetInt("Eggs") >= 400)
                    {
                        PlayerPrefs.SetInt("rLevel", 8);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 400);
                        LevelR.text = "Level: " + PlayerPrefs.GetInt("rLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("rNeed", 500);
                        upgradeButtonTextR.text = "Upgrade (" + PlayerPrefs.GetInt("rNeed").ToString() + " eggs)";
                    }
                    break;
                case 8:
                    if (PlayerPrefs.GetInt("Eggs") >= 500)
                    {
                        PlayerPrefs.SetInt("rLevel", 9);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 500);
                        LevelR.text = "Level: " + PlayerPrefs.GetInt("rLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        PlayerPrefs.SetInt("rNeed", 600);
                        upgradeButtonTextR.text = "Upgrade (" + PlayerPrefs.GetInt("rNeed").ToString() + " eggs)";
                    }
                    break;
                case 9:
                    if (PlayerPrefs.GetInt("Eggs") >= 600)
                    {
                        PlayerPrefs.SetInt("rLevel", 10);
                        PlayerPrefs.SetInt("Eggs", PlayerPrefs.GetInt("Eggs") - 600);
                        LevelR.text = "Level: " + PlayerPrefs.GetInt("rLevel").ToString();
                        Eggs.text = PlayerPrefs.GetInt("Eggs").ToString();
                        upgradeButtonTextR.text = "Max level (10)";
                    }
                    break;
            }
        }
    }
}
