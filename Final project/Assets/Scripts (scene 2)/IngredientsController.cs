using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsController : MonoBehaviour
{
    public ParticleSystem explosion;

    //Three ingredients
    public GameObject Crystal;
    public GameObject Skull;
    public GameObject Egg;

    
    //Potion
    //public GameObject Capsule;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "BetterCrystal01")
        {
            Destroy(Crystal);
        } else if (collider.gameObject.name == "prop_skull")
        {
            Destroy(Skull);
        } else if (collider.gameObject.name == "Egg")
        {
            Destroy(Egg);
        }
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Ingredient") == null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Cauldron"));
            CreateParticles();
        }
    }
    
    void CreateParticles()
    {
        explosion.Play();
    }
}
