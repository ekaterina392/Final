using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class DialogControllerScene4 : MonoBehaviour
{
    public Transform DragonTransform;
    
    public GameObject Dragon;
    public GameObject CanvasEvil;

    public CinemachineFreeLook Cinemachine;
    //public CinemachineFreeLook.Orbit[] originalOrbits;
    
    public GameObject Throne;
    public Transform ThroneCamera;
    
    private void Awake()
    {
        CanvasEvil.SetActive(false);
    }

    void Update()
    {
        if (Vector3. Distance(gameObject.transform.position, Throne.transform.position) < 10 && CanvasEvil != null)
        {
            Cinemachine.LookAt = ThroneCamera;
            Cinemachine.Follow = ThroneCamera;
            
            Cinemachine.m_Orbits[1].m_Height = 1.26f;
            Cinemachine.m_Orbits[1].m_Radius = 6.41f;

            Cinemachine.m_XAxis.Value = 41;
            
            CanvasEvil.SetActive(true);
            
            //disable player controller script
            Dragon.GetComponent<ThirdPersonMovementScene4>().enabled = false;
            
            //After ... seconds pass
            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);
 
                Destroy(CanvasEvil);
            }
            
            StartCoroutine(ExecuteAfterTime(3));

            //
            //Cinemachine.m_Orbits

            //Cinemachine.GetRig(1).m_Lens.FieldOfView = 20;

/*
            Cinemachine.GetRig(0).GetCinemachineComponent<CinemachineComposer>().m_ScreenX = 10;
            Cinemachine.GetRig(1).GetCinemachineComponent<CinemachineComposer>().m_ScreenX = 10;
            Cinemachine.GetRig(2).GetCinemachineComponent<CinemachineComposer>().m_ScreenX = 10;        
            
            Cinemachine.GetRig(0).GetCinemachineComponent<CinemachineComposer>().m_ScreenY = 10;
            Cinemachine.GetRig(1).GetCinemachineComponent<CinemachineComposer>().m_ScreenY = 10;
            Cinemachine.GetRig(2).GetCinemachineComponent<CinemachineComposer>().m_ScreenY = 10;
            */
        }

        if (CanvasEvil == null)
        {
            Dragon.GetComponent<ThirdPersonMovementScene4>().enabled = true;

            Cinemachine.LookAt = DragonTransform;
            Cinemachine.Follow = DragonTransform;
            
            Cinemachine.m_Orbits[1].m_Height = 3.8f;
            Cinemachine.m_Orbits[1].m_Radius = 8;

            Cinemachine.m_XAxis.Value = -78.4f;
        }
    }
}
