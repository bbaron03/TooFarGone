using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class TextStory : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string playerName;
    public string[] lines;
    public AudioSource selectSound;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        lines= new string[] { "<click>","Hello", "You must be Dexter.","It is a pleasure to meet you.",
                "In case you are wondering, I am you. I am your family, I am your friends, I am everything, yet nothing all at once.",
                "This is not your time to go, Dexter", "You must fix your ship and leave before the wormhole closes in 3 days. Now, go!"};
        
    }

        

    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(i<lines.Length)
            {
                selectSound.PlayOneShot(selectSound.clip, .5f);
                text.SetText(lines[i]);
                i++;

            }
            
            else
            {
                SceneManager.LoadScene("LoadScreen");
                SceneSwitcher.curLevel = "Level_1";
            }
        }
       
    }
}
