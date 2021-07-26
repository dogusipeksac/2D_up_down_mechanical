using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public MovementJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movementJoystick.joystickVektor.y != 0){
            rigidbody2D.velocity=new Vector2(movementJoystick.joystickVektor.x*playerSpeed,
            movementJoystick.joystickVektor.y*playerSpeed);
        }
        else{
            rigidbody2D.velocity=Vector2.zero;
        }


    }
}
