using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogController : MonoBehaviour
{
    //Potion
    public GameObject Potion;
    
    //Sounds
    public AudioSource CrabSound;
    public AudioSource TitanSound;
    public AudioSource CavemanSound;
    public AudioSource TrollSound;
    public AudioSource DemonGirlSound;
    public AudioSource PiggyOrcSound;
    public AudioSource WomanWarriorSound;
    public AudioSource CentaurSound;

    //Start canvas
    public GameObject CanvasStart;
    
    //Instructions canvas
    public GameObject Instructions;
    
    //Centaur
    public GameObject CanvasCentaur;
    public GameObject Centaur;
    
    //Crab
    public GameObject CanvasCrab;
    public GameObject Crab;
    
    //Titan
    public GameObject CanvasTitan;
    public GameObject Titan;
    
    //Cave man
    public GameObject CanvasCaveMan;
    public GameObject CaveMan;
    
    //Troll
    public GameObject CanvasTroll;
    public GameObject Troll;
    
    //Demon girl
    public GameObject CanvasDemonGirl;
    public GameObject DemonGirl;
    
    //Piggy orc
    public GameObject CanvasPiggyOrc;
    public GameObject PiggyOrc;
    
    //Woman warrior
    public GameObject CanvasWomanWarrior;
    public GameObject WomanWarrior;

    private void Awake()
    {
        Instructions.SetActive(false);
        CanvasStart.SetActive(true);
        CanvasCentaur.SetActive(false);
        CanvasCrab.SetActive(false);
        CanvasTitan.SetActive(false);
        CanvasCaveMan.SetActive(false);
        CanvasTroll.SetActive(false);
        CanvasDemonGirl.SetActive(false);
        CanvasPiggyOrc.SetActive(false);
        CanvasWomanWarrior.SetActive(false);
    }
    
    void Update ()
    {
        //End game
        if (GameObject.FindGameObjectWithTag("Ingredient") == null && Vector3. Distance(gameObject.transform.position, Potion.transform.position) < 3 && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("Scene 3");
        }
        
        if (GameObject.FindGameObjectWithTag("Ingredient") == null)
        {
            Destroy(Instructions);
        }

        if (CanvasStart == null)
        {
            Instructions.SetActive(true);
        }

        //Centaur
        if (Vector3. Distance(gameObject.transform.position, Centaur.transform.position) < 3 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasCentaur.SetActive(true);
            Destroy(CanvasStart);
            CentaurSound.Play();
        }
        
        if (Vector3. Distance(gameObject.transform.position, Centaur.transform.position) > 3)
        {
            CanvasCentaur.SetActive(false);
            CentaurSound.Stop();
        }
    
        //Crab
        if (Vector3. Distance(gameObject.transform.position, Crab.transform.position) < 4 && Input.GetKeyDown(KeyCode.T) && CanvasStart == null)
        {
            CanvasCrab.SetActive(true);
            CrabSound.Play();
        }
        
        if (Vector3. Distance(gameObject.transform.position, Crab.transform.position) > 4)
        {
            CanvasCrab.SetActive(false);
            CrabSound.Stop();
        }
        
        //Titan
        if (Vector3. Distance(gameObject.transform.position, Titan.transform.position) < 3 && Input.GetKeyDown(KeyCode.T) && CanvasStart == null)
        {
            CanvasTitan.SetActive(true);
            TitanSound.Play();
        }
        
        if (Vector3. Distance(gameObject.transform.position, Titan.transform.position) > 3)
        {
            CanvasTitan.SetActive(false);
            TitanSound.Stop();
        }
        
        //Cave man
        if (Vector3. Distance(gameObject.transform.position, CaveMan.transform.position) < 3 && Input.GetKeyDown(KeyCode.T) && CanvasStart == null)
        {
            CanvasCaveMan.SetActive(true);
            CavemanSound.Play();
        }
        
        if (Vector3. Distance(gameObject.transform.position, CaveMan.transform.position) > 3)
        {
            CanvasCaveMan.SetActive(false);
            CavemanSound.Stop();
        }
        
        //Troll
        if (Vector3. Distance(gameObject.transform.position, Troll.transform.position) < 3 && Input.GetKeyDown(KeyCode.T) && CanvasStart == null)
        {
            CanvasTroll.SetActive(true);
            TrollSound.Play();
        }
        
        if (Vector3. Distance(gameObject.transform.position, Troll.transform.position) > 3)
        {
            CanvasTroll.SetActive(false);
            TrollSound.Stop();
        }
        
        //Demon girl
        if (Vector3. Distance(gameObject.transform.position, DemonGirl.transform.position) < 3 && Input.GetKeyDown(KeyCode.T) && CanvasStart == null)
        {
            CanvasDemonGirl.SetActive(true);
            DemonGirlSound.Play();
        }
            
        if (Vector3. Distance(gameObject.transform.position, DemonGirl.transform.position) > 3)
        {
            CanvasDemonGirl.SetActive(false);
            DemonGirlSound.Stop();
        }
        
        //Piggy orc
        if (Vector3. Distance(gameObject.transform.position, PiggyOrc.transform.position) < 3 && Input.GetKeyDown(KeyCode.T) && CanvasStart == null)
        {
            CanvasPiggyOrc.SetActive(true);
            PiggyOrcSound.Play();
        }
            
        if (Vector3. Distance(gameObject.transform.position, PiggyOrc.transform.position) > 3)
        {
            CanvasPiggyOrc.SetActive(false);
            PiggyOrcSound.Stop();
        }
        
        //Woman warrior
        if (Vector3. Distance(gameObject.transform.position, WomanWarrior.transform.position) < 3 && Input.GetKeyDown(KeyCode.T) && CanvasStart == null)
        {
            CanvasWomanWarrior.SetActive(true);
            WomanWarriorSound.Play();
        }
            
        if (Vector3. Distance(gameObject.transform.position, WomanWarrior.transform.position) > 3)
        {
            CanvasWomanWarrior.SetActive(false);
            WomanWarriorSound.Stop();
        }
    }
}