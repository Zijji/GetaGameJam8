using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public GameObject player;
    private SpriteRenderer Fader;
    private Color alpha;
    private float alp;
    // Start is called before the first frame update
    void Start()
    {
        Fader = GetComponent<SpriteRenderer>();
        alpha = Fader.color;
        alpha.a = 0f;
        Fader.color = alpha;

        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player != null)
        {
            if (player.GetComponent<Score>().playerScore == 28)
            {
                alp += 0.1f;
                alpha.a = alp;
                Fader.color = alpha;

            }
        }

        if (alp >= 1)
        {
            SceneManager.LoadScene("EndScene");

        }



    }
}
