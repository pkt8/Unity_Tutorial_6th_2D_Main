using System;
using OOP;
using UnityEngine;

public class AmongusController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;

    private Vector3 dir;
    
    public float moveSpeed = 5f;
    public float turnSpeed = 5f;
    public float jumpPower = 10f;

    public bool isRide = false;

    public Transform grabItemPoint;
    public IItem currentItem; // 현재 장착중인 아이템
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isRide) // 무엇인가 탑승했다면 리턴
            return;
        
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
        
        // 아이템 상호작용
        if (currentItem != null) // 현재 아이템 장착 확인
        {
            // 아이템 사용
            if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
            {
                currentItem.Use();
            }

            // 아이템 버리기
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                currentItem.Release();

                currentItem.itemTransform.localPosition += Vector3.back;
                currentItem.itemTransform.SetParent(null);
                currentItem = null;
            }
        }
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

    private void OnTriggerEnter(Collider other)
    {
        // 탑승 가능한 오브젝트 기능
        if (other.GetComponent<IMove>() != null) 
        {
            // IMove가 있을 경우
            IMove mover = other.GetComponent<IMove>();

            isRide = true;
            mover.IsRide = true; // 캐릭터가 other에게 탑승한 상태

            transform.SetParent(other.transform); // other의 자식으로 계층구조 변경
            transform.localPosition = Vector3.zero;
        }
        
        // 장착 가능한 아이템 기능
        if (other.GetComponent<IItem>() != null)
        {
            IItem item = other.GetComponent<IItem>();
            
            currentItem = item;
            currentItem.itemTransform.SetParent(grabItemPoint);
            currentItem.itemTransform.localPosition = Vector3.zero;
            currentItem.itemTransform.localRotation = Quaternion.identity;
            
            currentItem.Grab(); // 아이템을 장착했을 때 이벤트
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