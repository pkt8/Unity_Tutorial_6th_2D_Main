using UnityEngine;

public class AdventurerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    private float h, v;

    [SerializeField] private float moveSpeed = 3f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        SetAnimation();
        Move();
    }

    private void Move()
    {
        rb.linearVelocityX = h * moveSpeed;
    }

    private void SetAnimation()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        // if (h < 0)
        //     renderer.flipX = true;
        // else if (h > 0)
        //     renderer.flipX = false;

        if (h != 0)
            renderer.flipX = h < 0;

        anim.SetFloat("AxisX", h);
        anim.SetFloat("AxisY", v);
    }
}