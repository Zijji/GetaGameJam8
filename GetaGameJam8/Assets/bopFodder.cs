using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bopFodder : MonoBehaviour
{

    private SpriteRenderer getSprRen;
    private GameObject dreamstatecont = null;
    private int dreamState = -1;
    public Sprite wokeSprite = null;
    public Sprite sleepSprite = null;
    public int xMoveDirection; //used for collision checks
    // Start is called before the first frame update
    void Start()
    {
        dreamstatecont = GameObject.Find("DreamStateController");
        getSprRen = GetComponent<SpriteRenderer>();
        xMoveDirection = 1;//used for collision checks
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerCollision(new Vector2(-xMoveDirection, 0));
        CheckPlayerCollision(new Vector2(xMoveDirection, 0));

        //Dreamstate controller
        if (dreamstatecont != null)
        {
            dreamState = dreamstatecont.GetComponent<DreamStateController>().GetDreamState();
        }

        if (dreamState == 0)
        {
            getSprRen.sprite = wokeSprite;
        }
        else if (dreamState == 1)
        {
            getSprRen.sprite = sleepSprite;
        }
    }

    void CheckPlayerCollision(Vector2 getVector)
    {
        RaycastHit2D player_hit = Physics2D.Raycast(transform.position, getVector);
        if (player_hit.collider != null)
        {
            if (player_hit.distance < 0.3f)
            {
                if (player_hit.collider.gameObject.name == "player")//"Ground")
                {
                    player_hit.collider.gameObject.GetComponent<PlayerMovement>().WokeBeastAttacked((int)Mathf.Sign(getVector.x));
                    //Flip();
                }

            }
        }
    }
}
