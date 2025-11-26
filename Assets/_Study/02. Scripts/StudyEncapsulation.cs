using UnityEngine;

public class StudyEncapsulation : MonoBehaviour
{
    // public int number1; // 외부 클래스에서 접근 O, 유니티에서 접근 O
    //
    // private int number2; // 외부 클래스에서 접근 X, 유니티에서 접근 X -> 내부에서만 접근 O
    //
    // protected int number3;  // 외부 클래스에서 접근 X, 유니티에서 접근 X -> 내부와 자식 클래스에서만 접근 O
    //
    // [HideInInspector] public int number4; // 외부 클래스에서 접근 O, 유니티에서 접근 X
    //
    // [SerializeField] private int number5; // 외부 클래스에서 접근 X, 유니티에서 접근 O
    //
    // [SerializeField] protected int number6; // 외부 클래스에서 접근 X, 유니티에서 접근 O

    private int level;
    public int Level
    {
        get // 데이터를 가져가는 기능
        {
            return level;
        }
    }
}