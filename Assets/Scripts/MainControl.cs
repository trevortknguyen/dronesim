using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour {

    public Motor motor0;
    public Motor motor1;
    public Motor motor2;
    public Motor motor3;

    MotorController controller;

	// Use this for initialization
	void Start () {
        controller = new KeyboardMockInput();
	}
	
	// Update is called once per frame
	void Update ()
    {
        motor0.WriteMotor(controller.GetMotorInput(0));
        motor1.WriteMotor(controller.GetMotorInput(1));
        motor2.WriteMotor(controller.GetMotorInput(2));
        motor3.WriteMotor(controller.GetMotorInput(3));
    }
}
