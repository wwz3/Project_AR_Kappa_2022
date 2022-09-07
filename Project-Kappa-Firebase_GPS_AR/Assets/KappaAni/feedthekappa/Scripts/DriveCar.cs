using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class DriveCar : MonoBehaviour
{

    //Car Speed Movement
    public float speed = 10.0F;
    //Left Right Car Movement Speed
    public float rotationSpeed = 100.0F;
    void Update()
    {
        //Get Joystick Control
        float translation = CrossPlatformInputManager.GetAxis("Vertical") * speed;
        float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
}