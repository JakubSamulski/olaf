using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float startingHealth { get; private set; }
    [SerializeField] private EnemyHealthBar healthBar;
    public float currentHealth { get; private set; }

    private void Awake()
    {
        startingHealth = 3;
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        print(currentHealth);
        healthBar.updateHealthBar(currentHealth, startingHealth);
        if (currentHealth <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
