using UnityEngine;

public class Ball : MonoBehaviour
{
    private PinballController controller; // 점수가 있는 클래스
    
    private Rigidbody2D ballRb;
    
    private Vector3 startPosition; // 처음 위치
    
    void Start()
    {
        controller = FindFirstObjectByType<PinballController>();
        ballRb = GetComponent<Rigidbody2D>();
        
        startPosition = transform.position;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Point10":
                controller.SetScore(10);
                break;
            case "Point30":
                controller.SetScore(30);
                break;
            case "Point50":
                controller.SetScore(50);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("게임 종료 : " + controller.GetScore());

        controller.ResetScore();
        
        Invoke("ReStart", 3f);
    }

    private void ReStart()
    {
        Debug.Log("ReStart");
        
        ballRb.linearVelocity = Vector2.zero;
        ballRb.angularVelocity = 0;
        
        transform.position = startPosition;
    }
}