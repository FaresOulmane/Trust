using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeRotation : MonoBehaviour
{
   float tour;
       float rot;
       private bool first = false;
      [SerializeField] private MainEasterEgg mee;
      // private Animator animator;
      //
      // void Awake()
      // {
      //     animator = GetComponent<Animator>();
      // }
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
           if (Input.GetKey(KeyCode.E))
           {
               tour += Time.deltaTime;
               // animator.SetBool("rotating",true);
               // animator.SetBool("stopRotate",false);
           }
           if(Input.GetKeyUp(KeyCode.E))
           {
               // animator.SetBool("rotating",false);
               // animator.SetBool("stopRotate",true);
               tour = 0;
           }
           
       }
   

}
