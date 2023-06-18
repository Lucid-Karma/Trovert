using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollectableData 
{
    private static int coinCount;
    public static int CoinCount{ get 
    { 
        if(coinCount >= 0)  return coinCount; 
        else    return 0;
    
    } 
    set { coinCount = value;}}

    private static int bulletCount;
    public static int BulletCount{ get { return bulletCount; } set { bulletCount = value;}}

    public static bool isFirstPowerUp = false;
    public static bool isSecondPowerUp = false;
}
