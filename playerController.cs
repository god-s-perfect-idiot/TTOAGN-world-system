using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //reqs
    public CharacterController controller;
    public Transform cam;
    public Transform player;

    //attributes
    public float playerSpeed = 2f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    void Start(){
      controller = GetComponent<CharacterController>();
      Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Get-key
        float horizontalPressed = Input.GetAxisRaw("Horizontal");
        float verticalPressed = Input.GetAxisRaw("Vertical");
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        if(runPressed){
          playerSpeed = 10f;
        }
        else{
          playerSpeed = 2f;
        }
        //calcs
        Vector3 direction = new Vector3(horizontalPressed, 0f, verticalPressed).normalized;

        //move
        if(direction.magnitude >= 0.1f){
          float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
          float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
          transform.rotation = Quaternion.Euler(0f, angle, 0f);

          Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
          controller.Move(moveDir  * playerSpeed * Time.deltaTime);
        //player.Translate(direction * Time.deltaTime);
        }

    }
}
