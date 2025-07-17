using UnityEngine;

public class PlayerCode : MonoBehaviour
{
    public GameObject projectile; 
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

        if (Input.GetKeyDown(KeyCode.R) && ShootOnCoolDown == false)
        {

            ShootOnCoolDown = true;

            GameObject newprojectile = Instantiate(projectile);
            newprojectile.transform.SetParent(output.transform, false);
            newprojectile.transform.SetParent(null);

            newprojectile.GetComponent<Rigidbody>().AddRelativeForce(transform.forward*force);
        }
    }
}
