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
        if (Vector3. Distance(gameObject.transform.position, Centaur.transform.position) < 5 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasCentaur.SetActive(true);
        }
        
        if (Vector3. Distance(gameObject.transform.position, Centaur.transform.position) > 5)
        {
            CanvasCentaur.SetActive(false);
        }
    
        //Crab
        if (Vector3. Distance(gameObject.transform.position, Crab.transform.position) < 5 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasCrab.SetActive(true);
        }
        
        if (Vector3. Distance(gameObject.transform.position, Crab.transform.position) > 5)
        {
            CanvasCrab.SetActive(false);
        }
        
        //Titan
        if (Vector3. Distance(gameObject.transform.position, Titan.transform.position) < 5 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasTitan.SetActive(true);
        }
        
        if (Vector3. Distance(gameObject.transform.position, Titan.transform.position) > 5)
        {
            CanvasTitan.SetActive(false);
        }
        
        //Cave man
        if (Vector3. Distance(gameObject.transform.position, CaveMan.transform.position) < 5 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasCaveMan.SetActive(true);
        }
        
        if (Vector3. Distance(gameObject.transform.position, CaveMan.transform.position) > 5)
        {
            CanvasCaveMan.SetActive(false);
        }
        
        //Troll
        if (Vector3. Distance(gameObject.transform.position, Troll.transform.position) < 5 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasTroll.SetActive(true);
        }
        
        if (Vector3. Distance(gameObject.transform.position, Troll.transform.position) > 5)
        {
            CanvasTroll.SetActive(false);
        }
        
        //Demon girl
        if (Vector3. Distance(gameObject.transform.position, DemonGirl.transform.position) < 5 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasDemonGirl.SetActive(true);
        }
            
        if (Vector3. Distance(gameObject.transform.position, DemonGirl.transform.position) > 5)
        {
            CanvasDemonGirl.SetActive(false);
        }
        
        //Piggy orc
        if (Vector3. Distance(gameObject.transform.position, PiggyOrc.transform.position) < 5 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasPiggyOrc.SetActive(true);
        }
            
        if (Vector3. Distance(gameObject.transform.position, PiggyOrc.transform.position) > 5)
        {
            CanvasPiggyOrc.SetActive(false);
        }
        
        
        //Woman warrior
        if (Vector3. Distance(gameObject.transform.position, WomanWarrior.transform.position) < 5 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasWomanWarrior.SetActive(true);
        }
            
        if (Vector3. Distance(gameObject.transform.position, WomanWarrior.transform.position) > 5)
        {
            CanvasWomanWarrior.SetActive(false);
        }
    }
}
