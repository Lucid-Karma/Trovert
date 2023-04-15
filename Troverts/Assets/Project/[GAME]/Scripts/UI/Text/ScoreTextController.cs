using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTextController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public TextMeshProUGUI ScoreText
    {
        get
        {
            if(scoreText == null)
            scoreText = GetComponent<TextMeshProUGUI>();

            return scoreText;
        }
    }

    private void OnEnable()
    {
        EventManager.OnICharacterDataReceive.AddListener(UpdateIScoreText);
        EventManager.OnECharacterDataReceive.AddListener(UpdateEScoreText);
        // EventManager.OnIntrovertLevelStart.AddListener(UpdateIScoreText);
        // EventManager.OnExtrovertLevelStart.AddListener(UpdateEScoreText);
    }

    private void OnDisable()
    {
        EventManager.OnICharacterDataReceive.RemoveListener(UpdateIScoreText);
        EventManager.OnECharacterDataReceive.RemoveListener(UpdateEScoreText);
        // EventManager.OnIntrovertLevelStart.RemoveListener(UpdateIScoreText);
        // EventManager.OnExtrovertLevelStart.RemoveListener(UpdateEScoreText);
    }


    private int point;

    private void UpdateIScoreText()
    {
        point = Introvert.Energy;
        ScoreText.text = point + " Energy Left !!";
    }

    private void UpdateEScoreText()
    {
        point = Extrovert.Score;
        ScoreText.text = "Total Energy: " + point;
    }
}
