using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    private Rigidbody2D rgb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    public float speed;
    [SerializeField]
    public float jumpForce;
    private bool flip;
    private bool jumping;
    private bool falling;

    // Start is called before the first frame update
    void Start()
    {
        this.rgb = this.GetComponent<Rigidbody2D>();
        this.anim = this.GetComponent<Animator>();
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        flip = false;
        jumping = false;
        falling = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        bool keyDown = Input.GetKeyDown(KeyCode.Space);
        HandleMovement(horizontalInput, keyDown);
    }

    void HandleMovement(float horizontalInput, bool keyDown)
    {
        if(horizontalInput != 0)
        {
            rgb.velocity = new Vector2(horizontalInput * speed, rgb.velocity.y);
            anim.SetBool("isRunning", true);
            if(horizontalInput < 0 && !flip)
            {
                spriteRenderer.flipX = true;
                flip = true;
            }
            if(horizontalInput > 0 && flip)
            {
                spriteRenderer.flipX = false;
                flip = false;
            }
            
        }
        else
        {
            rgb.velocity = new Vector2(0, rgb.velocity.y);
            anim.SetBool("isRunning", false);
        }
        if(keyDown && !jumping)
        {
            jumping = true;
            rgb.AddForce(new Vector2(rgb.velocity.x, jumpForce));
            anim.SetTrigger("jump");
        }
        if(rgb.velocity.y < 0 && !falling && jumping)
        {
            falling = true;
            anim.SetTrigger("fall");
        }
        if(rgb.velocity.y == 0 && falling)
        {
            falling = false;
            jumping = false;
            anim.SetTrigger("land");
        }
    }
}
