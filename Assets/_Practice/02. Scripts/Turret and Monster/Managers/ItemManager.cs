using System.Collections.Generic;
using Turret;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] dropItems;

    public List<GameObject> hasItems = new List<GameObject>();

    public void SpawnItem(Transform dropPoint)
    {
        int randomIndex = Random.Range(0, dropItems.Length);

        GameObject itemObj = Instantiate(dropItems[randomIndex], dropPoint.position, Quaternion.identity);
        Rigidbody itemRb = itemObj.GetComponent<Rigidbody>();

        Vector3 randomPower = new Vector3(Random.Range(-1f, 2f), 5f, Random.Range(-1f, 2f));
        itemRb.AddForce(Vector3.up * 5f, ForceMode.Impulse);

        Vector3 randomRotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        itemRb.AddTorque(randomRotation, ForceMode.Impulse);
    }

    public void AddInventory(IItem item)
    {
        hasItems.Add(item.Obj);
        Debug.Log($"{item.Name} 획득");
    }
}