using UnityEngine;

public class FlowTime : MonoBehaviour
{
    public Transform light;
    
    public float rotSpeed = 10f;
    
    void Update()
    {
        light.Rotate(Vector3.right * rotSpeed * Time.deltaTime);
    }
}