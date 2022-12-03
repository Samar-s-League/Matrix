using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 这是定义了所有敌人基础属性的模板 
public class Enemy : MonoBehaviour
{
    [Header("怪物属性")]
    public float health ;
    public float speed ; 

    public int deadExp ; 

    public List<string> buffs = new List<string>();

    //public Dictionary<string , GameObject> buffs = new Dictionary<string, GameObject>();
    void Start()
    {
        
    }

    void Update()
    {
        // 测试Enemy获得buff
        if(Input.GetKeyDown(KeyCode.O)){
            getBuff("灼烧");
        }
    }

    public void getBuff(string buffName){
        if(buffs.Contains(buffName)){
            // 拥有则刷新
        }else{
            Debug.Log("给予"+this+"   "+buffName);
            BuffManager.Instance.giveBuff(this,buffName);
        }
    }

    public void getDamage(float _damage){
        health -= _damage ; 
        checkDeath();
    }

    public void checkDeath(){
        if(health <= 0 ){
            Death();
        }
    }

    private void Death(){
        Debug.Log("死亡："+this.gameObject );
        GameManager.Instance.addExpToPlayer(deadExp);
        Destroy(gameObject);
    }
}
