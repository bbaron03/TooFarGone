using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public float value;
    public GameObject bar;
    public GameObject player;
    public bool isHealth;
    public AudioSource pickupNoise;
    

    // Start is called before the first frame update
    void Start()
    {
        
        if(gameObject.tag == "Water")
        {
            isHealth = false;
        }
        else if(gameObject.tag == "Health")
        {
            isHealth = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(pickupNoise.clip, transform.position, .5f);

            bar.GetComponent<Bars>().SetValue(value + bar.GetComponent<Bars>().GetValue());

            gameObject.SetActive(false);
            Destroy(this.gameObject);
            
        }
    }

   
}
