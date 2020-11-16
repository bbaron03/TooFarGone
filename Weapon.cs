using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    float timer = 0;
    public AudioSource shot;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timer > .3)
        {
            Shoot();
            shot.PlayOneShot(shot.clip, .5f);
            timer = 0;
        }


    }

    void Shoot()
    {
        GameObject myEffect = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        

    }


}
