using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour {

    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    public void FixedUpdate() {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
            
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }
}

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}

// void Start()
// {
//     Rigidbody = GetComponent<Rigidbody>();
// }

// public Rigidbody Rigidbody;
// public float rayThrust;

// RaycastHit leftHit;
// RaycastHit rightHit;

// if (Physics.Raycast(transform.position, -transform.right, out leftHit)) {
//     Debug.DrawRay(transform.position, -transform.right * leftHit.distance, Color.yellow);
//     if (leftHit.distance > 2) {
//         Rigidbody.AddForce(-transform.right * rayThrust * Time.fixedDeltaTime);
//         Debug.Log("Left: " + leftHit.distance);
//     }
// }

// if (Physics.Raycast(transform.position, transform.right, out rightHit)) {
//     Debug.DrawRay(transform.position, transform.right * rightHit.distance, Color.yellow);
//     if (rightHit.distance > 2) {
//         Rigidbody.AddForce(transform.right * rayThrust * Time.fixedDeltaTime);
//         Debug.Log("Right: " + rightHit.distance);
//     }
// }