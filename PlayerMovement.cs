using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    
    [SerializeField] private LayerMask jumpableGround;
    private float dirX = 0f;
    // can also use public, but makes variables accessible by other scripts
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling, crouching  }


    [SerializeField] private AudioSource jumpSoundEffect;
    
    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    private void Update() {
        
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown("up")) && IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }


        updateAnimationState();

        
    }

    private void updateAnimationState() {

        MovementState state;
        // moving right (forwards)
        if (dirX > 0f) {
            state = MovementState.running;
            sprite.flipX = false;
        }
        // moving left (backwards)
        else if (dirX < 0f) {
            state = MovementState.running;
            sprite.flipX = true;
        }
        // standing still
        else {
            state = MovementState.idle;
        }

        // jumping

        if (rb.velocity.y > .1f) {
            state = MovementState.jumping;
        } 
        else if (rb.velocity.y < -.1f) {
            state = MovementState.falling;

        }
        
        anim.SetInteger("state", (int) state);
    }

    private bool IsGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
