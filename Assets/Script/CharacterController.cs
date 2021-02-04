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
    
       private void Awake()
       { 
           speed = walkSpeed;
           cc = GetComponent<UnityEngine.CharacterController>();
       }
   
       private void Update()
       {
          PlayerMove();
          
       }
   
       void PlayerMove()
       {
           Vector3 moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
           playerYVelocity += Physics.gravity.y * Time.deltaTime;
   
           if (playerYVelocity < 0)
           {
               playerYVelocity = -1;
           }
           if (moveVector.magnitude >= 0.1f)
           {
               float targetAngle = Mathf.Atan2(moveVector.x, moveVector.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
               float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                   turnSmoothTime);
               
               transform.rotation = Quaternion.Euler(0,angle,0);
              
               Vector3 moveDirection =  Quaternion.Euler(0,targetAngle,0) * Vector3.forward;
               moveDirection.y = playerYVelocity;
              cc.Move(moveDirection.normalized * (speed * Time.deltaTime));
             
           }
           if (Input.GetKey(KeyCode.LeftShift))
               speed = Mathf.Lerp(speed, runSpeed, Time.deltaTime * timeToRun);
           else
               speed = Mathf.Lerp(speed, walkSpeed, Time.deltaTime * timeToRun);
           
       }
}
