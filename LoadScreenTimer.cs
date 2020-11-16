using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScreenTimer : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
       if(timer > 10f)
       {
          SceneManager.LoadScene("Level_1");
       }
    }
}
