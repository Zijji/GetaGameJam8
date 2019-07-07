using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wokebeast : MonoBehaviour
{
    public Sprite wokeSprite = null;
    public Sprite sleepSprite = null;
    public float enemySpeed = 3.0f;

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
        
        if (hit.distance < 0.1f)
        {
            if(hit.collider.gameObject.layer == 8)//"Ground")
            {
                Flip();
            }
            
        }
        //Dreamstate controller
        if(dreamstatecont != null)
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

    }

    void Flip()
    {
        if (xMoveDirection > 0 )
        {
            xMoveDirection = -1;
        }
        else
        {
            xMoveDirection = 1;
        }
    }
}
