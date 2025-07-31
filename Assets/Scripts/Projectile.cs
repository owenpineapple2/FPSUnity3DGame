using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    [SerializeReference] protected float lifetimeDuration;
    float timer;
    [SerializeField] int damage;
    public string abilityName;
    public float force;
    public float cooldown;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= lifetimeDuration)
        {
            Destroy(gameObject);
        }

    }
    protected void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("Player"))
        {
            if (collision.transform.TryGetComponent<Health>(out Health health))
            {
                health.TakeDamage(damage);
            }


            Destroy(gameObject);
        }
    }

}
