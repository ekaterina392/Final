using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject Constraint;
    public GameObject CanvasEnd;
    public GameObject Instructions;

    private void Start()
    {
        CanvasEnd.SetActive(false);
        Constraint.SetActive(true);
    }

    void Update()
    {
        //Type ALL cannons and enemies here
        if (GameObject.FindGameObjectWithTag("Cannon1") == null)
        {
            Debug.Log("all enemies are destoroyed");
            CanvasEnd.SetActive(true);
            Constraint.SetActive(false);
            Instructions.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Monster1
        if (collision.gameObject.name == "Dragon")
        {
            SceneManager.LoadScene("Scene 4");
        }
    }
}
