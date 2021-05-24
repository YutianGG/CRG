using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [Header("移動速度"), Range(0, 100)]
    public float speed = 1;
    [Header("跳躍高度"), Range(0, 100000)]
    public float jump = 50000;
    [Header("生命數量"), Range(1, 3)]
    public int live = 3;
    [Header("是否站在地板"), Tooltip("儲存玩家是否在地面")]
    public bool isGround;
    [Header("跳躍聲音")]
    public AudioSource jumpaud;
    [Header("死亡聲音")]
    public AudioSource deadaud;

    private int score;
    private Rigidbody2D rig;
    private AudioSource aud;
    private Animator ani;

    

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        float h = Input.GetAxis("Horizontal"); //水平
        rig.velocity = new Vector2(h * speed, rig.velocity.y); 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            Destroy(collision.gameObject,1f);
        }
        if (Input.GetButtonDown("Jump"))
        {
            rig.velocity = new Vector2(rig.velocity.x, jump * Time.deltaTime);  
        }
    }

}
