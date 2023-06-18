using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinTextController : MonoBehaviour
{
    private TextMeshProUGUI coinText;
    public TextMeshProUGUI CoinText
    {
        get
        {
            if(coinText == null)
            coinText = GetComponent<TextMeshProUGUI>();

            return coinText;
        }
    }

    private int coinAmount;

    void OnEnable()
    {
        EventManager.OnCoinPickUp.AddListener(UpdateCoinText);
        EventManager.OnBulletShoot.AddListener(UpdateCoinText);
    }
    void OnDisable()
    {
        EventManager.OnCoinPickUp.RemoveListener(UpdateCoinText);
        EventManager.OnBulletShoot.RemoveListener(UpdateCoinText);
    }

    private void UpdateCoinText()
    {
        coinAmount = CollectableData.CoinCount;
        CoinText.SetText(coinAmount.ToString());
    }
}
