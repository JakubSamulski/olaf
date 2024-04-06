using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private GameObject player;
    private Health health;
    private Rigidbody2D body;

    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    public CoinManager cm;
   

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        health = GetComponent<Health>();
    }

    private void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");

        //flip the character
        if(horizontalInput > 0.01f) 
        {
            transform.localScale = new Vector3(7, 7, 7);
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-7, 7, 7);
        }

        


        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("Grounded", isGrounded());
        
        if(wallJumpCooldown > 0.2f)
        {
           
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if(onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 2.5f;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                jump();
            }

        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }

    }

    private void jump()
    {
       if(isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("Jump");
        }
       else if(onWall() && !isGrounded())
        {

            if(horizontalInput==0)
            {
                body.velocity = new Vector2(-transform.localScale.x * 10, 0);
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                body.velocity = new Vector2(-transform.localScale.x * 3, 6);
            }

            wallJumpCooldown = 0;
            body.velocity = new Vector2(-transform.localScale.x*3 , 6);
        }

        anim.SetTrigger("Jump");

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("coin"))
       {
            Destroy(other.gameObject);
            cm.coinCount++;
       }
       if(other.gameObject.CompareTag("void"))
        {
            health.TakeDamage(1);
            player.transform.position = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }


    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,0,Vector2.down,0.1f,groundLayer);
        return hit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallLayer); ;
        return hit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput== 0 && isGrounded() && !onWall();
    }
}
