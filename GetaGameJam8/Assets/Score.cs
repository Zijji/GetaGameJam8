using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public bool isDead = true;
    public int playerScore = 0;
    public GameObject playerScoreUI;

    // Update is called once per frame
    void Update()
    {
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore + "/28");

        //code for dying at the end of the game. Not a good place to put it at all, but I'm tired.
        if (isDead == true)
        {
            SceneManager.LoadScene("BadEnd");
        }

    }

    void OnTriggerEnter2D(Collider2D col)
{
        if (col.gameObject.tag == "CoinPickup")
        {
            playerScore += 1;
            Destroy(col.gameObject);
        }
    }
}
