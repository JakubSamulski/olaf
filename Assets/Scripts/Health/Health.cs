using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    
    [SerializeField] private AudioClip dieSound;
    private UIManager uIManager;
    
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
        else if (currentHealth == 0){
            uIManager = FindObjectOfType<UIManager>();
            uIManager.GameOver();

        }
        else
        {
            SoundManager.instance.PlaySound(dieSound);
            
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
