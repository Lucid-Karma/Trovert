using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GreetingsTextController : MonoBehaviour
{
    private TextMeshProUGUI greetingText;
    public TextMeshProUGUI GreetingText
    {
        get
        {
            if(greetingText == null)
            greetingText = GetComponent<TextMeshProUGUI>();

            return greetingText;
        }
    }

    public string[] greetings = {"Hello !!", "No Time No See", "'Sup !", "How are you doing?", "Hey!", "Hello, Goodbye", "You have not changed at all"};
    private int randomGreeting;

    void OnEnable()
    {
        EventManager.OnPreGreet.AddListener(Greet);
    }
    void OnDisable()
    {
        EventManager.OnPreGreet.RemoveListener(Greet);
    }

    void Greet()
    {
        randomGreeting = Random.Range(0, greetings.Length);

        GreetingText.text = greetings[randomGreeting];
    }
}
