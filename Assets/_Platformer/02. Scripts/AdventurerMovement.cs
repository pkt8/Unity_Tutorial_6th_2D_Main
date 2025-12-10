using System;
using Platformer;
using UnityEngine;

public class AdventurerMovement : MonoBehaviour, IMovement
{
    [field:SerializeField]
    public InputType inputType { get; set; }

    private SoundManager sound;
    
    private Animator anim;
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;

    private float h, v;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 7f;
    
    void Start()
    {
        sound = FindFirstObjectByType<SoundManager>();
        
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (inputType == InputType.Keyboard)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
        }
        
        if (Input.GetButtonDown("Jump"))
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
            sound.SoundOneShot("Footstep Grass");
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
    
    public void InputJoystick(float h, float v)
    {
        if (inputType == InputType.Joystick)
        {
            this.h = h;
            this.v = v;
        }
    }

    public void Move()
    {
        rb.linearVelocityX = h * moveSpeed;
    }

    public void Jump()
    {
        if (anim.GetBool("IsGround"))
        {
            sound.SoundOneShot("Attack1");
            
            anim.SetBool("IsGround", false);

            anim.SetTrigger("Jump");
            rb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }
    
    public void SetAnimation()
    {
        if (h != 0)
        {
            float scaleX = 0f;
            if (h > 0)
                scaleX = 1;
            else if (h < 0)
                scaleX = -1;
            
            // float scaleX = h > 0 ? 1 : -1;
            
            transform.localScale = new Vector3(scaleX, 1, 1);
        }

        if (v < -0.45f) // Crouch 상태
        {
            coll.offset = new Vector2(coll.offset.x, 0.55f);
            coll.size = new Vector2(coll.size.x, 1.1f);
            moveSpeed = 1f;
        }
        else if (v >= -0.45f) // Idle 상태
        {
            coll.offset = new Vector2(coll.offset.x, 0.8f);
            coll.size = new Vector2(coll.size.x, 1.6f);
            moveSpeed = 3f;
        }
        
        anim.SetFloat("AxisX", h);
        anim.SetFloat("AxisY", v);
    }

    public void FootStep()
    {
        sound.SoundOneShot("Footstep Field");
    }
}