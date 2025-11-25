using System;
using System.Collections.Generic;
using UnityEngine;

public class Factory<T>
{
    private T prefab;

    public Factory(T prefab)
    {
        this.prefab = prefab;
    }
}

public class StudyCasting : MonoBehaviour
{
    public GameObject prefabObj;
    public Transform prefabPoint;
    
    void Start()
    {
        Factory<GameObject> factory1 = new Factory<GameObject>(prefabObj);
        
        Factory<Transform> factory2 = new Factory<Transform>(prefabPoint);
    }
}