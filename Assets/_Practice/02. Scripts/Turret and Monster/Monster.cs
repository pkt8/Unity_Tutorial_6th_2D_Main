using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    private CapsuleCollider coll;

    [SerializeField] protected float hp;
    [SerializeField] protected float moveSpeed;

    private bool isMove = true;

    void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        if (!isMove)
            return;

        rb.linearVelocity = Vector3.right * moveSpeed;
    }

    public void GetDamage(float damage)
    {
        StartCoroutine(HitRoutine(damage));
    }

    IEnumerator HitRoutine(float damage)
    {
        hp -= damage;
        anim.SetTrigger("Damage");
        isMove = false;

        if (hp <= 0)
        {
            anim.SetTrigger("Dead");
            isMove = false;
            coll.enabled = false;
            rb.isKinematic = true;

            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
        }
        else // h > 0
        {
            yield return new WaitForSeconds(0.5f);
            isMove = true;
        }
    }
}