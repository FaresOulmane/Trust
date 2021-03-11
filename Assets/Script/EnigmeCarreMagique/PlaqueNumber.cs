using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaqueNumber : MonoBehaviour
{
  [SerializeField] private int num;
  public int Num => num;
// detecte si il y a une plaque sur le trigger afin de recupere le chiffre que contient la plaque
  private void OnTriggerStay(Collider col)
  {
     
      if (col.gameObject.tag =="Plaque")
      {
          num = col.GetComponent<Plaque>().Number;
      }
     
  }


}
