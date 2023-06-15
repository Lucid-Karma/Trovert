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
        EventManager.OnLevelStart.AddListener(() => CollectableData.CoinCount = 0);
    }
    void OnDisable()
    {
        EventManager.OnIntrovertFirstBoxCall.RemoveListener(DisableCoin);
        EventManager.OnIntrovertSecondBoxCall.RemoveListener(DisableCoin);
        EventManager.OnLevelStart.RemoveListener(() => CollectableData.CoinCount = 0);
    }

    private void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), time, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    public void Collect()
    {

        CollectableData.CoinCount ++;
        EventManager.OnCoinPickUp.Invoke();

        if(CollectableData.CoinCount == 1 && PlayerPrefs.GetString("selected_character") == "introvert")
        {
            EventManager.OnIntrovertFirstBoxCall.Invoke();
        }
        if(CollectableData.CoinCount == 2 && PlayerPrefs.GetString("selected_character") == "introvert")
        {
            EventManager.OnIntrovertSecondBoxCall.Invoke();
        }

        Debug.Log(CollectableData.CoinCount);
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
}
