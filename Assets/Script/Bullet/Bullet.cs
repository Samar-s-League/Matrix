using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 所有子弹的父类
public class Bullet : MonoBehaviour
{
    public Transform target ; 

    public void setTarget(Transform _target){
        this.target = _target;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        
    }
}
