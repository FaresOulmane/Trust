using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    private bool couroutineAllowed;

    private int numberShown;
    // Start is called before the first frame update
    void Start()
    {
        couroutineAllowed = true;
        numberShown = 0;
    }

    private void OnMouseDown()
    {
        if (couroutineAllowed)
            StartCoroutine("RotateWheel");
    }

    private IEnumerator RotateWheel()
    {
        couroutineAllowed = false;
      transform.Rotate(0,40,0);
           yield return new WaitForSeconds(0.01f);
        
        couroutineAllowed = true;
        numberShown += 1;
        if (numberShown > 9)
            numberShown = 0;
        Rotated(name, numberShown);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(numberShown);
    }
}
