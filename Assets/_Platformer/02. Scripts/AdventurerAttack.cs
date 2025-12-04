using Platformer;
using UnityEngine;

public class AdventurerAttack : MonoBehaviour
{
    public enum InputType { Keyboard, Joystick }
    public InputType inputType;

    private SoundManager sound;

    private Animator anim;

    private bool isAttack, isCombo, isFinal;

    void Start()
    {
        sound = FindFirstObjectByType<SoundManager>();
        
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (inputType == InputType.Keyboard)
        {
            if (Input.GetKeyDown(KeyCode.Z))
                Attack();
        }
    }

    public void Attack()
    {
        if (!isAttack) // 처음 공격키를 눌렀을 때
        {
            isAttack = true;
            anim.SetTrigger("Attack");
        }
        else // 공격키를 추가로 눌렀을 때
        {
            if (!isCombo)
                isCombo = true;
            else
                isFinal = true;
        }
    }
    
    public void CheckCombo()
    {
        int currentCombo = anim.GetInteger("Combo"); // 현재 Combo라는 파라미터의 값을 가져오는 기능

        if (isCombo && currentCombo == 0)
            anim.SetInteger("Combo", 1);
        else if (isFinal && currentCombo == 1)
            anim.SetInteger("Combo", 2);
        else
            ClearCombo();
    }

    public void ClearCombo()
    {
        isAttack = false;
        isCombo = false;
        isFinal = false;
        anim.SetInteger("Combo", 0);
    }

    public void AttackSound(string clipName)
    {
        sound.SoundOneShot(clipName);
    }
}