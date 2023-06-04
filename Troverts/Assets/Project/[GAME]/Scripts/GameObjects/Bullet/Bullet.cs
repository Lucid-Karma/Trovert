using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;

    void FixedUpdate()
    {
        transform.position += transform.forward * _bulletSpeed * Time.fixedDeltaTime;
    }

    void OnTriggerEnter(Collider other)
    {   
        var interactable = other.GetComponent<NpcFSM>();

        if(interactable != null)
        {
            interactable?.Die();

            // if(!PcPowerManager.Instance.IsShocked)  
            // {
            //     EventManager.OnNpcShock.Invoke();
            //     Debug.Log("interface-1");
            //     PcPowerManager.Instance.IsShocked = true;
            // }
                //interactable?.Shock();      //!!!
            gameObject.SetActive(false);
        }
    }
}
