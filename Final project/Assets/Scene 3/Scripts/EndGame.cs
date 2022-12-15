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
        if (GameObject.FindGameObjectWithTag("Cannon1") == null && GameObject.FindGameObjectWithTag("Destroyed1") == null && GameObject.FindGameObjectWithTag("Destroyed2") == null && GameObject.FindGameObjectWithTag("Destroyed3") == null)
        {
            CanvasEnd.SetActive(true);
            Constraint.SetActive(false);
            Destroy(Instructions);        
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Dragon")
        {
            SceneManager.LoadScene("Scene 4");
        }
    }
}
