﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Animator animator; 
    [SerializeField] private GameObject doorBox;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            doorBox.transform.localPosition = new Vector3(0.5f,0,0.5f);
            doorBox.transform.localRotation = Quaternion.Euler(0,90,0);
            animator.SetBool("Open",true);
            animator.SetBool("Close",false);
         
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            doorBox.transform.localPosition = new Vector3(0,0,0);
            doorBox.transform.localRotation = Quaternion.Euler(0,0,0);
            animator.SetBool("Open",false);
            animator.SetBool("Close",true);

        }
    }
}
