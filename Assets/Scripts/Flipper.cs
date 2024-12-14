using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * The flipper script controls the flippers on the pinball table. 
 * To use set a desired key to control the flipper in the inspector.
 * The flipper can be set up to be a "left" or "right" flipper
 */
public class Flipper : MonoBehaviour
{
    HingeJoint joint;
    public AudioSource audio;
    public string flipperKey;
    public float flipperPower = 2000f;
    public bool leftFlipper = false;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        joint = GetComponent<HingeJoint>();
    }

    private void Start()
    {
        if (leftFlipper)
        {
            // flip the sign of the power in order to ensure it swings in the correct direction
            flipperPower *= -1; 
        }        
    }

    void Update()
    {
        if (Input.GetKey(flipperKey))
        {
            var motor = joint.motor;
            motor.targetVelocity = flipperPower;
            joint.motor = motor; // must set the joint's motor to the motor we just created (??? don't ask me why) 
        }
        else
        {
            var motor = joint.motor;
            motor.targetVelocity = -flipperPower;
            joint.motor = motor;
        }
    }


}
