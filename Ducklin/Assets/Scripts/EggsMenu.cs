using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggsMenu : MonoBehaviour
{
    public Text EggsText;

    void Start()
    {
        EggsText.text = PlayerPrefs.GetInt("Eggs").ToString();
    }
}
