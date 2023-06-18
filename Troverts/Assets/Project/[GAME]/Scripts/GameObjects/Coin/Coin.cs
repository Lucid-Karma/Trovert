using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour, ICollectable
{
    private float time = 4f;

    void OnEnable()
    {
        EventManager.OnIntrovertFirstBoxCall.AddListener(DisableCoin);
        EventManager.OnIntrovertSecondBoxCall.AddListener(DisableCoin);
        EventManager.OnLevelStart.AddListener(ResetPowerUp);
        EventManager.OnRestart.AddListener(ResetPowerUp);
    }
    void OnDisable()
    {
        EventManager.OnIntrovertFirstBoxCall.RemoveListener(DisableCoin);
        EventManager.OnIntrovertSecondBoxCall.RemoveListener(DisableCoin);
        EventManager.OnLevelStart.RemoveListener(ResetPowerUp);
        EventManager.OnRestart.RemoveListener(ResetPowerUp);
    }

    private void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), time, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    public void Collect()
    {

        CollectableData.CoinCount ++;
        EventManager.OnCoinPickUp.Invoke();

        if(CollectableData.CoinCount == 5 && PlayerPrefs.GetString("selected_character") == "introvert" && !CollectableData.isFirstPowerUp)
        {
            EventManager.OnIntrovertFirstBoxCall.Invoke();
            CollectableData.isFirstPowerUp = true;
        }
        if(CollectableData.CoinCount == 10 && PlayerPrefs.GetString("selected_character") == "introvert" && !CollectableData.isSecondPowerUp)
        {
            EventManager.OnIntrovertSecondBoxCall.Invoke();
            CollectableData.isSecondPowerUp = true;
        }

        gameObject.SetActive(false);
    }

    void EnableCoin()
    {
        gameObject.SetActive(true);
    }
    void DisableCoin()
    {
        gameObject.SetActive(false);
    }

    private void ResetPowerUp()
    {
        CollectableData.isFirstPowerUp = false;
        CollectableData.isSecondPowerUp = false;

        CollectableData.CoinCount = 0;
    }
}
