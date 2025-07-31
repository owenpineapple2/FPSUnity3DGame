using UnityEngine;
using UnityEngine.UI;

public class PlayerCode : MonoBehaviour
{
    public GameObject projectile1, projectile2; 
    public GameObject output;
    float force;

    bool ShootOnCoolDown;
    float ShootDelay;
    float shootTimer;

    public Canvas abilityUI;
    public float alphaLv;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void ChangeColor(float alpha)
    {
        for (int index = 0; index < abilityUI.transform.childCount; index++)
        {
            Image background = abilityUI.transform.GetChild(index).GetComponent<Image>();
            Color newColor = background.color;
            newColor.a = alpha;
            background.color = newColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ShootOnCoolDown)
        {
            ChangeColor(alphaLv);

            shootTimer += Time.deltaTime;

            if(shootTimer >= ShootDelay)
            {
                ShootOnCoolDown = false;
                shootTimer = 0;
                ChangeColor(1);
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

        force = newprojectile.GetComponent<Projectile>().force;
        ShootDelay = newprojectile.GetComponent<Projectile>().cooldown;

        newprojectile.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * force);
        ShootOnCoolDown = true;
    }
}
