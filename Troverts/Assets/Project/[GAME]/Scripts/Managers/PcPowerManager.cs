using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcPowerManager : Singleton<PcPowerManager>
{
    private bool isPowerUp;
    public bool IsPowerUp { get { return isPowerUp; } set { isPowerUp = value; } }

    void Start()
    {
        IsPowerUp = false;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.F))
        IsPowerUp = true;
    }
}
