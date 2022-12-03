using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDetector : MonoBehaviour
{
    public GameObject tile ;
    public bool canGet = false ; 

    public bool getState(){
        return canGet ; 
    }

    public GameObject getTile(){
        return gameObject ; 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Land"))
        {
                tile = other.gameObject;
                canGet = true ;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Land"))
        {
                tile = null;
                canGet = false;

        }
    }
}
