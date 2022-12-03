using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogControllerScene1 : MonoBehaviour
{
    public GameObject DoorTrigger;

    public AudioSource Knocking;
    public AudioSource GirlSpeaking;

    public GameObject CanvasGirl;
    public GameObject CanvasPressT;
    public GameObject CanvasPressE;
    
    public GameObject Girl;

    private void Awake()
    {
        DoorTrigger.SetActive(false);
        
        CanvasGirl.SetActive(false);
        CanvasPressT.SetActive(true);
        CanvasPressE.SetActive(false);
    }

    void Update()
    {

        if (Vector3. Distance(gameObject.transform.position, Girl.transform.position) < 2 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasGirl.SetActive(true);
            Destroy(CanvasPressT);
            
            //Timer
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
 
                CanvasPressE.SetActive(true);
                Destroy(CanvasGirl);
                Knocking.Play();
                
                GirlSpeaking.PlayDelayed(2.5f);

                DoorTrigger.SetActive(true);
            }
            
            StartCoroutine(ExecuteAfterTime(3));
        }
        
        if (Vector3.Distance(gameObject.transform.position, DoorTrigger.transform.position) < 2.5f &&
            Input.GetKeyDown(KeyCode.E) && DoorTrigger.activeSelf)
        {
            //moving to the sound scene
            Debug.Log("door opened");
        }
    }

}
