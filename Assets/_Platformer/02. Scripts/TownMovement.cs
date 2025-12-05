using Platformer;
using UnityEngine;

public class TownMovement : MonoBehaviour
{
    public InputType inputType;

    private SoundManager sound;
    
    private Animator anim;
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;

    private float h, v;

    [SerializeField] private float moveSpeed = 3f;
    
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
    }

    void FixedUpdate()
    {
        SetAnimation();
        Move();
    }
    
    public void InputJoystick(float h, float v)
    {
        if (inputType == InputType.Joystick)
        {
            this.h = h;
            this.v = v;
        }
    }
    
    private void Move()
    {
        Vector2 dir = new Vector2(h, v);
        rb.linearVelocity = dir * moveSpeed;
    }
    
    private void SetAnimation()
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

        anim.SetFloat("AxisX", h);
        anim.SetFloat("AxisY", v);
    }
    
    public void FootStep()
    {
        sound.SoundOneShot("Footstep Field");
    }
}