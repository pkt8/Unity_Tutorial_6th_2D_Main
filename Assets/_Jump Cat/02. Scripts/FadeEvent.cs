using UnityEngine;

public class FadeEvent : MonoBehaviour
{
    public GameObject playObj;
    public GameObject outroUI;
    
    public void OutroUISetOn()
    {
        playObj.SetActive(false);
        outroUI.SetActive(true);
    }
}