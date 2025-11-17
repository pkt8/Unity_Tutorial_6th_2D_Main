using UnityEngine;

public class Pipe : MonoBehaviour
{
    public enum ItemType { None, Pipe, Fruit, All }
    public ItemType itemType;

    private GameObject pipeObj;
    private GameObject fruitObj;
    private GameObject particleObj;
    
    public float moveSpeed = 1f;
    private float randomPosY;

    void Start()
    {
        pipeObj = transform.GetChild(0).gameObject;
        fruitObj = transform.GetChild(1).gameObject;
        particleObj = transform.GetChild(2).gameObject;

        SetType();
        transform.position = new Vector3(transform.position.x, randomPosY, 0);
    }
    
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -10f)
        {
            SetType();
            transform.position = new Vector3(10f, randomPosY, 0);
        }
    }
    
    private void SetType()
    {
        randomPosY = Random.Range(-6.5f, -2.5f);
        
        int randomIndex = Random.Range(0, 4); // 0, 1, 2, 3

        fruitObj.SetActive(false); // 미리 Off하는 기능
        particleObj.SetActive(false);
        
        itemType = (ItemType)randomIndex; // 형변환(Type Casting) : 데이터 타입을 변경하는 방법
        switch (itemType)
        {
            case ItemType.None:
                pipeObj.SetActive(false);
                fruitObj.SetActive(false);
                break;
            case ItemType.Pipe:
                pipeObj.SetActive(true);
                fruitObj.SetActive(false);
                break;
            case ItemType.Fruit:
                pipeObj.SetActive(false);
                fruitObj.SetActive(true);
                break;
            case ItemType.All:
                pipeObj.SetActive(true);
                fruitObj.SetActive(true);
                break;
        }
    }
}