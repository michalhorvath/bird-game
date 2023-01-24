using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    private Vector3 defaultPosition = new Vector3(-0.03f,2.04f,6.35f);
    private Quaternion defaultRotation = new Quaternion(0f,-0.99699f,0.07757f,0f);

    private Vector3 closeupPosition = new Vector3(-1.02f,1.30f,2.22f);
    private Quaternion closeupRotation = new Quaternion(-0.07442f,-0.96619f,0.05257f,-0.24118f);

    private Vector3 desiredPosition;
    private Quaternion desiredRotation;
    private float speedPosition = 0.1f;
    private float speedRotation = 0.1f;

    void Awake(){
        changeCameraPosition(CameraState.Default);
    }

    void Start(){
    }

    void Update(){
        transform.position = 
            Vector3.Lerp(transform.position, desiredPosition, speedPosition);
        transform.rotation = 
            Quaternion.Lerp(transform.rotation, desiredRotation, speedRotation);
    }

    public void changeCameraPosition(CameraState cameraState){
        switch (cameraState){
            case CameraState.Default:
                desiredPosition = defaultPosition;
                desiredRotation = defaultRotation;
                break;
            case CameraState.Closeup:
                desiredPosition = closeupPosition;
                desiredRotation = closeupRotation;
                break;
        }
    }
}

public enum CameraState{
    Default,
    Closeup
}
