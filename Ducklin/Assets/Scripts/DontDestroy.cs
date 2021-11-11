using UnityEngine;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour {
    public bool randomPlay = false; // checkbox for random play
    public AudioClip[] clips;
    public AudioSource audioSource;
    int clipOrder = 0; // for ordered playlist
    public GameObject songPlayingPanel;
    public static int playing;
    public Text songPlaying;

    void Start()
    {
        audioSource.loop = false;
        int volume = PlayerPrefs.GetInt("MusicVolume");
        if(volume == 0)
        {
            audioSource.mute = true;
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            // if random play is selected
            if (randomPlay == true)
            {
                audioSource.clip = GetRandomClip();
                audioSource.Play();
            }
            else
            {
                audioSource.clip = GetNextClip();
                audioSource.Play();
            }
        }
    }

    // function to get a random clip
    private AudioClip GetRandomClip()
    {
        playing = Random.Range(0, clips.Length);
        return clips[playing];
    }

    // function to get the next clip in order, then repeat from the beginning of the list.
    private AudioClip GetNextClip()
    {
        if (clipOrder >= clips.Length - 1)
        {
            clipOrder = 0;
            playing = 0;
        }
        else
        {
            clipOrder += 1;
            playing += 1;
        }
        return clips[clipOrder];
    }
    
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
