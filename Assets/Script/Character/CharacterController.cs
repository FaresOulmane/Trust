using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float speed;
      [SerializeField] private float runSpeed;
      [SerializeField] private float walkSpeed;
      UnityEngine.CharacterController cc;
     
      [SerializeField] private float timeToRun;
   
       private float turnSmoothVelocity;
      [SerializeField] private float turnSmoothTime;
      [SerializeField] private Transform cam;
      private float playerYVelocity;
      private bool canMove;
      private bool isMoving;
      private bool onEnigme;
    
      public bool OnEnigme => onEnigme;
      
        private Animator animator;
        
        [SerializeField] private TextMeshProUGUI textInteract;
        private Transform camTr;
        private RectTransform interactRect;

        private void Awake()
      {
          animator = GetComponent<Animator>();
          canMove = true;
           speed = walkSpeed;
           cc = GetComponent<UnityEngine.CharacterController>();
           camTr = Camera.main.transform;
           interactRect = textInteract.GetComponent<RectTransform>();

      }

      private void Start()
      {
          isMoving = false;
      }

      private void Update()
       {
           PlayerMove();
         
          interactRect.rotation = camTr.rotation;
       }
    
   // Deplacement du perso gerant la rotation selon la camera et jouant les animation de course ou marche
       void PlayerMove()
       {

           if (!cc.isGrounded) 
               playerYVelocity += Physics.gravity.y * Time.deltaTime;
           else
               playerYVelocity = 0f;
           Vector3 moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
           moveVector.y = playerYVelocity;
          
           if (canMove &&( Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical")!=0) )
           {
               isMoving = true;
              
               float targetAngle = Mathf.Atan2(moveVector.x, moveVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
               float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                   turnSmoothTime);
               transform.rotation = Quaternion.Euler(0,angle,0);
              Vector3 moveDirection =  Quaternion.Euler(0,targetAngle,0) * Vector3.forward;
           
               cc.Move(new Vector3(moveDirection.x,moveVector.y,moveDirection.z) * (speed * Time.deltaTime));
               
               if (speed <= walkSpeed + 1)
               {
                   animator.SetBool("marche",true);
                   animator.SetBool("run",false); 
               }

               else
               {
                  animator.SetBool("run",true); 
               }
           }
           else
           {
              
               isMoving = false;
               animator.SetBool("marche",false); 
               animator.SetBool("run",false); 
             
        }
           if (Input.GetKey(KeyCode.LeftShift)&&isMoving)
               speed = Mathf.Lerp(speed, runSpeed, Time.deltaTime* timeToRun);
           else
               speed = Mathf.Lerp(speed, walkSpeed, Time.deltaTime * timeToRun);
       }
// freeze le perso et la camera
       public void StopMove()
       {
           canMove = false;
           onEnigme = true;

       }
// redonne la possibilite au joueur de se deplacer et de bouger la cam
       public void MoveAgain()
       {
           canMove = true;
           onEnigme = false;
       }
// detecte si le joueur est sur un escalier pour jouer l anim
       private void OnTriggerStay(Collider col)
       {
          
           if (col.gameObject.CompareTag("Escalier"))
           {
              
               Vector3 forward = transform.TransformDirection(Vector3.forward); Vector3 toOther = col.gameObject.transform.position - transform.position;
               if (isMoving)
               {
                   if (Vector3.Dot(forward, toOther) < 1)
                   {
                       animator.SetBool("escalier",true);
                       animator.SetBool("escalierDown",false);
                   }
                   else
                   {
                       animator.SetBool("escalierDown", true);
                       animator.SetBool("escalier",false);
                   }
                  
               }

               else
               {
                   animator.SetBool("escalier",false);
                   animator.SetBool("escalierDown",false);
               }

           }
          
       }
// quand le joueur n est plus sur un escalier l animation escalier s arrete
       private void OnTriggerExit(Collider col)
       {
        
           if (col.gameObject.CompareTag("Escalier"))
           {
               animator.SetBool("escalier",false);
               animator.SetBool("escalierDown",false);
              
           }
       }
}
