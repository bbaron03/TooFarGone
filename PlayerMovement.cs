using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Variables

    public float speed = 5f;
    private float movementInput;
    public GameObject thirst;
    public GameObject health;
    private Rigidbody2D rb;
    public float jumpForce = 5f;
    private bool facingRight = true;
    public bool isGrounded = false;
    public Animator animator;
    public int medKitVal = 3;
    public int waterVal = 3;
    //public float currentHealth;
    public float timeBetweenShots;
    public float bulletSpeed;
    public GameObject bullet;
    public GameObject barrel;
    public string playerDeathReason;
    public GameObject recentCheckpoint;
    //float timer = 2;
    public float damageTime = 2;
    public float thirstTimer;
    public float thirstTimes = 0;
    float timeBetweenDamage = 0f;
    float timeBetweenFootSteps = 0f;

    
    public AudioSource jumpNoise;
    public AudioSource damageNoise;
    public AudioSource pickupNoise;
    public AudioSource footsteps;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeBetweenShots = 0;
        //currentHealth = health.GetComponent<Bars>().startingVals;
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenFootSteps += Time.deltaTime;
        if (this.transform.position.y < -200)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("RespawnScreen");
        }
        

    }

    void FixedUpdate()
    {
        
        timeBetweenDamage += Time.deltaTime;
            //Move a character
            movementInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(rb.velocity.x) > 0 && timeBetweenFootSteps > footsteps.clip.length - .1 && isGrounded)
        {
            footsteps.PlayOneShot(footsteps.clip);
            timeBetweenFootSteps = 0;
        }
        //Player's rb using velocity
        rb.velocity = new Vector2(movementInput * speed, rb.velocity.y);

            //Calling Jump method
            Jump();

            //Fliping Player's sprite
            if (facingRight == false && movementInput > 0)
            {
                Flip();
            }
            else if (facingRight == true && movementInput < 0)
            {
                Flip();
            }
            //Running Animation
            animator.SetFloat("Speed", Mathf.Abs(movementInput));

            //Jumping Animation
            if (isGrounded == true)
            {
                animator.SetBool("IsJumping", false);
            }
            else
            {
                animator.SetBool("IsJumping", true);


            }

        thirstTimer += Time.deltaTime;
        if(thirst.GetComponent<Bars>().GetValue() == 0 && thirstTimer > 5)
        {
            //currentHealth--;
            damageNoise.PlayOneShot(damageNoise.clip, .5f);
            health.GetComponent<Bars>().DecreaseValue(1);
            animator.SetTrigger("damage");
            thirstTimer = 0;
            thirstTimes++;
        }
        if (health.GetComponent<Bars>().GetValue() <= 0 && thirstTimes >= 1 )
        {
            animator.SetTrigger("Die");
            StartCoroutine(ExecuteAfterTime(1));
        }
        
        
        
    }

    void Jump()
    {
        //Player's jump
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            jumpNoise.PlayOneShot(jumpNoise.clip);
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            damageNoise.PlayOneShot(damageNoise.clip, .5f);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            //currentHealth -= 1;
            health.GetComponent<Bars>().DecreaseValue(1);
            thirstTimes = 0;
            if (health.GetComponent<Bars>().GetValue() <= 0)
                {

                animator.SetTrigger("Die");
                StartCoroutine(ExecuteAfterTime(1));


               }
                else
                {
                    
                    animator.SetTrigger("Damage");
                }
            
        }
       if(collision.gameObject.tag == "Water" || collision.gameObject.tag == "Health")
        {
            pickupNoise.PlayOneShot(pickupNoise.clip, .5f);
        }

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy" && timeBetweenDamage > .1)
        {
            damageNoise.PlayOneShot(damageNoise.clip, .5f);
            Destroy(collision.gameObject);
            //currentHealth -= collision.gameObject.GetComponent<Enemy>().damageVal;
            health.GetComponent<Bars>().DecreaseValue(collision.gameObject.GetComponent<Enemy>().damageVal);
            thirstTimes = 0;
            if (health.GetComponent<Bars>().GetValue() <= 0)
            {
                animator.SetTrigger("Die");
                StartCoroutine(ExecuteAfterTime(1)); 
            }
            else
            {
                
                animator.SetTrigger("Damage");
            }
        }
        


        

    }

    
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        playerDeathReason = "player";
        SceneManager.LoadScene("RespawnScreen");
    }


}
