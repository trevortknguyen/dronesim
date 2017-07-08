using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMU : MonoBehaviour {

    Vector3 previousVelocity;
    Vector3 acceleration;

    public Quaternion GetRotation ()
    {
        return transform.rotation;
    }

    public Vector3 GetAcceleration ()
    {
        return acceleration;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        acceleration = (velocity - previousVelocity) / Time.deltaTime;
        previousVelocity = velocity;
    }
}
