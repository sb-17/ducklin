using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DucklinMenu : MonoBehaviour
{
    public Image image;
    public Sprite ducklin1;
    public Sprite ducklin2;

    void Start()
    {
        StartCoroutine(UpDown());
    }

    IEnumerator UpDown()
    {
        while (true)
        {
            if (image.sprite == ducklin1)
            {
                image.sprite = ducklin2;
            }
            else if (image.sprite == ducklin2)
            {
                image.sprite = ducklin1;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
