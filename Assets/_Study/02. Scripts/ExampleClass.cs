using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    public StudyCoroutine fade;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fade.OnFade(3f, 3f, Color.white);
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            fade.OnFade(3f, 3f, Color.black);
        }
    }
}