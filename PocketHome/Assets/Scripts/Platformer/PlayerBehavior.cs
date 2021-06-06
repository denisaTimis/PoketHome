using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject text;
    [SerializeField]
    int index;
    Text txt;
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
    [SerializeField]
    Vector2 respawn;

    // Start is called before the first frame update
    void Start()
    {
        this.txt = text.GetComponent<Text>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Coin"))
        {
            int value = Int32.Parse(txt.text);
            value = value + 10;
            txt.text = value.ToString();
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.name.Contains("LevelFinish"))
        {
            SceneManager.LoadScene(index);
        }
        else if(collision.gameObject.name.Contains("Death"))
        {
            this.transform.position = new Vector3(respawn.x, respawn.y, this.transform.position.z);
        }
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
