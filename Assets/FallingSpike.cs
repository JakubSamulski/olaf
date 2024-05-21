using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;
    public float distance;
    bool isFalling = false;
    Vector2 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (isFalling == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);
            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);

            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("player"))
                {
                    rigidbody2D.gravityScale = 5;
                    isFalling = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Destroy(gameObject);
            StartCoroutine(Respawn());
        }
        else
        {
            rigidbody2D.gravityScale = 0;
            boxCollider2D.enabled = false;
            isFalling = false;
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2); // Wait for 2 seconds before respawning
        transform.position = initialPosition;
        rigidbody2D.velocity = Vector2.zero;
        boxCollider2D.enabled = true;
        rigidbody2D.gravityScale = 0;
        isFalling = false;
    }
}
