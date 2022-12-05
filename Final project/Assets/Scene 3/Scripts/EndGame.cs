using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    void Update()
    {
        //Type ALL cannons and enemies here
        if (GameObject.FindGameObjectWithTag("Cannon1") == null)
        {
            Debug.Log("all enemies are destoroyed");
        } 
    }
}
