using UnityEngine;

public class StreetLight : MonoBehaviour
{
    public Transform targetLight;

    public GameObject[] streetLightLamps;

    void Start()
    {
        foreach (var light in streetLightLamps)
        {
            light.SetActive(false);
        }
    }

    void Update()
    {
        if (targetLight.eulerAngles.x >= 0f && targetLight.eulerAngles.x <= 180f)
        {
            foreach (var light in streetLightLamps)
            {
                light.SetActive(false);
            }
        }
        else
        {
            foreach (var light in streetLightLamps)
            {
                light.SetActive(true);
            }
        }
    }
}