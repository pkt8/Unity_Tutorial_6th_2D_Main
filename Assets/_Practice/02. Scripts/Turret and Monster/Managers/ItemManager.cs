using System.Collections.Generic;
using Turret;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] dropItems;

    public List<GameObject> hasItems = new List<GameObject>();

    public void SpawnItem(Transform dropPoint)
    {
        int randomIndex = Random.Range(0, dropItems.Length); // 랜덤 아이템 인덱스 설정

        GameObject itemObj = Instantiate(dropItems[randomIndex], dropPoint.position, Quaternion.identity);
        Rigidbody itemRb = itemObj.GetComponent<Rigidbody>();

        // 아이템 생성시 랜덤 방향 기능
        Vector3 randomPower = new Vector3(Random.Range(-1f, 1f), 5f, Random.Range(-1f, 1f));
        itemRb.AddForce(randomPower, ForceMode.Impulse);

        // 아이템 생성시 랜덤 회전 기능
        Vector3 randomRotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        itemRb.AddTorque(randomRotation, ForceMode.Impulse);
    }

    public void AddInventory(IItem item)
    {
        hasItems.Add(item.Obj);
        Debug.Log($"{item.Name} 획득");
    }
}