using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public bool isFacingLeft;
    public float health = 10f;
    public float speed = 1.2f;
    public float bulletDamage = 5f;
    public int damageVal;
    public GameObject Boss;

    public AudioSource impactNoise;
    // Start is called before the first frame update
    void Start()
    {
        isFacingLeft = true;
    }

    public void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        isFacingLeft = !isFacingLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingLeft == true)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        if (isFacingLeft == false)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            AudioSource.PlayClipAtPoint(impactNoise.clip, this.transform.position, .5f);
            Destroy(collision.gameObject);
            health -= bulletDamage;

            if (health <= 0)
                Destroy(gameObject);
        }
        if(collision.gameObject.tag == "EnemyTurn")
        {
            Flip();
           

        }
       
    }


    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit: enemy");
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    */

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
