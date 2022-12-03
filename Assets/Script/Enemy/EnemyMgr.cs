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
            callEne();
            //gTimer = generateTime;
            gTimer = Random.Range(generateTime-1,generateTime+3);
        }else{
            gTimer -= Time.deltaTime;
        }
    }

    private void callEne(){
        float temp = GameManager.Instance.getWintime();
        if(temp >= 900){
            NotifyDoors(1);
        }else if(temp >= 720){
            NotifyDoors(2);
        }else if(temp >= 480){
            NotifyDoors(1);
            NotifyDoors(2);

        }else if(temp >= 180){
            NotifyDoors(1);
            NotifyDoors(3);
        }else{
            NotifyDoors(2);
            NotifyDoors(3);
        }
    }

    public void NotifyDoors(){
        int mode = 0 ; 
        foreach (EnemyDoor door in enemyDoors)
        {
            door.generateEnemy(mode);
        }
    }

    public void NotifyDoors(int mode){
        foreach (EnemyDoor door in enemyDoors)
        {
            door.generateEnemy(mode);
        }
    }
}
