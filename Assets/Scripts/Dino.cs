using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public enum State { Stand, Run, Jump, Hit };
    public float startJumpPower;
    public float jumpPower;
    public bool isGround;
    public bool isJumpKey;

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
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);
        }
        isJumpKey = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {
        if (isJumpKey && !isGround)
        {
            jumpPower = Mathf.Lerp(jumpPower, 0, 0.1f);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void ChangingAnim(State state)
    {
        anim.SetInteger("State", (int)state);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGround)
        {
            ChangingAnim(State.Run);
            jumpPower = 1;
        }

        isGround = true;        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ChangingAnim(State.Jump);
        isGround = false;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rigid.simulated = false;
        ChangingAnim(State.Hit);
    }
}
