using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [Header("移動速度"), Range(0, 100)]
    public float speed = 1;
    [Header("跳躍高度"), Range(0, 10)]
    public float jump = 2;
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
        
    }
    private void Move()
    {
        float h = Input.GetAxis("Horizonatal");
        rig.velocity = new Vector2(h * speed, rig.velocity.y);
    }
    private void Jump()
    {
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        { 
            
        }
    }
}
