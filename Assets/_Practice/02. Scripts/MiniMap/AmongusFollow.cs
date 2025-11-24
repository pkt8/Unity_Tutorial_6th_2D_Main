using UnityEngine;

public class AmongusFollow : MonoBehaviour
{
    public Transform followTarget;

    public Vector3 offset;
    
    void LateUpdate()
    {
        transform.position = followTarget.position + offset;
    }
}