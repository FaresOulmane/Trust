using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaque : MonoBehaviour
{
    [SerializeField] public int number;
    private Vector3 Offset;
    private float camZ;
    public Vector3 startedPos;
    
    void Awake()
    {
        startedPos = transform.localPosition;
    }
    void OnMouseDown()
    {
        camZ= Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Offset = gameObject.transform.position - MouseWorldPoint();

    }

    private Vector3 MouseWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = camZ;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        transform.position = MouseWorldPoint() + Offset;
    }

   
}

