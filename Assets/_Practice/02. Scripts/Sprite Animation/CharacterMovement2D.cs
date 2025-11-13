using UnityEngine;

public class CharacterMovement2D : MonoBehaviour
{
    private Rigidbody2D characterRb;
    public SpriteRenderer[] renderers;
    
    public float moveSpeed = 5f;
    private float h;

    void Start()
    {
        characterRb = GetComponent<Rigidbody2D>();
        renderers = GetComponentsInChildren<SpriteRenderer>(); // 자신을 포함한 SpriteRenderer 컴포넌트가 있는 오브젝트를 모두 가져오는 기능
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal"); // A, D 키보드에 대한 입력값

        // if (h == 0) // 키를 누르지 않았을 때
        // {
        //     renderers[0].gameObject.SetActive(true);
        //     renderers[1].gameObject.SetActive(false);
        // }
        // else // 키를 눌렀을 때
        // {
        //     renderers[0].gameObject.SetActive(false);
        //     renderers[1].gameObject.SetActive(true);
        // }

        renderers[0].gameObject.SetActive(h == 0);
        renderers[1].gameObject.SetActive(h != 0);

        // if (h < 0) // 왼쪽 바라보는 상태
        // {
        //     renderers[0].flipX = true;
        //     renderers[1].flipX = true;
        // }
        // else if (h > 0)
        // {
        //     renderers[0].flipX = false;
        //     renderers[1].flipX = false;
        // }

        if (h != 0)
        {
            renderers[0].flipX = h < 0;
            renderers[1].flipX = h < 0;
        }
    }

    void FixedUpdate()
    {
        characterRb.linearVelocityX = h * moveSpeed; // x축으로 속도를 변경하는 기능
    }
}