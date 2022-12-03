using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBuff : Buff
{
    public float damage ; 
    // public DamageBuff(int _MaxCount , float _damage) : base(_MaxCount)
    // {
    //     Debug.Log("生成一个DamageBuff");
    //     this.MaxCount = _MaxCount;
    //     this.damage = _damage ; 
    // }

    // public DamageBuff(int _MaxCount , float _damage) : base(_MaxCount)
    // {
    //     Debug.Log("生成一个DamageBuff");
    //     this.MaxCount = _MaxCount;
    //     this.damage = _damage ; 
    // }

    public override void useBuff()
    {
        enemy.getDamage(damage);
        Debug.Log("对 "+enemy+" 执行 "+this);
        enemy.GetComponent<SpriteRenderer>().color  = new Color(255,0,0);
    }

    public override void endBuff(){
            Debug.Log(enemy+" 结束buff "+this);
        enemy.GetComponent<SpriteRenderer>().color  = new Color(255,255,255);
    }
}
