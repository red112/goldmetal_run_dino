using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public enum State { Stand, Run, Jump, Hit };
    public float startJumpPower;
    public float jumpPower;
    public bool isGround;

    Rigidbody2D rigid;
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")) {
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);
        }
        
    }
}
