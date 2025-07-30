using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHp;
    int hp;

    public Image maxHealth, health;

    Canvas ui;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ui = GetComponentInChildren<Canvas>();
        hp = maxHp;
        maxHealth.rectTransform.sizeDelta = new Vector2(maxHp, 20);
        health.rectTransform.sizeDelta = maxHealth.rectTransform.sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        print($"My max hp is {maxHp}, and my current hp is {hp}");
        if(hp <= 0)
        {
            if(tag.Equals("Player"))
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        ui.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        health.rectTransform.sizeDelta = new Vector2(hp, 20);
    }
}
