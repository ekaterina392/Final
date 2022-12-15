using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject StartCanvas;
    public GameObject Instructions;
    public GameObject Dragon;

    // Start is called before the first frame update
    void Start()
    {
      Instructions.SetActive(false);
      StartCanvas.SetActive(true);

      
      //disable player controller script
      Dragon.GetComponent<ThirdPersonMovement>().enabled = false;
      //Time.timeScale = 0;

    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        
        {
            
        //disable player controller script
        Dragon.GetComponent<ThirdPersonMovement>().enabled = true;
        //Time.timeScale = 1;

        
        Instructions.SetActive(true);
        StartCanvas.SetActive(false);
        }

    }
}
