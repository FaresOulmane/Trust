using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeCarreMagique : MonoBehaviour
{
    [SerializeField] private PlaqueNumber[] plaqueNumber;
    [SerializeField] private Plaque[] plaque;
    // Update is called once per frame
    void Update()
    {
       if(plaqueNumber[0].num + plaqueNumber[4].num + plaqueNumber[8].num == 15 &&
          plaqueNumber[0].num + plaqueNumber[1].num + plaqueNumber[2].num == 15 &&
          plaqueNumber[3].num + plaqueNumber[4].num + plaqueNumber[5].num == 15 &&
          plaqueNumber[6].num + plaqueNumber[7].num + plaqueNumber[8].num == 15 &&
          plaqueNumber[0].num + plaqueNumber[3].num + plaqueNumber[6].num == 15 &&
          plaqueNumber[1].num + plaqueNumber[4].num + plaqueNumber[7].num == 15 &&
          plaqueNumber[2].num + plaqueNumber[5].num + plaqueNumber[8].num == 15 &&
          plaqueNumber[6].num + plaqueNumber[4].num + plaqueNumber[2].num == 15
          )
       {
           Debug.Log("gg");
       }
    }
    public void ResetPos()
    {
        for (int i = 0; i < plaque.Length; i++)
        {
            plaque[i].transform.localPosition = plaque[i].startedPos;
        }
       
    }
}
