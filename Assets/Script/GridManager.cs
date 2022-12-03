using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject setCenter;
    public int Size; // n x n 
    public float offest; 

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0 ; j < Size ; j++){
                    Vector3 temp = new Vector3 (setCenter.transform.localPosition.x + offest + i ,setCenter.transform.localPosition.y - j -offest , setCenter.transform.localPosition.z);

                    GameObject gob =  GameObject.Instantiate(setCenter);
                    gob.transform.localPosition = temp ;
                }




            } 
            // GameObject.Instantiate(setCenter);
        }
    }
}
