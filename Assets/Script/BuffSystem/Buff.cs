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

    public Buff(int _MaxCount){
        this.MaxCount = _MaxCount; 
        this.Count = _MaxCount ; 
        this.Timer = 0.1f ;
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
        }
    }

    public void RefreshBuff(){
        Count = MaxCount ; 
        Timer = 0.01f;
    }

    public abstract void useBuff(); // 触发buff 
}
