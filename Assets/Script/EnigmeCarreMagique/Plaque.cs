using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaque : MonoBehaviour
{
    [SerializeField] private int number;

    public int Number => number;

    private Vector3 Offset;
    private float camZ;
    private Vector3 startedPos;
    [SerializeField] private Camera cam;
    public bool placable;
    public Vector3 StartedPos => startedPos;

    void Awake()
    {
       
        startedPos = transform.position;
    }
    // recupere les pos quand on clique sur la plaque
    void OnMouseDown()
    {
        camZ= cam.WorldToScreenPoint(transform.position).z;
        Offset = transform.position - MouseWorldPoint();

    }
// recupere la pos de la souris
    private Vector3 MouseWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = camZ;
        return cam.ScreenToWorldPoint(mousePoint);
    }
    // bouge la plaque au curseur de la souris quand on reste appuyer sur le clique
    void OnMouseDrag()
    {
        transform.position = MouseWorldPoint() + Offset;
    }
// detecte si la plaque est sur le coffre
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag(("Coffre")))
        {
            placable = true;
          
        }
    }
    // Verifie le bool qui gere si la plaque est sur le coffre et si c est pas le cas reset la pos de la plaque
    private void OnMouseUp()
    {
        if (!placable)
        {
            transform.position = startedPos;
        }
            
    }
// detecte si la plaque n est plus en contact avec le coffre
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag(("Coffre")))
        {
            placable = false;
           
        }
    }
}

