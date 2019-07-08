using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Scene scene = SceneManager.GetActiveScene();

    public float jumpspeed;
    public float movementSpeed;
    private Rigidbody2D thisRb2d;
    public GameObject groundObject = null;
    public GameObject groundObjectBack = null;
    public GameObject groundObjectFront = null;
    public GameObject wallObjectLeft = null;
    public GameObject wallObjectRight = null;
    public PhysicsMaterial2D thisPM2D = null;
    public float knockbackXMagn = 2.0f;
    public float knockbackYMagn = 3.0f;
    public int coinScore = 0;

    private float knockbackX = 0;
    private bool isInvuln = false;
    private int invulnFrames;
    public int invulnFrameDuration = 20;
    private SpriteRenderer thisSprR;
    private bool onGround = false;
    private bool canJump = false;
    public enum DreamState { nightmare, dream };
    public DreamState currentDreamState = DreamState.dream;
    private float prevY;

    public GameObject ScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        thisRb2d = GetComponent<Rigidbody2D>();
        thisSprR = GetComponent<SpriteRenderer>();
        prevY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Scene1");
        }
        //Checks if on ground
        onGround = Physics2D.Linecast(transform.position, groundObject.transform.position, 1 << LayerMask.NameToLayer("Ground"));
        if (onGround == false)
        {
            onGround = Physics2D.Linecast(transform.position, groundObjectBack.transform.position, 1 << LayerMask.NameToLayer("Ground"));
        }
        if (onGround == false)
        {
            onGround = Physics2D.Linecast(transform.position, groundObjectFront.transform.position, 1 << LayerMask.NameToLayer("Ground"));
        }
        //if (gameObject.GetComponent<Rigidbody2D>().velocity.y < 0.01f) && (gameObject.GetComponent<Rigidbody2D>().velocity.y < 0.01f)
        //onGround = 
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
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(knockbackX + movementSpeed * moveX, gameObject.GetComponent<Rigidbody2D>().velocity.y);
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
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(knockbackX + 0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }

        //Turning down knockback
        if (knockbackX > 0)
        {
            knockbackX -= 0.05f;
            if (knockbackX < 0)
            {
                knockbackX = 0;
            }
        }
        if (knockbackX < 0)
        {
            knockbackX += 0.05f;
            if (knockbackX > 0)
            {
                knockbackX = 0;
            }
        }
        //Flipping

        //Getting jump input
        if ((Input.GetAxis("Jump") != 0) && canJump)
        {
            Jump();
            /*
            thisRb2d.velocity = new Vector2(thisRb2d.velocity.x, jumpspeed);
            canJump = false;
            */
        }

        //Invuln frame
        if (isInvuln)
        {
            invulnFrames--;
            if (invulnFrames < 0)
            {
                isInvuln = false;
            }
        }

        //CheckPlayerCollision(new Vector2(0f, 0f));
    }

    private void PlayerScore()
    {
        throw new NotImplementedException();
    }

    public int returnDreamState()
    {
        return (int)currentDreamState;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Jump();
            //Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Death")
        {
            Die();
            //Destroy(col.gameObject);
        }
        /*
        if (col.gameObject.tag == "CoinPickup")
        {
            coinScore++;
            Destroy(col.gameObject);
        }
        */
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "CoinPickup")
        {
            coinScore++;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "PickupMoon")
        {
            if (currentDreamState == DreamState.nightmare)
            {
                currentDreamState = DreamState.dream;
                Destroy(col.gameObject);
            }
        }
    }


    void Jump()
    {
        thisRb2d.velocity = new Vector2(thisRb2d.velocity.x, jumpspeed);
        canJump = false;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void WokeBeastAttacked(int direction)
    {
        if (!isInvuln)
        {
            if (currentDreamState == DreamState.dream)
            {
                currentDreamState = DreamState.nightmare;
                isInvuln = true;
                invulnFrames = invulnFrameDuration;
            }
            else if (currentDreamState == DreamState.nightmare)
            {
                Die();
            }
        }
        //Knockback?
        knockbackX = knockbackXMagn * direction;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, knockbackYMagn);
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 3);

    }
    /*
    void CheckPlayerCollision()
    {
        if (col.gameObject.tag == "CoinPickup")
        {
            coinScore++;
            Destroy(col.gameObject);
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

    void CheckPlayerCollision(Vector2 getVector)
    {
        RaycastHit2D player_hit = Physics2D.Raycast(transform.position, getVector);
        if (player_hit.collider != null)
        {
            if (player_hit.distance < 0.2f)
            {
                if (player_hit.collider.gameObject.tag == "CoinPickup")//"Ground")
                {

                    coinScore++;
                    Destroy(player_hit.collider.gameObject);
                }

            }
        }
    }
    */
}
