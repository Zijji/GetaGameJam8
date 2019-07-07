using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seekerbeast : MonoBehaviour
{
    public Sprite wokeSprite = null;
    public Sprite sleepSprite = null;
    public float enemySpeed = 3.0f;
    public GameObject target = null;
    public float addAngle = 180f;

    private SpriteRenderer getSprRen;
    private GameObject dreamstatecont = null;
    private int dreamState = -1;
    // Start is called before the first frame update
    void Start()
    {
        //xMoveDirection = 1;
        dreamstatecont = GameObject.Find("DreamStateController");
        getSprRen = GetComponent<SpriteRenderer>();
        //finds target
        target = GameObject.Find("player");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // move sprite towards the target location
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemySpeed);
            float getAngle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(getAngle + addAngle, Vector3.forward);
            CheckPlayerCollision(new Vector2(0f, 0f));
        }
    }
    void Update()
    {
        //
        /*
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * enemySpeed;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0));

        if (hit.collider != null)
        {
            if (hit.distance < 0.1f)
            {
                if (hit.collider.gameObject.layer == 8)//"Ground")
                {
                    Flip();
                }

            }
        }
        */

        

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
            Object.Destroy(gameObject);
        }

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
                    player_hit.collider.gameObject.GetComponent<PlayerMovement>().WokeBeastAttacked((int)Mathf.Sign(getVector.x));
                    //Flip();
                }

            }
        }
    }
}
