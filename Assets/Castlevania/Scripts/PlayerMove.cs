using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 10;
    public float jumpSpeed = 3;

    public AudioSource tickSource;

    public AudioClip Attack;
    public AudioClip Hurt;
    public AudioClip Healing;

    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        if (Input.GetKey("d") || Input.GetKey("right")){
            pos.x += runSpeed * Time.deltaTime;
            spriteRenderer.flipX = false;
            animator.SetBool("Run1", true);

        }
        else if (Input.GetKey("a") || Input.GetKey("left")){
            pos.x -= runSpeed * Time.deltaTime;
            spriteRenderer.flipX = true;
            animator.SetBool("Run1", true);

        } else if (!Input.GetKey("d") || !Input.GetKey("right") || !Input.GetKey("a") || !Input.GetKey("left")){
            animator.SetBool("Run1", false);

        } 
        
        if (Input.GetKey("r")){
            animator.SetBool("Attack_R", true);
            tickSource.clip = Attack;
            tickSource.Play();
            
        }

        if (!Input.GetKey("r")){
            animator.SetBool("Attack_R", false);
        }
                
        transform.position = pos;

        if((Input.GetKey("w") || Input.GetKey("space")) && CheckGround.isGrounded){
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.SetBool("Run1", false);
            animator.SetBool("Jump", true);
        } else {
            animator.SetBool("Jump", false);
        
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if( other.gameObject.tag == "Object" )
     {
         Destroy(other.gameObject);
     }


       if( other.gameObject.tag == "Food" )
     {
         tickSource.clip = Healing;
         tickSource.Play();
     }

     if( other.gameObject.tag == "Enemie" )
     {
         tickSource.clip = Hurt;
         tickSource.Play();
     }
 
    }

}
