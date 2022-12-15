using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class DialogControllerScene4 : MonoBehaviour
{
    public AudioSource MonsterLaugh;
    public GameObject Trigger;
    public Transform DragonTransform;
    public GameObject CanvasPressF;
    public GameObject Dragon;
    public GameObject CanvasEvil;
    public CinemachineFreeLook Cinemachine;
    public GameObject Monster;
    public Transform MonsterCamera;
    
    private void Awake()
    {
        Dragon.GetComponent<FireBreath>().enabled = false;
        CanvasEvil.SetActive(false);
        CanvasPressF.SetActive(false);
    }

    void Update()
    {
        if (Vector3. Distance(gameObject.transform.position, Monster.transform.position) < 10 && CanvasEvil != null)
        {
            Cinemachine.LookAt = MonsterCamera;
            Cinemachine.Follow = MonsterCamera;
            Cinemachine.m_Orbits[1].m_Height = 1.26f;
            Cinemachine.m_Orbits[1].m_Radius = 6.41f;
            Cinemachine.m_XAxis.Value = 41;
            CanvasEvil.SetActive(true);
            
            //disable player controller script
            Dragon.GetComponent<ThirdPersonMovementScene4>().enabled = false;
            
            Destroy(Trigger);
            MonsterLaugh.Play();
        }

        if (Trigger == null && Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(CanvasEvil);
        }

        if (CanvasEvil == null)
        {
            CanvasPressF.SetActive(true);
            Dragon.GetComponent<FireBreath>().enabled = true;
            Cinemachine.LookAt = DragonTransform;
            Cinemachine.Follow = DragonTransform;
            Cinemachine.m_Orbits[1].m_Height = 3.8f;
            Cinemachine.m_Orbits[1].m_Radius = 8;
            Cinemachine.m_XAxis.Value = -78.4f;
        }
    }
}