using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 最基本的Buff
public abstract class Buff : MonoBehaviour
{
    // 
    public Enemy enemy ; 
    public float Timer ; 
    public int MaxCount ; //触发次数
    public int Count ; //触发次数

    // 第一次的倒计时是0.1f,这样可以立刻触发
    // 默认每秒触发一次

    // public Buff(int _MaxCount){
    //     this.MaxCount = _MaxCount; 
    //     this.Count = _MaxCount ; 
    //     this.Timer = 0.1f ;
    // }
    public void setEnemy(Enemy _enemy){
        this.enemy = _enemy;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if(Count > 0){
            if(Timer >= 0.01f){
                Timer -= Time.deltaTime ; 
            }else{
                useBuff();
                Count--;
                Timer = 1.01f;
            }
            Debug.Log("[BUFF]:" + Count +"   Time:"+Timer);

        }else{
            //结束buff
            endBuff();
            // enemy.removeBuff(this);
            BuffManager.Instance.removeBuffFromUsingList(this.gameObject);
            Debug.Log("Buff结束");
            Destroy(gameObject);
        }
    }

    public void RefreshBuff(){
        Count = MaxCount ; 
        Timer = 0.01f;
    }

    public abstract void useBuff(); // 触发buff 
    public abstract void endBuff(); // 触发buff 
}
