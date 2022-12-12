using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngredientsController : MonoBehaviour
{
    //Sounds
    public AudioSource IngredientDroppedSound;
    public AudioSource ExplosionSound;
    public AudioSource PotionSound;

    //Explosion and green fire
    public ParticleSystem Explosion;
    public ParticleSystem GreenFire;
    public ParticleSystem IngredientDropped;

    //Three ingredients
    public GameObject Crystal;
    public GameObject Skull;
    public GameObject Egg;

    //Potion
    public GameObject Potion;
    
    //Canvas to end the level
    public GameObject CanvasEnd;

    private void Awake()
    {
        Potion.SetActive(false);
        CanvasEnd.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "BetterCrystal01")
        {
            Destroy(Crystal);
            CreateIngredientDropped();
            IngredientDroppedSound.Play();
            
        } else if (collider.gameObject.name == "prop_skull")
        {
            Destroy(Skull);
            CreateIngredientDropped();
            IngredientDroppedSound.Play();

        } else if (collider.gameObject.name == "Egg")
        {
            Destroy(Egg);
            CreateIngredientDropped();
            IngredientDroppedSound.Play();
        }
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Ingredient") == null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Cauldron"));
            CreateParticles();
            Potion.SetActive(true);
            ExplosionSound.Play();
            PotionSound.PlayDelayed(1);
            CanvasEnd.SetActive(true);
        }
        
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("Scene 3");
        }
    }
    
    void CreateParticles()
    {
        Explosion.Play();
        GreenFire.Play();
    }
    
    void CreateIngredientDropped()
    {
        IngredientDropped.Play();
    }
}
