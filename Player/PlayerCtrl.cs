using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;
    private GameObject ground0;
    private GameObject ground1;
    static public PlayerCtrl instance;
    private float thrust = 10f;
    private float getHori = 0f;
    private float jumpHeight = 7f;
    private bool inJumpAction = false;
    private bool triggerToggled = false;//flag
    private bool bnDown;

    private void Awake()
    {
        PlayerCtrl.instance = this;
        this.ground0 = GameObject.Find("Ground0");
        this.ground1 = GameObject.Find("Ground1");
        this.rb2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    private void Update()
    {
        this.getHori = InputManager.instance.horizontal;
        this.bnDown = InputManager.instance.bnDown;
        this.Move();
        this.Jump();
        this.CheckJumpHeightToIsTrigger();

    }

    protected void Move()
    {
        // Move forward
        if (getHori > 0)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 1);
            this.rb2D.AddForce(new Vector2(this.thrust, 0));
        }
        // Move back
        else if (getHori < 0)
        {
            transform.localScale = new Vector3(-0.25f, 0.25f, 1);
            this.rb2D.AddForce(new Vector2(-this.thrust, 0));
        }
        // Set Moving Animator
        this.animator.SetFloat("Moving", Mathf.Abs(this.getHori));
    }

    protected void Jump()
    {
        if (InputManager.instance.jump == false) return;
        if (this.inJumpAction == true) return;
        this.rb2D.gravityScale = 15f;
        float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb2D.gravityScale));
        rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        this.inJumpAction = true;
        this.triggerToggled = false;
    }

    // Check Player isGround and set isJump
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //touch Ground0
        if (collision.gameObject.CompareTag("Ground0"))
        {
            this.inJumpAction = false;
            InputManager.instance.jump = false;
            this.rb2D.gravityScale = 1;

            this.ground1.GetComponent<Collider2D>().isTrigger = true;
        }

        //touch Ground1
        if (collision.gameObject.CompareTag("Ground1"))
        {
            this.inJumpAction = false;
            InputManager.instance.jump = false;
            this.rb2D.gravityScale = 1;
        }
        
        //touch Enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.inJumpAction = false;
            InputManager.instance.jump = false;
            this.rb2D.gravityScale = 1;
        }
    }

    protected void CheckJumpHeightToIsTrigger()
    {
        if (!triggerToggled && transform.position.y >= -2f)
        {
            this.ground1.GetComponent<Collider2D>().isTrigger = false;
            this.triggerToggled = true;
        }

        //button down to fall
        if (bnDown == true && this.transform.position.y > ground1.transform.position.y)
        {
            this.ground1.GetComponent<Collider2D>().isTrigger = true;
            this.rb2D.gravityScale = 15;
            InputManager.instance.bnDown = false;
        }
    }
}
