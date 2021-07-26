using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementJoystick : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVektor;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;

    bool facingRight = true;



    // Start is called before the first frame update
    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;

    }
    public void PointerDown()
    {
        joystick.transform.position= Input.mousePosition;
        joystickBG.transform.position= Input.mousePosition;
        joystickTouchPos = Input.mousePosition;


    }
    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVektor = (dragPos * joystickTouchPos).normalized;
        float joystickDist = Vector2.Distance(dragPos,joystickTouchPos);
        if (joystickDist<joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVektor * joystickDist;
            
        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVektor * joystickRadius;
            
        }
    }
    public void PointerUp()
    {
        joystickVektor = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
    }
    void flip(float h)
    {
        if (h > 0 && !facingRight || h < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }


}
