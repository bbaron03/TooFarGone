using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 5;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public Camera cam;
    public GameObject player;
    float height;
    float width;
    float halfH;
    float halfW;

    

    public AudioSource impact;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        cam = Camera.main;
        height = (2f * cam.orthographicSize) - (2f * cam.orthographicSize) / 4;
        width = (height * cam.aspect) - ((height * cam.aspect) / 4);
        

    }

    private void Update()
    {
        if(Mathf.Abs(transform.position.x - cam.transform.position.x) > width)
        {
            Destroy(gameObject);
        }
        if (Mathf.Abs(transform.position.y - cam.transform.position.y) > height)
        {
            Destroy(gameObject);
        }

        
    }
    void OnTriggerEnter2D(Collider2D hitInfo) 
    {
       
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);

        Instantiate(impactEffect, transform.position, transform.rotation);
        
    }


}
