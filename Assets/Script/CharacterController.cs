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
     
      private void Awake()
      {
          canMove = true;
           speed = walkSpeed;
           cc = GetComponent<UnityEngine.CharacterController>();
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
           
           if (moveVector.magnitude >= 1f && canMove)
           {
               isMoving = true;
               float targetAngle = Mathf.Atan2(moveVector.x, moveVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
               float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                   turnSmoothTime);
               transform.rotation = Quaternion.Euler(0,angle,0);
              Vector3 moveDirection =  Quaternion.Euler(0,targetAngle,0) * Vector3.forward;
               cc.Move(new Vector3(moveDirection.x,moveVector.y,moveDirection.z) * (speed * Time.deltaTime));
              
           }
           else
           {
               isMoving = false;
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
}
