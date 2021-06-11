using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour

{
    [Header("跳躍聲音")]
    public AudioSource jumpaud;
    [Header("死亡聲音")]
    public AudioSource deadaud;
    [Header("分數")]
    public int score;
    public float speed,jumpForce;   //移動及跳躍參數
    public Transform groundChenck;  //偵測物
    public LayerMask ground;        //偵測物
    public bool isGround, isJump;   //狀態判斷

    private Rigidbody2D rig;
    private Collider2D coll;
    private Animator anim;
    private AudioSource aud;
    private bool jumpPressed;
    private int jumpCount;


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
        isGround = Physics2D.OverlapCircle(groundChenck.position, 0.1f, ground);    //在地面上

        GroundMovement();
        SwitchAnim();
        Jump();
    }
    /// <summary>
    /// 移動
    /// </summary>
    private void GroundMovement()
    {
        float horizontalMove = 1;   //水平移動
        rig.velocity = new Vector2(horizontalMove * speed, rig.velocity.y); //水平加速度

        if (horizontalMove != 0)    //如果水平移動不等於0
        {
            transform.localScale = new  Vector3(horizontalMove, 1, 1);  //判斷方向面向
        }
    }
    /// <summary>
    /// 跳躍及判斷
    /// </summary>
    private void Jump()
    {
        if (isGround)   //如果在地面
        {
            jumpCount = 2;  //可連跳躍次數
            isJump = false; //跳躍動畫 = false
        }
        if (jumpPressed && isGround)    //如果按下跳躍鍵且在地面上
        {
            isJump = true;  //跳躍動畫 = true
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);  //跳躍參數
            jumpCount--;    //跳躍次數-1
            jumpPressed = false;    //確保if迴圈執行完
        }
        else if (jumpPressed && jumpCount > 0 && isJump )   //如果按下跳躍鍵&&跳躍次數大於0&&跳躍動畫執行
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);  //跳躍參數
            jumpCount--;    //跳躍次數-1
            jumpPressed = false;    //確保完成else if迴圈
        }
    }
    /// <summary>
    /// 動畫判斷
    /// </summary>
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
            anim.SetBool("fall", false);
        }
        else if (rig.velocity.y < 0)
        {
            anim.SetBool("jump", false);
            anim.SetBool("fall", true);
        }
    }
    /// <summary>
    /// 地面物件刪除(碰到物件)
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)   
    {
        if (collision.gameObject.tag == "floor")    //完加觸碰到的圖層為floor
        {
            Destroy(collision.gameObject, 0.5f);    //消除所碰到之物件.5秒鐘刪除
        }
    }
}
