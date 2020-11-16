using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 25f;
    public GameObject canvasEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }

        if(collision.gameObject.tag == "Endgame")
        {
            canvasEnd.SetActive(true);
        }
    }
}
