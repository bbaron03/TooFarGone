using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    float timer;
    public static string curLevel;
    public int deathCount;
    public AudioSource loadMusic;
    // Start is called before the first frame update
    public void SwitchScene()
    {
       
        SceneManager.LoadScene("StorySlides");
        
        timer = 0;
        

    }

    private void Start()
    {
        
    }

    public static void SetLevel(string levelName)
    {
        curLevel = levelName;
    }


    private void Update()
    {
        
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            if (timer == 0) 
                loadMusic.PlayOneShot(loadMusic.clip, .4f);
            timer += Time.deltaTime;
            if (timer > 6)
            {
                SceneManager.LoadScene(curLevel);
                
            }
            
        }
       

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            deathCount++;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                
                SceneManager.LoadScene(curLevel);
            }
        }
        
            
        if(GlobalControl.Instance.dayCounter > 3 && GlobalControl.Instance.dayCounter != null)
        {
            SceneManager.LoadScene("TooLateScene");
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(7))
        {
            GameObject CanvasEnd = GameObject.FindGameObjectWithTag("CanvasEnd");
            if(CanvasEnd.activeSelf)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    Application.Quit();
                }

            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(8))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.Quit();
            }
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
