using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoor : MonoBehaviour
{
    [Header("基础属性")]
    public Vector3 location;

    [Header("怪物列表")]
    public GameObject EneA ;  
    public GameObject EneB ;  
    public GameObject EneC ;
    public GameObject EneTest ;
    
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        EnemyMgr.Instance.RegisterDoor(this);
        location = new Vector3(transform.position.x , transform.position.y , transform.position.z);
    }

    public void generateEnemy(int i){
        if(i == 0){
            GameObject.Instantiate(EneTest,location,Quaternion.identity);
        }

        if(i == 1){
            GameObject.Instantiate(EneA,location,Quaternion.identity);
        }

        if(i == 2){
            GameObject.Instantiate(EneB,location,Quaternion.identity);
        }

        if(i == 3){
            GameObject.Instantiate(EneC,location,Quaternion.identity);
        }

        randOffest();
    }

    private void randOffest(){
        float Offesty = Random.Range(-10,10);
        float Offestx = Random.Range(-5,5);
        transform.position = new Vector3(transform.position.x + Offestx , transform.position.y+Offesty,transform.position.z );

        Offesty = Random.Range(-3,3);
        Offestx = Random.Range(-3,3);
        location =  new Vector3(transform.position.x + Offestx , transform.position.y+Offesty,transform.position.z );
    }


}
