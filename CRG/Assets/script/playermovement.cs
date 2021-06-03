using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour

{
    [Header("跳躍聲音")]
    public AudioSource jumpaud;
    [Header("死亡聲音")]
    public AudioSource deadaud;
    private Rigidbody2D rig;
    private Collider2D coll;
    private Animator anim;

    private int score;
    private AudioSource aud;
    public float speed,jumpForce;
    public Transform groundChenck;
    public LayerMask ground;

    public bool isGround, isJump;

    bool jumpPressed;
    int jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }
    }
    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundChenck.position, 0.1f, ground);

        GroundMovement();
        SwitchAnim();
        Jump();
    }
    private void GroundMovement()
    {
        float horizontalMove = 1;
        rig.velocity = new Vector2(horizontalMove * speed, rig.velocity.y);

        if (horizontalMove != 0)
        {
            transform.localScale = new  Vector3(horizontalMove, 1, 1);
        }
    }
    private void Jump()
    {
        if (isGround)
        {
            jumpCount = 2;
            isJump = false;
        }
        if (jumpPressed && isGround)
        {
            isJump = true;
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed && jumpCount > 0 && isJump )
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
    }
    private void SwitchAnim()
    {
        anim.SetBool("run", true);
        if (isGround)
        {
            anim.SetBool("fall", false);
        }
        else if (!isGround && rig.velocity.y > 0)
        {
            anim.SetBool("jump", true);
        }
        else if (rig.velocity.y < 0)
        {
            anim.SetBool("jump", false);
            anim.SetBool("fall", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            Destroy(collision.gameObject, 0.5f);
        }
    }
}
