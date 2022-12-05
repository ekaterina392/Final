using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsController : MonoBehaviour
{
    //Explosion and green fire
    public ParticleSystem Explosion;
    public ParticleSystem GreenFire;

    //Three ingredients
    public GameObject Crystal;
    public GameObject Skull;
    public GameObject Egg;

    //Potion
    public GameObject Potion;

    private void Awake()
    {
        Potion.SetActive(false);
    }

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
            Potion.SetActive(true);
        }
    }
    
    void CreateParticles()
    {
        Explosion.Play();
        GreenFire.Play();
    }
}