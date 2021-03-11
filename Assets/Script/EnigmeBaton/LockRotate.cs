using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    private bool couroutineAllowed;

    private int numberShown;
   
    void Start()
    {
        couroutineAllowed = true;
        numberShown = 0;
    }
// si on clique sur une roulette sa lance la coroutine
    private void OnMouseOver()
    {

        if (couroutineAllowed)
        {
            if(Input.GetMouseButtonDown(0))
                StartCoroutine(nameof(RotateWheel));
            if(Input.GetMouseButtonDown(1))
                StartCoroutine(nameof(RotateInverseWheel));
        }
           
    }
// coroutine permettant de faire une rotation sur la roulette et d augmente le chiffre de 1
    private IEnumerator RotateWheel()
    {
        couroutineAllowed = false;
      transform.Rotate(0,36f,0);
           yield return new WaitForSeconds(0.01f);
        
        couroutineAllowed = true;
        numberShown += 1;
        if (numberShown > 9)
            numberShown = 0;
        Rotated(name, numberShown);
    }
    // coroutine permettant de faire une rotation inverse sur la roulette et de diminuer le chiffre de 1
    private IEnumerator RotateInverseWheel()
    {
        couroutineAllowed = false;
        transform.Rotate(0,-36f,0);
        yield return new WaitForSeconds(0.01f);
        
        couroutineAllowed = true;
        numberShown -= 1;
        if (numberShown < 0)
            numberShown = 9;
        Rotated(name, numberShown);
    }
   
}
