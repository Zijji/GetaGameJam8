using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wokebeast : MonoBehaviour
{
    public Sprite wokeSprite = null;
    public Sprite sleepSprite = null;
    public float enemySpeed = 3.0f;
    public GameObject groundCheckLeft = null;
    public GameObject groundCheckRight = null;

    public int xMoveDirection;
    private SpriteRenderer getSprRen;
    private GameObject dreamstatecont = null;
    private int dreamState = -1;
    // Start is called before the first frame update
    void Start()
    {
        xMoveDirection = 1;
        dreamstatecont = GameObject.Find("DreamStateController");
        getSprRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * enemySpeed;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0));
        if( hit.collider != null)
        {
            if (hit.distance < 0.1f)
            {
                if (hit.collider.gameObject.layer == 8)//"Ground")
                {
                    Flip();
                }

            }
        }
        if(xMoveDirection < 0)
        { 
            bool onGround = Physics2D.Linecast(transform.position, groundCheckLeft.transform.position, 1 << LayerMask.NameToLayer("Ground"));
            if (onGround == false)
            {
                Flip();
            }
        }

        if (xMoveDirection > 0)
        {
            bool onGround = Physics2D.Linecast(transform.position, groundCheckRight.transform.position, 1 << LayerMask.NameToLayer("Ground"));
            if (onGround == false)
            {
                Flip();
            }
        }

        //Dreamstate controller
        if (dreamstatecont != null)
        {
            dreamState = dreamstatecont.GetComponent< DreamStateController>().GetDreamState();
        }

        if(dreamState == 0)
        {
            getSprRen.sprite = wokeSprite;
        }
        else if (dreamState == 1)
        {
            getSprRen.sprite = sleepSprite;
        }

        //Injures player
        /*
        RaycastHit2D player_hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0));
        
        if (player_hit.collider != null)
        {
            if (player_hit.distance < 0.2f)
            {
                if (player_hit.collider.gameObject.name == "player")//"Ground")
                {
                    player_hit.collider.gameObject.GetComponent<PlayerMovement>().WokeBeastAttacked();
                    //Flip();
                }

            }
        }
        */
        CheckPlayerCollision(new Vector2(-xMoveDirection, 0));
        CheckPlayerCollision(new Vector2(xMoveDirection, 0));

        /*
        RaycastHit2D player_hit_back = Physics2D.Raycast(transform.position, new Vector2(-xMoveDirection, 0));
        if (player_hit_back.collider != null)
        {
            if (player_hit_back.distance < 0.2f)
            {
                if (player_hit_back.collider.gameObject.name == "player")//"Ground")
                {
                    player_hit_back.collider.gameObject.GetComponent<PlayerMovement>().WokeBeastAttacked();
                    //Flip();
                }

            }
        }
        */
    }

    void CheckPlayerCollision(Vector2 getVector)
    {
        RaycastHit2D player_hit = Physics2D.Raycast(transform.position, getVector);
        if (player_hit.collider != null)
        {
            if (player_hit.distance < 0.2f)
            {
                if (player_hit.collider.gameObject.name == "player")//"Ground")
                {
                    player_hit.collider.gameObject.GetComponent<PlayerMovement>().WokeBeastAttacked( (int) Mathf.Sign(getVector.x));
                    //Flip();
                }

            }
        }
    }

    void Flip()
    {
        if (xMoveDirection > 0 )
        {
            xMoveDirection = -1;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            xMoveDirection = 1;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
