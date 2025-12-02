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
        
        anim.SetFloat("AxisX", h);
        anim.SetFloat("AxisY", v);
    }
}