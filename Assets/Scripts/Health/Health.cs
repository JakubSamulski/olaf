using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    
    [SerializeField] private AudioClip dieSound;
    
    public float currentHealth { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
      
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        print(currentHealth);
        print("Player took damage");
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        print(currentHealth);
        if (currentHealth > 0)
        {

        }
        else
        {
            SoundManager.instance.PlaySound(dieSound);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
            SoundManager.instance.PlaySound(dieSound);
        }
    }
}
