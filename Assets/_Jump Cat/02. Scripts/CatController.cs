using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody2D catRb;
    private Animator catAnim;
    
    public float jumpPower = 10f;
    public float limitVelocity = 5f;
    public int jumpCount;
    public float rotPower = 3f;
    
    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            jumpCount = 0;
            catAnim.SetBool("IsGround", true);
        }
        else if (other.collider.CompareTag("Pipe"))
        {
            Debug.Log("Game Over");
            // Time.timeScale = 0f;
        }
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 3)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("IsGround", false);
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;

            if (catRb.linearVelocityY > limitVelocity)
            {
                catRb.linearVelocityY = limitVelocity;
            }
        }
        
        Vector3 catRotation = transform.eulerAngles; // 현재 회전값 가져오기
        catRotation.z = catRb.linearVelocityY * rotPower; // 회전값 수정
        
        transform.eulerAngles = catRotation; // 수정된 회전값을 다시 적용
    }
}