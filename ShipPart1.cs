﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ShipPart1 : MonoBehaviour
{
    public static bool collided = false;
    int i = 0;
    string[] lines;

    public TextMeshProUGUI text;
    public GameObject activator;
     
    // Start is called before the first frame update
    void Start()
    {
        lines = new string[] { "Well done getting your first part, but the journey is just getting started <click>",
                                "You ready to keep fighting? <click>", ""};
    }

    // Update is called once per frame
    void Update()
    {
        if(collided)
        {
            if(!activator.activeSelf)
                activator.SetActive(true);


            SceneSwitcher.SetLevel("Level_2");
            if (i >= lines.Length)
                SceneManager.LoadScene("LoadScreen");
            if(Input.GetMouseButtonDown(0))
            {
                text.SetText(lines[i]);
                i++;
               
            }

            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collided = true;
            
        }
         
    }
}
