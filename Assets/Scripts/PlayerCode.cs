using UnityEngine;

public class PlayerCode : MonoBehaviour
{
    public GameObject projectile1, projectile2; 
    public GameObject output;
    public float force;

    bool ShootOnCoolDown;
    [SerializeField] float ShootDelay;
    float shootTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ShootOnCoolDown)
        {
            shootTimer += Time.deltaTime;

            if(shootTimer >= ShootDelay)
            {
                ShootOnCoolDown = false;
                shootTimer = 0;
            }
        }

        if (ShootOnCoolDown == false)
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                SpawnProjectile(Instantiate(projectile1));
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                SpawnProjectile(Instantiate(projectile2));
            }
           
        }
    }

    void SpawnProjectile(GameObject newprojectile)
    {
        newprojectile.transform.SetParent(output.transform, false);
        newprojectile.transform.SetParent(null);
        newprojectile.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * force);
        ShootOnCoolDown = true;
    }
}
