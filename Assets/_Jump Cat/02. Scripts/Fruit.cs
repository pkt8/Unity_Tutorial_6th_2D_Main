using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject particleObj;
    
    void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++) // 모든 과일 오브젝트 끄기
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        int randomIndex = Random.Range(0, transform.childCount); // 랜덤값 설정
        
        transform.GetChild(randomIndex).gameObject.SetActive(true); // 특정 과일 오브젝트만 켜기
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            particleObj.SetActive(true);
            
            gameObject.SetActive(false);
        }
    }
}