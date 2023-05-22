using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour, ICollectable
{
    public float moveSpeed;
    private float time = 4f;

    private void Start()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), time, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    public void Collect()
    {
        BulletManager.Instance.SetBulletObject();
        EventManager.OnCoinPickUp.Invoke();
        gameObject.SetActive(false);
    }
}
