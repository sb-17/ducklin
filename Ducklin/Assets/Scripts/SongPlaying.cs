using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongPlaying : MonoBehaviour
{
    public GameObject songPlaying1;
    public GameObject songClosed;
    public Text songPlaying;
    int on;

    void Start()
    {
        StartCoroutine(onStart());
        on = PlayerPrefs.GetInt("SongPlayingBox");

        if(on == 0)
        {
            Close();
        }
        else if(on == 1)
        {
            Open();
        }
    }

    public void Close()
    {
        songPlaying1.SetActive(false);
        songClosed.SetActive(true);
        PlayerPrefs.SetInt("SongPlayingBox", 0);
    }

    public void Open()
    {
        songPlaying1.SetActive(true);
        songClosed.SetActive(false);
        PlayerPrefs.SetInt("SongPlayingBox", 1);
        switch (DontDestroy.playing)
        {
            case 0:
                songPlaying.text = "Song playing: Chunky Monkey";
                break;
            case 1:
                songPlaying.text = "Song playing: Infinite Doors";
                break;
            case 2:
                songPlaying.text = "Song playing: Jumpy Game";
                break;
            case 3:
                songPlaying.text = "Song playing: Potato";
                break;
            case 4:
                songPlaying.text = "Song playing: Street Love";
                break;
            case 5:
                songPlaying.text = "Song playing: Stupid Dancer";
                break;
            case 6:
                songPlaying.text = "Song playing: Sunny Day";
                break;
            case 7:
                songPlaying.text = "Song playing: Tiny Blocks";
                break;
            case 8:
                songPlaying.text = "Song playing: Zephyr";
                break;
        }
    }

    IEnumerator onStart()
    {
        yield return new WaitForSeconds(0.2f);
        Open();
    }
}
