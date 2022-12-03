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

    public GameObject player ;

    [SerializeField] private bool hurtPlayer = false ;

    public List<GameObject> buffs = new List<GameObject>();
    public List<string> existBuff = new List<string>();

    //public Dictionary<string , GameObject> buffs = new Dictionary<string, GameObject>();

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {

    }
    void Start()
    {
        player = PlayerControl.instance.gameObject ; 
    }

    void Update()
    {

        // 测试Enemy获得buff
        if(Input.GetKeyDown(KeyCode.O)){
            getBuff("灼烧");
        }

        gameObject.transform.localPosition = Vector2.MoveTowards(this.transform.position,player.transform.position,speed*Time.deltaTime) ; 

        if(hurtPlayer && !PlayerControl.instance.isDef){
            PlayerControl.instance.PlayerHurt();
        }

    }

    public void getBuff(string buffName){
        if(existBuff.Contains(buffName)){
            //不干活
        }else{
            existBuff.Add(buffName);
            BuffManager.Instance.giveBuff(this,buffName);
        }
    }


    public void removeExitBuffString(string s){
        existBuff.Remove(s);
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

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("161616");
        if(other.CompareTag("Player")){
            hurtPlayer = true ;
        }
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            hurtPlayer = false ;
        }
    }
}
