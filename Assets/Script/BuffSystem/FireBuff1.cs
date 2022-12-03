using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBuff1 : Buff
{
    public FireBuff1(int _MaxCount) : base(_MaxCount)
    {
        Debug.Log("FireBuff1");
    }

    public override void useBuff()
    {
        enemy.getDamage(3);
        Debug.Log("对 "+enemy+" 执行 "+this);
    }
}
