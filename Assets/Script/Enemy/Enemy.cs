using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 这是定义了所有敌人基础属性的模板 
public class Enemy : MonoBehaviour
{
    [Header("怪物属性")]
    public float health ;
    public float speed ; 

    [Header("Buff管理")]
    List<Buff> buffs = new List<Buff>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void addBuff(Buff buff){
        if(buffs.Contains(buff)){
            
        }else{
            buffs.Add(buff);
        }
    }

    public void getDamage(float _damage){
        health -= _damage ; 
    }

    public void checkDeath(){
        if(health <= 0 ){
            Death();
        }
    }

    private void Death(){
        Debug.Log("死亡："+this.gameObject );
        Destroy(gameObject);
    }
}
