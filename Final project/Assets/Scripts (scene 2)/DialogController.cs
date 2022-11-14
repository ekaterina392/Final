using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
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
        //Centaur
        if (Vector2. Distance(gameObject.transform.position, Centaur.transform.position) < 3 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasCentaur.SetActive(true);
        }
        
        if (Vector2. Distance(gameObject.transform.position, Centaur.transform.position) > 3)
        {
            CanvasCentaur.SetActive(false);
        }
    
        //Crab
        if (Vector2. Distance(gameObject.transform.position, Crab.transform.position) < 3 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasCrab.SetActive(true);
        }
        
        if (Vector2. Distance(gameObject.transform.position, Crab.transform.position) > 3)
        {
            CanvasCrab.SetActive(false);
        }
        
        //Titan
        if (Vector2. Distance(gameObject.transform.position, Titan.transform.position) < 3 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasTitan.SetActive(true);
        }
        
        if (Vector2. Distance(gameObject.transform.position, Titan.transform.position) > 3)
        {
            CanvasTitan.SetActive(false);
        }
        
        //Cave man
        if (Vector2. Distance(gameObject.transform.position, CaveMan.transform.position) < 3 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasCaveMan.SetActive(true);
        }
        
        if (Vector2. Distance(gameObject.transform.position, CaveMan.transform.position) > 3)
        {
            CanvasCaveMan.SetActive(false);
        }
        
        //Troll
        if (Vector2. Distance(gameObject.transform.position, Troll.transform.position) < 3 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasTroll.SetActive(true);
        }
        
        if (Vector2. Distance(gameObject.transform.position, Troll.transform.position) > 3)
        {
            CanvasTroll.SetActive(false);
        }
        
        //Demon girl
        if (Vector2. Distance(gameObject.transform.position, DemonGirl.transform.position) < 3 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasDemonGirl.SetActive(true);
        }
            
        if (Vector2. Distance(gameObject.transform.position, DemonGirl.transform.position) > 3)
        {
            CanvasDemonGirl.SetActive(false);
        }
        
        //Piggy orc
        if (Vector2. Distance(gameObject.transform.position, PiggyOrc.transform.position) < 3 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasPiggyOrc.SetActive(true);
        }
            
        if (Vector2. Distance(gameObject.transform.position, PiggyOrc.transform.position) > 3)
        {
            CanvasPiggyOrc.SetActive(false);
        }
        
        
        //Woman warrior
        if (Vector2. Distance(gameObject.transform.position, WomanWarrior.transform.position) < 3 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasWomanWarrior.SetActive(true);
        }
            
        if (Vector2. Distance(gameObject.transform.position, WomanWarrior.transform.position) > 3)
        {
            CanvasWomanWarrior.SetActive(false);
        }
    }
}
