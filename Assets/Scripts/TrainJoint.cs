using System.Collections;
using UnityEngine;

public class TrainJoint : MonoBehaviour {
    public GameObject Body;
    public GameObject FBogey;
    public GameObject BBogey;
    // public Transform BodyTransform;
    // public Transform FBogeyTransform;
    // public Transform BBogeyTransform;

    void FixedUpdate() {
        Body.transform.position = new Vector3((FBogey.transform.position.x+BBogey.transform.position.x)/2, ((FBogey.transform.position.y+BBogey.transform.position.y)/2)+2, (FBogey.transform.position.z+BBogey.transform.position.z)/2);

        Body.transform.eulerAngles = new Vector3((FBogey.transform.eulerAngles.x+BBogey.transform.eulerAngles.x)/2, ((FBogey.transform.eulerAngles.y+BBogey.transform.eulerAngles.y)/2)-90, FBogey.transform.eulerAngles.z);
        Debug.Log((FBogey.transform.eulerAngles.x+BBogey.transform.eulerAngles.x)/2);
    }
}
// Body.transform.eulerAngles = new Vector3((FBogey.transform.eulerAngles.x+BBogey.transform.eulerAngles.x)/2,((FBogey.transform.eulerAngles.y+BBogey.transform.eulerAngles.y)/2)-90,(FBogey.transform.eulerAngles.z+BBogey.transform.eulerAngles.z)/2);
// BodyTransform.localRotation = (FBogeyTransform.localRotation + FBogeyTransform.localRotation)/2;
//new Quaternion(0,0,0,0);
//(FBogey.transform.rotation.x),(FBogey.transform.rotation.y+1),(FBogey.transform.rotation.z+1),(FBogey.transform.rotation.w-1)
//cringeobject.transform.localPosition.y+10,cringeobject.transform.localposition.z+10