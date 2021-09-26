using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHover : MonoBehaviour
{
    public GameObject Earth;
    public GameObject Moon;
    public float RotationSpeed = 1;
    public float ScrollSpeed = 5;
    public float smoothTime = 0.2f;
    public Gravity gravity;

    private Transform target;
    private float rotationX;
    private float rotationY;
    private Vector3 curRotation;
    private float hoverDistance = 5f;

    private Vector3 smoothVelocity = Vector3.zero;
    
    private void Start()
    {
        HoverEarth();
    }
    public void HoverMoon()
    {
        target = Moon.transform;
    }
    public void HoverEarth()
    {
        target = Earth.transform;
    }
    private void LateUpdate()
    {
        float inputScroll = Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;

        hoverDistance = Mathf.Clamp(hoverDistance - (inputScroll * (Input.GetKey(KeyCode.LeftShift) ? 10 : 1)), 4, 100);


        float inputX = Input.GetAxis("Horizontal") * RotationSpeed;
        float inputY = Input.GetAxis("Vertical") * RotationSpeed;

        rotationX += inputX;
        rotationY += inputY;

        float angle = 0;
        if (target.gameObject == Moon)
        {
            Vector3 dir = gravity.DirectionToEarth();
            if (dir.z >= 0)
            {
                angle = Mathf.Rad2Deg * Mathf.Acos(dir.x);
            }
            else if (dir.z < 0)
            {
                angle = 360 - (Mathf.Rad2Deg * Mathf.Acos(dir.x));
            }
        }
        Vector3 TargetRotation = new Vector3(rotationY, -rotationX - angle);
        curRotation = Vector3.SmoothDamp(curRotation, TargetRotation, ref smoothVelocity, smoothTime);

        transform.localEulerAngles = curRotation;

        transform.position = target.position - transform.forward * hoverDistance;

        //TODO 
        //Fix when angle goes from 360 to 0 so it doesn't snap weirdly like it does at hight timescales
        //add option to follow moon while hovering earth
    }
}
