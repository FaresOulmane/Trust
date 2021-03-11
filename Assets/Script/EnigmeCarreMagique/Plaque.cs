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
    public Vector3 StartedPos => startedPos;

    void Awake()
    {
        startedPos = transform.localPosition;
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

   
}

