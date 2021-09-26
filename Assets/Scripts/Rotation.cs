using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float RotationTime;
    
    void FixedUpdate()
    {
        this.transform.Rotate(Vector3.up, (360/RotationTime)*Time.fixedDeltaTime*Gravity.TimeScale);
    }
}
