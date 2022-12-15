using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    private Animator Monster;
    public static float speed = 5f;
    NavMeshAgent _agent;
    public Transform[] targetLocations;
    public Transform playerTarget;
    private int _targetIndex = 0;
    public float sight = 10f;
        
    void Start()
    {
        Monster = gameObject.GetComponent<Animator>();
        _agent = transform.GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        Monster.SetBool("isChasing", false);
        Monster.SetBool("isAttacking", false);
        _agent.speed = speed;
        int layerMask = 1 << 3;
        if (Vector3.Distance(transform.position,playerTarget.position)<sight 
            && !Physics.Linecast (transform.position, playerTarget.transform.position,layerMask)) {
            _agent.SetDestination(playerTarget.position);
            
            //Running animation set up
            Monster.SetBool("isChasing", true);
            
            //Increase enemy speed after noticing the player
            _agent.speed = 10f;
            
            if (Vector3.Distance(transform.position,playerTarget.position)<10f)
            {
                Monster.SetBool("isAttacking", true);
                _agent.speed = 0;
            }
        }
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    GoToNextLocation();
                }
            }
        }
    }

    public void GoToNextLocation()
    {
        _agent.SetDestination(targetLocations[_targetIndex].position);
        _targetIndex = (_targetIndex+ 1) % targetLocations.Length;
    }
}