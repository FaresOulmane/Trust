using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeRotation : MonoBehaviour
{
   float tour;
       float rot;
       private bool first = false;
      [SerializeField] private MainEasterEgg mee;
       private void Update()
       {
           if (tour >= 10)
           {
               first = true;
           }
   
           if (first)
           {
               mee.Interactable = true;
           }
           RotateGlobe();
       }
   
       private void RotateGlobe()
       {
           if (Input.GetKey(KeyCode.Space))
           {
               rot += Time.deltaTime * 90;
               transform.rotation = Quaternion.Euler(0, rot, 0);
               tour += Time.deltaTime;
           }
           if(Input.GetKeyUp(KeyCode.A))
           {
               tour = 0;
           }
           
       }
   

}
