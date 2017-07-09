using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour {

    public Motor motor0;
    public Motor motor1;
    public Motor motor2;
    public Motor motor3;

    public IMU imu;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        Quaternion rot = imu.GetRotation();
        Vector3 acc = imu.GetAcceleration();
        float alt = imu.GetAltitude();

        DroneInformation info = new DroneInformation();

        float ysqr = rot.y * rot.y;

        // roll (x-axis rotation)
        float t0 = +2.0f * (rot.w * rot.x + rot.y * rot.z);
        float t1 = +1.0f - 2.0f * (rot.x * rot.x + ysqr);

        float roll = Mathf.Atan2(t0, t1);

        // pitch (y-axis rotation)
        float t2 = +2.0f * (rot.w * rot.y - rot.z * rot.x);
        t2 = ((t2 > 1.0) ? 1.0f : t2);
        t2 = ((t2 < -1.0) ? -1.0f : t2);

        float pitch = Mathf.Asin(t2);

        // yaw (z-axis rotation)
        float t3 = +2.0f * (rot.w * rot.z + rot.x * rot.y);
        float t4 = +1.0f - 2.0f * (ysqr + rot.z * rot.z);

        float yaw = Mathf.Atan2(t3, t4);


        info.rotx = roll;
        info.roty = pitch;
        info.rotz = yaw;

        /*
        info.rotw = rot.w;
        info.rotx = rot.x;
        info.roty = rot.y;
        info.rotz = rot.z;
        */

        info.accx = acc.x;
        info.accy = acc.y;
        info.accz = acc.z;

        info.alt = alt;

        Application.ExternalCall("WriteData", JsonUtility.ToJson(info));
    }

    public void WriteMotorFromSocket(string data)
    {
        MotorInformation mjr = JsonUtility.FromJson<MotorInformation>(data);

        if (mjr.side == "front")
        {
            motor0.WriteMotor(mjr.thrust);
            motor3.WriteMotor(mjr.thrust);
        } else if (mjr.side == "back")
        {
            motor1.WriteMotor(mjr.thrust);
            motor2.WriteMotor(mjr.thrust);
        } else if (mjr.side == "left")
        {
            motor0.WriteMotor(mjr.thrust);
            motor1.WriteMotor(mjr.thrust);
        } else if (mjr.side == "right")
        {
            motor2.WriteMotor(mjr.thrust);
            motor3.WriteMotor(mjr.thrust);
        } else
        {
            throw new System.NotSupportedException();
        }
    }
}

class MotorInformation
{
    public string side;
    public float thrust;
}

class DroneInformation
{
    public float rotw;
    public float rotx;
    public float roty;
    public float rotz;

    public float accx;
    public float accy;
    public float accz;

    public float alt;
}