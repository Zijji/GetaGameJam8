using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMix : MonoBehaviour
{
    private GameObject dreamstatecont = null;
    public AudioClip DreamClip;
    public AudioClip NightmareClip;
    public AudioSource MusicSource;
    public bool isDead = false;
    private int dreamState = -1;
    private int soundCheck = -1;
    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = DreamClip;
        MusicSource.Play();
        dreamstatecont = GameObject.Find("DreamStateController");
    }

    // Update is called once per frame
    void Update()
    {
        //Dreamstate controller
        if (dreamstatecont != null)
        {
            soundCheck = dreamState;
            dreamState = dreamstatecont.GetComponent<DreamStateController>().GetDreamState();
        }

        if (dreamState != soundCheck)
        {
            MusicSource.Stop();
            if (dreamState == 0)
            {
                MusicSource.clip = NightmareClip;
                MusicSource.Play();
                
            }
            else if (dreamState == 1)
            {
                MusicSource.clip = DreamClip;
                MusicSource.Play();
            }
        }
 

    }
}
