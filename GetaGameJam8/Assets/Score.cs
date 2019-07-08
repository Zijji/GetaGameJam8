using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int playerScore = 0;
    public GameObject playerScoreUI;

    // Update is called once per frame
    void Update()
    {
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore + "/28");

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
