using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class DialogControllerScene4 : MonoBehaviour
{
    public CinemachineFreeLook Cinemachine;
    //public CinemachineFreeLook.Orbit[] originalOrbits;
    
    public GameObject Throne;
    public Transform ThroneCamera;
    
    /*
    public void Start()
    {
        Cinemachine = GetComponentInChildren<CinemachineFreeLook>();
        originalOrbits = new CinemachineFreeLook.Orbit[Cinemachine.m_Orbits.Length];
        {
            originalOrbits[1].m_Height = Cinemachine.m_Orbits[i].m_Height;
            originalOrbits[1].m_Radius = Cinemachine.m_Orbits[i].m_Radius;
        }
    } */
    
    void Update()
    {
        if (Vector3. Distance(gameObject.transform.position, Throne.transform.position) < 10)
        {
            Debug.Log("c");
            
            Cinemachine.LookAt = ThroneCamera;
            Cinemachine.Follow = ThroneCamera;
            
            Cinemachine.m_Orbits[1].m_Height = 1.26f;
            Cinemachine.m_Orbits[1].m_Radius = 6.41f;
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
    }
}
