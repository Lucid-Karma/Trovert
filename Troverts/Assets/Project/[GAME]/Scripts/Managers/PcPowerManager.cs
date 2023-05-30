using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcPowerManager : Singleton<PcPowerManager>
{
    private bool isPowerUp;
    public bool IsPowerUp { get { return isPowerUp; } set { isPowerUp = value; } }

    private bool isLearning;
    public bool IsLearning { get { return isLearning; } set { isLearning = value; } }

    void Start()
    {
        IsPowerUp = false;
        IsLearning = false;
    }
}
