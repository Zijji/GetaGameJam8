using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpspeed;
    public float movementSpeed;
    private Rigidbody2D thisRb2d;
    public GameObject groundObject = null;
    public GameObject wallObjectLeft = null;
    public GameObject wallObjectRight = null;


    private SpriteRenderer thisSprR;
    private bool onGround = false;
    private bool canJump = false;
    // Start is called before the first frame update
    void Start()
    {
        thisRb2d = GetComponent<Rigidbody2D> ();
        thisSprR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Checks if on ground
        onGround = Physics2D.Linecast(transform.position, groundObject.transform.position, 1 << LayerMask.NameToLayer("Ground"));
        if (onGround)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        //Makes movement
        float moveX = Input.GetAxis("Horizontal");
        if (moveX != 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeed * moveX, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            if (moveX < 0)
            {
                thisSprR.flipX = true;
                //Note: Only the rendering is affected. Use negative Transform.scale, if you want to affect all the other components (for example colliders).
            }
            else if (moveX > 0)
            {   
                thisSprR.flipX = false;
            }
        }
        //Flipping
        
        //Getting jump input
        if ((Input.GetAxis("Jump") != 0) && canJump)
        {
            thisRb2d.velocity = new Vector2(thisRb2d.velocity.x, jumpspeed);
            canJump = false;
        }
        
    }
    
}
