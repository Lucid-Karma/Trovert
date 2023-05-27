using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    public TextMeshProUGUI TimerText
    {
        get
        {
            if(timerText == null)
            timerText = GetComponent<TextMeshProUGUI>();

            return timerText;
        }
    }

    private float timeValue = 1000;

    void FixedUpdate()
    {
            if(timeValue > 0)   timeValue -= Time.fixedDeltaTime;
            else    timeValue = 0;

            DisplayTime(timeValue);
        
    }

    void DisplayTime(float timeToDisplay)
    {
        if(!GameManager.Instance.IsLevelStarted)    return;
        if(FsmManager.Instance.IsCharacterCommunicating)    return;

        if(timeToDisplay < 0)   timeToDisplay = 0;

        if(!GameManager.Instance.IsLevelFail || !GameManager.Instance.IsLevelSuccess)     
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            float milliseconds = timeToDisplay % 1 * 1000;

            TimerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

            if(timeToDisplay == 0)  
            {
                if (PlayerPrefs.GetString("selected_character") == "introvert")
                {
                    if(CharacterBase.Energy >= 1)   EventManager.OnLevelSuccess.Invoke();
                    else    EventManager.OnLevelFail.Invoke();
                }
                else    EventManager.OnLevelFail.Invoke();
            }

            // if(timeToDisplay == 0 )
            // {
            //     OnTimeOut?.Invoke();    //such a big sus. cos never do works like real observer pattern piece. change it when the time come.
            //     isTimeOut = true;
            // }  
        }
    }

}
