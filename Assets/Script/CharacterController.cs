using System;
using System.Collections;
using System.Collections.Generic;
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
      [SerializeField] private GameObject freeLookCam;
        private Animator animator;
      private void Awake()
      {
          animator = GetComponent<Animator>();
          canMove = true;
           speed = walkSpeed;
           cc = GetComponent<UnityEngine.CharacterController>();
         
      }

      private void Start()
      {
          isMoving = false;
      }

      private void Update()
       {
        
          PlayerMove();
          Debug.Log(speed);
       }
   
       void PlayerMove()
       {
         
            bool isGrounded = cc.isGrounded;
           if (isGrounded && playerYVelocity < 0)
           {
               playerYVelocity = 0f;
           }
           playerYVelocity += Physics.gravity.y * Time.deltaTime;
           Vector3 moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
           moveVector.y = playerYVelocity;
           
           if (Input.GetAxisRaw("Horizontal")!=0 && canMove || Input.GetAxisRaw("Vertical")!=0 && canMove )
           {
               isMoving = true;
              
               float targetAngle = Mathf.Atan2(moveVector.x, moveVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
               float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                   turnSmoothTime);
               transform.rotation = Quaternion.Euler(0,angle,0);
              Vector3 moveDirection =  Quaternion.Euler(0,targetAngle,0) * Vector3.forward;
               cc.Move(new Vector3(moveDirection.x,moveVector.y,moveDirection.z) * (speed * Time.deltaTime));
               animator.SetBool("marche",false); 
            animator.SetBool("idle", true);
        }
           else
           {
               isMoving = false;
               animator.SetBool("marche",true); 
               animator.SetBool("idle", false);
        }
           if (Input.GetKey(KeyCode.LeftShift)&&isMoving)
               speed = Mathf.Lerp(speed, runSpeed, Time.deltaTime* timeToRun);
           else
               speed = Mathf.Lerp(speed, walkSpeed, Time.deltaTime * timeToRun);
       }

       public void StopMove()
       {
           canMove = false;
           freeLookCam.SetActive(false);

       }

       public void MoveAgain()
       {
           canMove = true;
           freeLookCam.SetActive(true);
       }

       // private void OnTriggerStay(Collider col)
       // {
       //     Debug.Log("salut");
       //     if (col.gameObject.CompareTag("Escalier"))
       //     {
       //         animator.SetBool("transition_escalier_idle",true);
       //         animator.SetBool("transition_marche_escalier",true);
       //     }
       //     else if (col.gameObject.CompareTag("Untagged"))
       //     {
       //         animator.SetBool("transition_escalier_idle",false);
       //         animator.SetBool("transition_marche_escalier",false);
       //     }
       // }
}
