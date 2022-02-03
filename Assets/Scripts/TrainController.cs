using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour {
    public List<AxleInfo> axleInfos;
    public List<TransformInfo> transformInfos;
    public List<CouplerInfo> couplerInfos;

    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float maxBrakeTorque;
    public float suspension;

    public void FixedUpdate() {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float brake = maxBrakeTorque * Input.GetAxis("Horizontal");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.motor) {
                axleInfo.lWheel.motorTorque = motor;
                axleInfo.rWheel.motorTorque = motor;
            }
            if (axleInfo.brake) {
                axleInfo.lWheel.brakeTorque = brake;
                axleInfo.rWheel.brakeTorque = brake;
            }
            if (axleInfo.steering) {
                axleInfo.lWheel.steerAngle = steering;
                axleInfo.rWheel.steerAngle = steering;
            }
            if (axleInfo.suspension) {
                axleInfo.lWheel.suspensionDistance = suspension;
                axleInfo.rWheel.suspensionDistance = suspension;
            }
            if (!axleInfo.suspension) {
                axleInfo.lWheel.suspensionDistance = 0;
                axleInfo.rWheel.suspensionDistance = 0;
            }
        }
        // visual wheel transforms but it kinda doesn't work so uh oh
        // foreach (TransformInfo transformInfo in transformInfos) {
        //     transformInfo.transform.rotation = axleInfo.lWheel.transform.rotation *= Quaternion.Euler(0, 90, 0);
        // }
    }
    // void OnTriggerEnter(Collider coupler) {
    //     foreach (CouplerInfo CouplerInfo in couplerInfos) {
            
    //     }
    // }
}
[System.Serializable]
public class AxleInfo {
    public WheelCollider lWheel;
    public WheelCollider rWheel;
    public bool motor; // is this wheel attached to motor?
    public bool brake; // does this wheel apply steer angle?
    public bool steering; // does this wheel apply steer angle?
    public bool suspension;
}
[System.Serializable]
public class TransformInfo {
    public Transform transform;
}
[System.Serializable]
public class CouplerInfo {
    public Collider collider;
}

//Quaternion.Slerp(, axleInfo.rWheel.transform.rotation, 1)
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

//  public void ApplyLocalPositionToVisuals(WheelCollider collider)
//     {
//         if (collider.transform.childCount == 0) {
//             return;
//         }
     
//         Transform visualWheel = collider.transform.GetChild(0);
     
//         Vector3 position;
//         Quaternion rotation;
//         collider.GetWorldPose(out position, out rotation);
     
//         visualWheel.transform.position = position;
//         visualWheel.transform.rotation = rotation;
//     }