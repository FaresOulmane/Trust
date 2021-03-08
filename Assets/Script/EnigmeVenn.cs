using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnigmeVenn : MonoBehaviour
{
    // [SerializeField] private Button[] symbole;
    public int digit = 1;
    static int[] solution = {1, 2, 3};
    private static int[] input = {-1, -1, -1};

    private void OnMouseDown()
    {
        input[0] = input[1];
        input[1] = input[2];
        input[2] = digit;

        if (solution[0] == input[0] && solution[1] == input[1] && solution[2] == input[2])
        {
            Debug.Log("corrects");
        }
    }
}
