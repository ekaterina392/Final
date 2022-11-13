using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    //Centaur
    public GameObject CanvasCentaur;
    public GameObject Centaur;

    private void Awake()
    {
        CanvasCentaur.SetActive(false);
    }
    
    void Update ()
    {
        //Centaur
        if (Vector2. Distance(gameObject.transform.position, Centaur.transform.position) < 5 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasCentaur.SetActive(true);
        }
        
        if (Vector2. Distance(gameObject.transform.position, Centaur.transform.position) > 5)
        {
            CanvasCentaur.SetActive(false);
        }
    }
}
