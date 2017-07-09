using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {

    Rigidbody body;

    float force;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();

        force = 0;
	}
	
    public void WriteMotor (float value)
    {
        force += value;
        body.AddForce(transform.up * force);        
    }

    public float GetThrottle ()
    {
        return force;
    }
}
