using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioClip jumpClip;
    public AudioClip coinClip;
    public AudioClip moonClip;
    public AudioClip bounceClip;
    public AudioClip landingClip;
    public AudioClip gameOverClip;
    public AudioSource MusicSource;

    public bool jumpBool;
    public bool coinBool;
    public bool bounceBool;
    public bool landingBool;
    public bool gameOverBool;

    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = jumpClip;
        jumpBool = false;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (jumpBool == true)
        {
            MusicSource.clip = jumpClip;
            MusicSource.Play();
            jumpBool = false;
        }
        if(coinBool == true)
        {
            MusicSource.clip = coinClip;
            MusicSource.Play();
            coinBool = false;
        }
        if (bounceBool == true)
        {
            MusicSource.clip = bounceClip;
            MusicSource.Play();
            bounceBool = false;
        }
        if (gameOverBool == true)
        {
            MusicSource.clip = gameOverClip;
            MusicSource.Play();
            gameOverBool = false;
        }
    }
}
