using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptexRotate : MonoBehaviour
{
    public static event Action<string, int> RotatedCryptex = delegate { };

    private bool cryptexCouroutineAllowed;

    private int numberShown;
    // Start is called before the first frame update
    void Start()
    {
        cryptexCouroutineAllowed = true;
        numberShown = 0;
    }
// si on clique sur une roulette sa lance la coroutine
    private void OnMouseOver()
    {
        if (cryptexCouroutineAllowed)
        {
            if(Input.GetMouseButtonDown(0))
                StartCoroutine(nameof(RotateCryptexWheel));
            if (Input.GetMouseButtonDown(1))
                StartCoroutine(nameof(RotateInverseCryptexWheel));

        }
           
    }
// coroutine permettant de faire une rotation sur la roulette et d augmente le chiffre de 1
    private IEnumerator RotateCryptexWheel()
    {
        cryptexCouroutineAllowed = false;
        transform.Rotate(-13.8333333f,0,0);
        yield return new WaitForSeconds(0.01f);
        
        cryptexCouroutineAllowed = true;
        numberShown += 1;
        if (numberShown > 25)
            numberShown = 0;
        RotatedCryptex(name, numberShown);
    }
    // coroutine permettant de faire une rotation inverse sur la roulette et de diminuer le chiffre de 1
    private IEnumerator RotateInverseCryptexWheel()
    {
        cryptexCouroutineAllowed = false;
        transform.Rotate(13.8333333f,0,0);
        yield return new WaitForSeconds(0.01f);
        
        cryptexCouroutineAllowed = true;
        numberShown -= 1;
        if (numberShown < 0)
            numberShown = 25;
        RotatedCryptex(name, numberShown);
    }
  
   
}
