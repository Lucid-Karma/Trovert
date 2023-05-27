using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimeBenderBox : MonoBehaviour, ICollectable
{
    //private float moveSpeed = 10f;
    private float time = 4f;

    private void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), time, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    public void Collect()
    {
        EventManager.OnIntrovertFirstPowerUp.Invoke();  // to initialize ui text.
        PcPowerManager.Instance.IsPowerUp = true;
        PcPowerManager.Instance.IsLearning = true;
        //EventManager.OnTimeBend.Invoke();
        //EventManager.OnTimeFlow.Invoke();
        gameObject.SetActive(false);
    }
}
