using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogControllerScene1 : MonoBehaviour
{
    public AudioSource Knocking;

    public GameObject CanvasGirl;
    public GameObject CanvasPressT;
    public GameObject CanvasPressE;
    
    public GameObject Girl;

    private void Awake()
    {
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
                Knocking.Play(2);
            }
            
            StartCoroutine(ExecuteAfterTime(3));
        }
    }

}
