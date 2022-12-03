using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : Singleton<BuffManager>
{
    // 所有buff 
    public Dictionary<string , Buff> allBuffs = new  Dictionary<string, Buff>();

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        initializedBuff() ;
    }

    public void initializedBuff(){
        allBuffs.Add("基础火焰伤害",new FireBuff1(3));
    }
    public void giveBuff(Enemy enemy , Buff buff){
        enemy.addBuff(buff);
    }

    public void removeBuff(Enemy enemy , Buff buff){
        enemy.addBuff(buff);
    }
}
