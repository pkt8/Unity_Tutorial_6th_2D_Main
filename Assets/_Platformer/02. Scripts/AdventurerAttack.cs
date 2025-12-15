using System;
using Platformer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class AdventurerAttack : MonoBehaviour, IDamageable
    {
        [HideInInspector] public InputType inputType;
        private SoundManager sound;
        private Animator anim;

        [SerializeField] private Slider hpSlider;
        [SerializeField] private TextMeshProUGUI hpText;
        [SerializeField] private Image hpBar;

        [SerializeField] private float hp = 10f;
        private float maxHp;
        [SerializeField] private float damage = 1f;

        private bool isAttack, isCombo, isFinal;

        void Start()
        {
            sound = FindFirstObjectByType<SoundManager>();

            anim = GetComponent<Animator>();

            maxHp = hp;
            hpSlider.value = hp / maxHp;
            hpText.text = $"{hp * 10} / {maxHp * 10}";
            hpBar.color = Color.green;
        }

        void Update()
        {
            if (inputType == InputType.Keyboard)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                    Attack();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var target = other.GetComponent<IDamageable>();
            if (target != null)
            {
                target.TakeDamage(damage);
                
                Debug.Log($"{gameObject.name}이 {other.name}에게 {damage}만큼의 데미지 적용");
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

        public void TakeDamage(float damage)
        {
            hp -= damage;
            hpSlider.value = hp / maxHp;
            hpText.text = $"{hp * 10} / {maxHp * 10}";

            if (hp < 7.5f && hp >= 2.5f)
                hpBar.color = Color.yellow;
            else if (hp < 2.5f)
                hpBar.color = Color.red;
            
            if (hp <= 0)
                Death();
        }

        public void Death()
        {
            Debug.Log($"{gameObject.name} 죽음");
        }
    }
}