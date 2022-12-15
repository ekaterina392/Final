using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogControllerScene1 : MonoBehaviour
{
    public GameObject Text;
    public GameObject Button;

    public AudioSource BackgroundMusic;
    public AudioSource DoorSound;
    public AudioSource Scream;

    public GameObject DoorTrigger;

    public AudioSource Knocking;
    public AudioSource GirlSpeaking;

    public GameObject CanvasGirl;
    public GameObject CanvasPressT;
    public GameObject CanvasPressE;
    
    public GameObject NextLevel;

    
    public GameObject Girl;

    private void Awake()
    {
        Text.SetActive(false);
        Button.SetActive(false);
        
        NextLevel.SetActive(false);
        DoorTrigger.SetActive(false);
        
        CanvasGirl.SetActive(false);
        CanvasPressT.SetActive(true);
        CanvasPressE.SetActive(false);
    }

    void Update()
    {
        
               
        if (Input.GetKeyDown(KeyCode.Space) && Scream == null)
        {
            SceneManager.LoadScene("Scene 2");
        }
        

        if (Vector3.Distance(gameObject.transform.position, Girl.transform.position) < 2 && Input.GetKeyDown(KeyCode.T))
        {
            CanvasGirl.SetActive(true);
            Destroy(CanvasPressT);
        }

        if (CanvasPressT == null && Input.GetKeyDown(KeyCode.Q))
        {
            BackgroundMusic.Stop();
            CanvasPressE.SetActive(true);
            Destroy(CanvasGirl);
            Knocking.Play();

            GirlSpeaking.PlayDelayed(2.5f);
            DoorTrigger.SetActive(true);
        }

        if (Vector3.Distance(gameObject.transform.position, DoorTrigger.transform.position) < 2.5f &&
            Input.GetKeyDown(KeyCode.E) && DoorTrigger.activeSelf)
        {
            NextLevel.SetActive(true);
            Destroy(CanvasPressE);
            Destroy(DoorTrigger);
            Knocking.Stop();
            GirlSpeaking.Stop();

            DoorSound.Play();

            //Timer
            IEnumerator ExecuteAfterTime1(float time)
            {
                yield return new WaitForSeconds(time);

                Scream.Play();
            }

            StartCoroutine(ExecuteAfterTime1(3));


            //Timer
            IEnumerator ExecuteAfterTime2(float time)
            {
                yield return new WaitForSeconds(time);

                Text.SetActive(true);
            }

            StartCoroutine(ExecuteAfterTime2(10));

            IEnumerator ExecuteAfterTime3(float time)
            {
                yield return new WaitForSeconds(time);

                Destroy(Scream);
                Button.SetActive(true);
            }

            StartCoroutine(ExecuteAfterTime3(17));
        }
    }
    
}
