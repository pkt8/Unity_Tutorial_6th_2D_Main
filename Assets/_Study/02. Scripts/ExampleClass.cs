using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    public StudyEncapsulation studyCapsule;

    void Start()
    {
        // studyCapsule.Level = 99;
    }
    
    public void ViewLevel()
    {
        int level = studyCapsule.Level;
        
        Debug.Log("현재 레벨은 : " + level);
    }
}