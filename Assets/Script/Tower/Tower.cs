using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 所有塔的父类 
public class Tower : MonoBehaviour
{
    public GameObject Bullet;
    //public float attackArea ; 
    public float attackCD ; 
    private float attackTimer = -99f;
    public GameObject target;

    [Header("攻击设置")]
    public float attackDamage ; 

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if(attackTimer <= 0.01f && target != null){
            attackEnemy();
            attackTimer = attackCD ; 
        }else{
            attackTimer -= Time.deltaTime;
        }
    }

    private void attackEnemy(){
        target.GetComponent<SpriteRenderer>().color = new Color(255,125,0);
        target.GetComponent<Enemy>().getDamage(attackDamage);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")){
            target = other.gameObject;
        }
    }
}
