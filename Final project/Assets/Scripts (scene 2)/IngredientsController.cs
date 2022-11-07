using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsController : MonoBehaviour
{
    //Three ingredients
    public GameObject Sphere;
    public GameObject Cylinder;
    public GameObject Cube;

    
    //Potion
    //public GameObject Capsule;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Sphere")
        {
            Destroy(Sphere);
        } else if (collider.gameObject.name == "Cylinder")
        {
            Destroy(Cylinder);
        } else if (collider.gameObject.name == "Cube")
        {
            Destroy(Cube);
        }
    }
}
