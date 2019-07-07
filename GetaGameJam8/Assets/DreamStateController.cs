using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamStateController : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //Gets player
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetDreamState());
    }

    public int GetDreamState()
    {
        if(player != null)
        {
            return player.GetComponent<PlayerMovement>().returnDreamState();
        }
        else
        {
            return -1;
        }
    }
}
