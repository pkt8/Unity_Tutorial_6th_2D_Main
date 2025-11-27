using UnityEngine;

public class StudyEncapsulation : MonoBehaviour
{
    public int number1; // 외부 클래스에서 접근 O, 유니티에서 접근 O
    
    private int number2; // 외부 클래스에서 접근 X, 유니티에서 접근 X -> 내부에서만 접근 O
    
    protected int number3; // 외부 클래스에서 접근 X, 유니티에서 접근 X -> 내부와 자식 클래스에서만 접근 O
    
    [HideInInspector] public int number4; // 외부 클래스에서 접근 O, 유니티에서 접근 X
    
    [SerializeField] private int number5; // 외부 클래스에서 접근 X, 유니티에서 접근 O
    
    [SerializeField] protected int number6; // 외부 클래스에서 접근 X, 유니티에서 접근 O -> 내부와 자식 클래스에서만 접근 O

    private int level = 1;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    private int level2 = 1;
    public int Level2
    {
        get => level2;
        set => level2 = value;
    }
    
    public int Level3 { get; set; } // 자동구현 프로퍼티
    public int Level4 { get; private set; }
    
    public int Level5 { private get; set; }
    
    // public int Level6 { private get; private set; } // 에러 -> private 변수로 대체
    private int level6;
    
    [field:SerializeField]
    public int Level7 { get; set; } // 유니티에서 접근 O, 외부 클래스에서 접근 O - 수정 O
    
    [field:SerializeField]
    public int Level8 { private get; set; } // 유니티에서 접근 O, 외부 클래스에서 접근 X - 수정 O
    
    [field:SerializeField]
    public int Level9 { get; private set; } // 유니티에서 접근 O, 외부 클래스에서 접근 O - 수정 X

    void Start()
    {
        Level4 = 10;
        Level5 = 10;
    }
    
    
}