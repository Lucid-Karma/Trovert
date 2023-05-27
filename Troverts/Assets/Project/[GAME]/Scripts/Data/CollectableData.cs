using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollectableData 
{
    private static int coinCount;
    public static int CoinCount{ get { return coinCount; } set { coinCount = value;}}

    private static int bulletCount;
    public static int BulletCount{ get { return bulletCount; } set { bulletCount = value;}}
}
