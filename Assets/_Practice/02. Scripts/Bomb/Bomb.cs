using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Collider[] colliders;
    public LayerMask layerMask;

    public GameObject particleObj;
    public GameObject particleObj2;

    public float bombPower = 500f;
    public float bombRange = 100f;
    public float bombHeight = 10f;
    
    void Start()
    {
        Invoke(nameof(Explosion), 7f);
        Invoke(nameof(PlayParticle), 6.2f);
        Invoke(nameof(PlayParticle2), 2.2f);
    }

    private void Explosion()
    {
        colliders = Physics.OverlapSphere(transform.position, 10f, layerMask);

        foreach (var coll in colliders)
        {
            coll.GetComponent<Rigidbody>().AddExplosionForce(bombPower, transform.position, bombRange, bombHeight);
        }

        // Destroy(gameObject);

        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
    }

    private void PlayParticle()
    {
        particleObj.SetActive(true);
    }
    
    private void PlayParticle2()
    {
        particleObj2.SetActive(true);
    }
}