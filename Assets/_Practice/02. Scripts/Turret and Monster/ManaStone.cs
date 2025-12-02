using Turret;
using UnityEngine;

public class ManaStone : MonoBehaviour, IItem
{
    private ItemManager itemManager;
    public GameObject Obj { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }

    void Start()
    {
        itemManager = FindFirstObjectByType<ItemManager>();
        
        Obj = gameObject;
        Name = gameObject.name;
        Price = 5;
    }
    
    void OnMouseDown()
    {
        Get();
    }
    
    public void Get()
    {
        itemManager.AddInventory(this);
        gameObject.SetActive(false);
    }

    public void Use()
    {
        Debug.Log("Mp 회복");
    }
}