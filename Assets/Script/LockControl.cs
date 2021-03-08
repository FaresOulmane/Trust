using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    private int[] result;

    private int[] correctCombination;

    private EnigmeBaton enigmeBaton;
    // Start is called before the first frame update
    void Start()
    {
        result = new int[] {0, 0, 0, 0};
        correctCombination = new int[]{3,6,6,5};
        LockRotate.Rotated += CheckResults;
    }

    private void CheckResults(string codeName,int number)
    {
        switch (codeName)
        {
            case "code_1" :
                result[0] = number;
                break;
            case "code_2" :
                result[1] = number;
                break;
            case "code_3" :
                result[2] = number;
                break;
            case "code_4" :
                result[3] = number;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] &&
            result[2] == correctCombination[2] && result[3] == correctCombination[3])
        {
            enigmeBaton.EndEnigme = true;
        }
    }
   
}