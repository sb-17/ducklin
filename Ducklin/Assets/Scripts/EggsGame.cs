using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggsGame : MonoBehaviour
{
    public Text eggsCountText;

    void Start()
    {
        eggsCountText.text = "0";
    }
}