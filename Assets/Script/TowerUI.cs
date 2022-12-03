using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            GameManager.Instance.BuildTower(1);
            GameManager.Instance.ExitBuildTower();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            GameManager.Instance.BuildTower(2);
            GameManager.Instance.ExitBuildTower();
        }

        if(Input.GetKeyDown(KeyCode.Alpha3)){
            GameManager.Instance.BuildTower(3);
            GameManager.Instance.ExitBuildTower();
        }

        if(Input.GetKeyDown(KeyCode.Alpha4)){
            GameManager.Instance.BuildTower(4);
            GameManager.Instance.ExitBuildTower();
        }
    }
}
