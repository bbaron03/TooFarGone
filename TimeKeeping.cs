using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeKeeping : MonoBehaviour
{
    public GameObject fillImage;
    public GameObject sunOrMoon;
    public GameObject thirstBar;
    public TextMeshProUGUI dayCount;

    int dayCounter;
    int minute;
    public int cycleLength;
    float timer = 0f;
    float thirstTimer = 0f;
    // Every two cycles, plus one day
    int cycleShiftCount;

    public TimeKeeping instance;

    public Image bg;

    public Sprite moon;
    public Sprite sun;
    public Sprite daySky;
    public Sprite nightSky;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;


        minute = GlobalControl.Instance.minute;
        dayCounter = GlobalControl.Instance.dayCounter;
        if (GlobalControl.Instance.dayCounter == 0)
            dayCounter++;
        cycleShiftCount = GlobalControl.Instance.cycleCount;
        if (cycleShiftCount % 2 == 1)
        {
            sunOrMoon.GetComponent<Image>().sprite = moon;
            bg.GetComponent<Image>().sprite = nightSky;
            fillImage.GetComponent<Image>().color = new Color32(127, 8, 248, 255);
            dayCount.SetText("Night " + dayCounter);
        }
        else
        {
            sunOrMoon.GetComponent<Image>().sprite = sun;
            bg.GetComponent<Image>().sprite = daySky;
            fillImage.GetComponent<Image>().color = new Color32(248, 211, 8, 255);
            dayCount.SetText("Day " + dayCounter);
        }

       
       /* 
        sunOrMoon.GetComponent<Image>().sprite = sun;
        bg.GetComponent<Image>().sprite = daySky;
        fillImage.GetComponent<Image>().color = new Color32(248, 211, 8, 255);
        instance.GetComponent<Bars>().SetValue(minute);
       */
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if(timer > 1)
        {
            instance.GetComponent<Bars>().SetValue(minute);
            timer = 0;
            minute++;
            GlobalControl.Instance.minute = minute;
        }

        if(minute == cycleLength)
        {
            minute = 0;
            GlobalControl.Instance.minute = minute;

            cycleShiftCount++;
            
            GlobalControl.Instance.cycleCount = cycleShiftCount;

            instance.GetComponent<Bars>().SetValue(minute);

            if(cycleShiftCount % 2 == 1)
            {
               sunOrMoon.GetComponent<Image>().sprite = moon;
                bg.GetComponent<Image>().sprite = nightSky;
               fillImage.GetComponent<Image>().color = new Color32(127, 8, 248, 255);
                dayCount.SetText("Night " + dayCounter);
            }
            else
            {
                sunOrMoon.GetComponent<Image>().sprite = sun;
                bg.GetComponent<Image>().sprite = daySky;
                fillImage.GetComponent<Image>().color = new Color32(248, 211, 8, 255);
            }

            if (cycleShiftCount % 2 == 0 && cycleShiftCount != 0)
            {
                dayCounter++;
                GlobalControl.Instance.dayCounter = dayCounter;

                dayCount.SetText("Day " + dayCounter);
            }

            if(dayCounter > 3)
            {
                SceneManager.LoadScene("TooLateScene");
            }
            

        }

        thirstTimer += Time.deltaTime;
       
            if (thirstTimer > 12)
        {
            
            thirstBar.GetComponent<Bars>().DecreaseValue(1);
            thirstTimer = 0;
        }


    }
}
