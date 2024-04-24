using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private Transform currentPoint;
   private EnemyHealth enemyHealth;
    public float speed;
    public GameObject sword;
    [SerializeField] private float startingHealth;
    private float currentHealth;
    private bool isAttacking = false;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = pointB.transform;
        animator.SetBool("isRunning", true);
        enemyHealth = GetComponent<EnemyHealth>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {


        if (isAttacking)
        {
            sword.transform.Rotate(Vector3.back, 400 * Time.deltaTime);
            print("wrod rotation "+sword.transform.rotation.eulerAngles.z);
        }

        if (sword.transform.rotation.eulerAngles.z < 300)
        {
            isAttacking = false;
            sword.transform.eulerAngles = new Vector3(
                 sword.transform.eulerAngles.x,
                 sword.transform.eulerAngles.y,
                 -10f);
        }

        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform){
            rigidbody.velocity = new Vector2(speed, 0);
        }
        else {
            rigidbody.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform){
            flip();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform){
            flip();
            currentPoint = pointB.transform;
        }
    }

    private void flip(){
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        flipSword();
    }

    private void flipSword()
    {
        Vector3 localScale = sword.transform.localScale;
        localScale.x *= -1;
        sword.transform.localScale = localScale;
        sword.transform.Rotate(0, 180, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fireball"))
        {  
            enemyHealth.TakeDamage(1);
        }
        if(other.gameObject.CompareTag("player"))
        {
            isAttacking = true;
        }
        
    }

}
