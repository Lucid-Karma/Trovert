using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShooterBox : MonoBehaviour, ICollectable
{
    private float time = 4f;

    private void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), time, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    public void Collect()
    {
        EventManager.OnIntrovertSecondPowerUp.Invoke();
        PcPowerManager.Instance.IsLearning = true;
        Destroy(gameObject);
    }
}
