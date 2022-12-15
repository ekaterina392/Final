using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    //Start canvas
    public GameObject CanvasStart;
    
    private KeyCode pickKey = KeyCode.E;

    //Pickup Settings
    [SerializeField] private Transform holdArea;
    private GameObject heldObject;
    private Rigidbody heldObjectRB;
    
    //Physics Parameters
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    private void Update()
    {
        if (Input.GetKeyDown(pickKey) && CanvasStart == null)
        {
            if (heldObject == null && CanvasStart == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,
                        pickupRange) && CanvasStart == null)
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }

        if (heldObject != null && CanvasStart == null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObject.transform.position, holdArea.position) > 0.1f && CanvasStart == null)
        {
            Vector3 moveDirection = (holdArea.position - heldObject.transform.position);
            heldObjectRB.AddForce(moveDirection * pickupForce);
        }
    }

    void PickupObject(GameObject pickObject)
    {
        if (pickObject.GetComponent<Rigidbody>() && CanvasStart == null)
        {
            heldObjectRB = pickObject.GetComponent<Rigidbody>();
            heldObjectRB.useGravity = false;
            heldObjectRB.drag = 10;
            heldObjectRB.constraints = RigidbodyConstraints.FreezeRotation;
            heldObjectRB.transform.parent = holdArea;
            heldObject = pickObject;
        }
    }
    
    void DropObject()
    {
            heldObjectRB.useGravity = true;
            heldObjectRB.drag = 1;
            heldObjectRB.constraints = RigidbodyConstraints.None;
            heldObjectRB.transform.parent = null;
            heldObject = null;
    }
}