using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rigid;
    Animator anim;
    float h;
    float v;

    bool isHorizonMove;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
{
    h = Input.GetAxisRaw("Horizontal");
    v = Input.GetAxisRaw("Vertical");

    bool hDown = Input.GetButtonDown("Horizontal");
    bool vDown = Input.GetButtonDown("Vertical");
    bool hUp = Input.GetButtonUp("Horizontal");
    bool vUp = Input.GetButtonUp("Vertical");

    // 기본 방향을 수직 이동으로 설정
    if (vDown)
    {
        isHorizonMove = false; // 수직 이동이 우선
    }
    else if (hDown)
    {
        isHorizonMove = true; // 수평 이동이 우선
    }
    else if (hUp || vUp)
    {
        isHorizonMove = h != 0;
    }

    // ✅ 우선 수직 방향을 먼저 처리하고, 수평 방향을 나중에 처리
    if (anim.GetInteger("vAxisRaw") != v)
    {
        anim.SetBool("isChange", true);
        anim.SetInteger("vAxisRaw", (int)v);
    }
    else if (anim.GetInteger("hAxisRaw") != h)
    {
        anim.SetBool("isChange", true);
        anim.SetInteger("hAxisRaw", (int)h);
    }
    else
    {
        anim.SetBool("isChange", false);
    }
}


    void FixedUpdate()
    {

        Vector2 moveVec = isHorizonMove ? new Vector2(h,0) : new Vector2(0,v);
        rigid.velocity = moveVec * Speed;

    
    }
}
