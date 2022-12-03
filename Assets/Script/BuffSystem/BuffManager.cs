using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : Singleton<BuffManager>
{
    [Header("Buff栏")]
    public GameObject 灼烧Buff  ; 

    [Header("管理")]
    // 所有buff 
    public Dictionary<string , GameObject> allBuffs = new  Dictionary<string, GameObject>();
    public List<GameObject> usingBuff = new List<GameObject>();

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        initializedBuff() ;
    }

    public void initializedBuff(){
        allBuffs.Add("灼烧",灼烧Buff); // 三次，一秒一次，一次造成3伤害   
        Debug.Log("Buff初始化完成");
    }
    // public void giveBuff(Enemy enemy , string buffName){
    //     Buff temp = allBuffs[buffName];
    //     //GameObject.Instantiate<Bu>

    //     if(allBuffs.ContainsKey(buffName)){
    //         temp = allBuffs[buffName];
    //     }else{
    //         Debug.Log("目录中没有这个buff:"+buffName);
    //         return;
    //     }

    //     addBuffToUsingList(temp);
        
    //     Debug.Log("[BuffSys]给予"+enemy+"  "+buffName);
    // }
    public void giveBuff(Enemy enemy , string buffName ){
        GameObject tempBuff = GameObject.Instantiate(allBuffs[buffName],this.transform);
        tempBuff.GetComponent<Buff>().setEnemy(enemy);

        if(enemy.buffs.Contains(tempBuff)){
            //有的话就刷新
            enemy.buffs.Remove(tempBuff);
            usingBuff.Remove(tempBuff);
        }
            usingBuff.Add(tempBuff);
            enemy.buffs.Add(tempBuff);
        

    }

    public void removeBuffFromUsingList(GameObject buff){
        usingBuff.Remove(buff);
        
    }

    public void removeBuff(Enemy enemy , Buff buff){
        
    }
}
