using System;
using UnityEngine;

public class AdventurerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;

    private float h, v;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 7f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Jump();
    }

    void FixedUpdate()
    {
        SetAnimation();
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("IsGround", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("IsGround", false);
        }
    }

    private void Move()
    {
        rb.linearVelocityX = h * moveSpeed;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("IsGround", false);

            anim.SetTrigger("Jump");
            rb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }
    
    private void SetAnimation()
    {
        if (h != 0)
            transform.localScale = new Vector3(h, 1, 1);
        
        // if (h < 0)
        //     transform.localScale = new Vector3(-1, 1, 1);
        // else if (h > 0)
        //     transform.localScale = new Vector3(1, 1, 1);
        //
        //
        // if (h != 0)
        // {
        //     float scaleX = h > 0 ? 1 : -1;
        //     transform.localScale = new Vector3(scaleX, 1, 1);
        // }

        if (v < 0) // Crouch 상태
        {
            coll.offset = new Vector2(coll.offset.x, 0.55f);
            coll.size = new Vector2(coll.size.x, 1.1f);
            moveSpeed = 1.5f;
        }
        else if (v >= 0) // Idle 상태
        {
            coll.offset = new Vector2(coll.offset.x, 0.8f);
            coll.size = new Vector2(coll.size.x, 1.6f);
            moveSpeed = 3f;
        }
        
        
        anim.SetFloat("AxisX", h);
        anim.SetFloat("AxisY", v);
    }
}