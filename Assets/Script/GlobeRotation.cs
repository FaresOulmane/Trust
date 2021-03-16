using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlobeRotation : MonoBehaviour
{
   float tour;
       float rot;
       private bool first = false;
      [SerializeField] private MainEasterEgg mee;
      private Animator animator;
      
      [SerializeField] private TextMeshProUGUI textInteract;
      private Transform camTr;
      private RectTransform interactRect;
      [SerializeField] private float rangeActivateEnigme;
        private CharacterController player;
      void Awake()
      {
          player = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
          camTr = Camera.main.transform;
          interactRect = textInteract.GetComponent<RectTransform>();
          animator = GetComponent<Animator>();
      }
       private void Update()
       {
           interactRect.rotation = camTr.rotation;
           if (tour >= 5)
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
           if (Vector3.Distance(transform.position, player.transform.position) <= rangeActivateEnigme)
           {
               textInteract.text = "??";
               if (Input.GetKey(KeyCode.Space))
               {
                   tour += Time.deltaTime;
                   animator.SetBool("rotating",true);
                   animator.SetBool("stopRotate",false);
               }
               if(Input.GetKeyUp(KeyCode.Space))
               {
                   animator.SetBool("rotating",false);
                   animator.SetBool("stopRotate",true);
                   tour = 0;
               }
           }
           else
           {
               textInteract.text = "";
           }
          
           
       }
   

}
