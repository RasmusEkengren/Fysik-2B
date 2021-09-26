using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float RotationTime;
    public Vector3 rotationAxis;
    
    void FixedUpdate()
    {
        this.transform.Rotate(rotationAxis, (360/RotationTime)*Time.fixedDeltaTime*Gravity.TimeScale);
    }
}
