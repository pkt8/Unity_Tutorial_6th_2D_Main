using System;
using UnityEngine;

public class AmongusController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;

    private Vector3 dir;
    
    public float moveSpeed = 5f;
    public float turnSpeed = 5f;
    public float jumpPower = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        dir = new Vector3(h, 0, v).normalized;

        if (h != 0 || v != 0) // 입력이 있을 때
            anim.SetBool("IsWalk", true); // 걷는 애니메이션 실행
        else // 입력이 없을 때
            anim.SetBool("IsWalk", false); // 걷는 애니메이션 종료

        // bool isMove = h != 0 || v != 0;
        // anim.SetBool("IsWalk", isMove);
        
        Jump();
    }

    void FixedUpdate()
    {
        Move();
        Turn();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) // 바닥에 닿은 순간
        {
            anim.SetBool("IsGround", true);
        }
    }
    
    public void Move()
    {
        Vector3 targetPosition = rb.position + dir * moveSpeed;
        
        rb.MovePosition(targetPosition);
    }
    
    public void Turn()
    {
        if (dir.x == 0 && dir.z == 0)
            return;
        
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        Quaternion newRotation = Quaternion.Slerp(rb.rotation, targetRotation, turnSpeed);
        
        rb.MoveRotation(newRotation);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("IsGround", false);
            
            anim.SetTrigger("Jump"); // 점프 애니메이션 실행
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}