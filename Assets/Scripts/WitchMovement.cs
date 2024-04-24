using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchMovement : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public GameObject player;
    [SerializeField]private PlayerMovement playerMovement;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private Transform currentPoint;
    private EnemyHealth enemyHealth;
    private float timeSinceAttack = 0.0f;
    public GameObject circle;

    public float speed;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = pointB.transform;
        animator.SetBool("isRunning", true);
        enemyHealth = GetComponent<EnemyHealth>();

    }

    // Update is called once per frame
    void Update()
    {
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

        float seperation = Vector3.Distance(this.transform.position, player.transform.position);
        float attackCooldown = 3.0f;
        timeSinceAttack += Time.deltaTime;
        if (seperation < 5 &&timeSinceAttack>attackCooldown)
        {
            attack();
            timeSinceAttack = 0.0f;
        }

    }

    private void attack()
    {
        int spell = Random.Range(0, 3);
        if (spell == 0)
        {
            circle.GetComponent<SpriteRenderer>().color = new Color(255, 255, 0, 0.3f);
        }
        else if (spell == 1)
        {
            circle.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 0.3f);
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().color = new Color(0, 255, 1, 0.3f);
        }
        playerMovement.getAttackedBySpell(spell);
    }

    private void flip(){
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fireball"))
        {
            enemyHealth.TakeDamage(1);
        }
    }
}
