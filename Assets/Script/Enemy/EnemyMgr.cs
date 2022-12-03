using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMgr : Singleton<EnemyMgr>
{
    
    public float generateTime ; //出怪时间  
    [SerializeField] private float gTimer ;
    // public float TimeCD ; //出怪间隔

    public List<EnemyDoor> enemyDoors = new List<EnemyDoor>();

    public void RegisterDoor(EnemyDoor door){
        enemyDoors.Add(door);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if(gTimer <= 0.01f){
            NotifyDoors();
            gTimer = generateTime;
        }else{
            gTimer -= Time.deltaTime;
        }
    }

    public void NotifyDoors(){
        int mode = 0 ; 
        foreach (EnemyDoor door in enemyDoors)
        {
            door.generateEnemy(mode);
        }
    }
}
