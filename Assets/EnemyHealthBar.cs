using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{

    [SerializeField] private Slider healthSlider;
    [SerializeField] private EnemyHealth health;
    // Start is called before the first frame update

    private void Start()
    {
        updateHealthBar(health.currentHealth , health.startingHealth);
    }
    public void updateHealthBar(float currentHealth,float maxHealth)

    {
        healthSlider.value = currentHealth/maxHealth;
    }
}
