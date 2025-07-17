using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHp;
    int hp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        print($"My max hp is {maxHp}, and my current hp is {hp}");
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
}
