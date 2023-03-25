﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarController : MonoBehaviour
{
    public float speed = 1500f;
    public float rotationSpeed = 15f;

    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;
    public Rigidbody2D _rb;

    private float movement = 0f;
    private float rotation = 0f;

    private void Update()
    {
        movement = Input.GetAxisRaw("Vertical")* speed;
        rotation = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if(movement == 0f)
        {
            backWheel.useMotor = false;
            frontWheel.useMotor = false;
        }
        else
        {
            backWheel.useMotor = true;
            frontWheel.useMotor = true;
            JointMotor2D moter = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000 };
            backWheel.motor = moter;
            frontWheel.motor = moter;
        }

        _rb.AddTorque(-rotation * rotationSpeed * Time.fixedDeltaTime);
    }
}
