using UnityEngine;

public class StudyClass // 참조 타입 -> 어떠한 주소를 가리키는 방식
{
    public int number;

    public StudyClass(int number)
    {
        this.number = number;
    }
}

public struct StudyStruct // 값 타입 -> 자기 자신에게 값이 있는 방식
{
    public int number;

    public StudyStruct(int number)
    {
        this.number = number;
    }
}

public class StudyClassStruct : MonoBehaviour
{
    void Start()
    {
        Debug.Log("클래스의 얕은 복사---------------------");
        StudyClass c1 = new StudyClass(10);
        StudyClass c2 = c1;

        Debug.Log($"c1 : {c1.number} / c2 : {c2.number}");
        
        c1.number = 100;
        Debug.Log($"c1 : {c1.number} / c2 : {c2.number}");
        
        Debug.Log("클래스의 깊은 복사---------------------");
        StudyClass c3 = new StudyClass(10);
        StudyClass c4 = new StudyClass(c3.number);

        Debug.Log($"c3 : {c3.number} / c2 : {c4.number}");
        
        c3.number = 100;
        Debug.Log($"c3 : {c3.number} / c2 : {c4.number}");
        
        Debug.Log("구조체---------------------");
        StudyStruct s1 = new StudyStruct(10);
        StudyStruct s2 = s1;
        
        Debug.Log($"s1 : {s1.number} / s2 : {s2.number}");
        
        s1.number = 100;
        Debug.Log($"s1 : {s1.number} / s2 : {s2.number}");
    }
}