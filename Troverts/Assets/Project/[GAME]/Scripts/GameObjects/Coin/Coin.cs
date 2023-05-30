using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour, ICollectable
{
    // CollectableData collectableData;
    //public float moveSpeed;
    private float time = 4f;

    void OnEnable()
    {
        EventManager.OnIntrovertFirstBoxCall.AddListener(DisableCoin);
        // EventManager.OnIntrovertSecondBoxCall.AddListener(EnableCoin);
    }
    void OnDisable()
    {
        EventManager.OnIntrovertFirstBoxCall.RemoveListener(DisableCoin);
        //EventManager.OnIntrovertSecondBoxCall.RemoveListener(EnableCoin);
    }

    private void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), time, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    public void Collect()
    {

        CollectableData.CoinCount ++;
        EventManager.OnCoinPickUp.Invoke();

        if(CollectableData.CoinCount == 5)
        {
            EventManager.OnIntrovertFirstBoxCall.Invoke();
        }
        if(CollectableData.CoinCount == 10)
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
