using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaqueNumber : MonoBehaviour
{
  [SerializeField] public int num;

  private void OnTriggerStay(Collider col)
  {
     
      if (col.gameObject.tag =="Plaque")
      {
          Debug.Log("ok");
         num = col.GetComponent<Plaque>().number;
      }
     
  }


}
